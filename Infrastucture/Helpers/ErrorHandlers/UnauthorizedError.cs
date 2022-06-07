using EggStore.Infrastucture.Helpers.ResponseBuilders;

namespace EggStore.Infrastucture.Helpers.ErrorHandlers
{
    public class UnauthorizedError : ResponseFormat
    {
        public UnauthorizedError(string message)
        {
            // Handle error here
            StatusCode = 401;
            Success = false;
            Message = message;
            Errors = null;
        }
    }
}
