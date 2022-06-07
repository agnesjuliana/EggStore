using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using EggStore.Infrastucture.Helpers.ResponseBuilders;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sentry;

namespace EggStore.Infrastucture.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ErrorHandlerMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                Console.WriteLine("=================");
                Console.WriteLine("masuk exception");
                Console.WriteLine("=================");

                var response = context.Response;
                response.ContentType = "application/json";
                ResponseFormat result;
                Console.Write(error);

                switch (error)
                {
                    // case when throwing error in application
                    //case BusinessException e:
                    //    response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    //    result = ResponseBuilder.ErrorResponse(response.StatusCode, e.Message, null);
                    //    break;
                    // case when request validation failure
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        result = ResponseBuilder.UnprocessableEntityResponse(response.StatusCode, e);
                        break;
                    // case when throwing auth context error
                    case AuthenticationException e:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        result = ResponseBuilder.ErrorResponse(response.StatusCode, e.Message, null);
                        break;
                    // case for unhandled exception
                    default:
                        // log error to sentry 500 error only
                        SentrySdk.CaptureException(error);
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        // formatting error
                        var errorFormat = new Dictionary<string, string>
                        {
                            {"Type", error.GetType().ToString()},
                            {"Message", error.Message},
                            {"Source", error.Source}
                        };
                        Console.WriteLine("==========ERROR==========");
                        Console.WriteLine(error.StackTrace);
                        Console.WriteLine("==========ERROR==========");
                        if (_configuration?["Logging:AppEnv"] == "dev")
                        {
                            errorFormat.Add("StackTrace", error.StackTrace);
                        }
                        result = ResponseBuilder.ErrorResponse(response.StatusCode, error.Message, errorFormat);
                        break;
                }

                var toJson = JsonConvert.SerializeObject(result, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    },
                    Formatting = Formatting.Indented
                });
                await response.WriteAsync(toJson);
            }
        }
    }
}
