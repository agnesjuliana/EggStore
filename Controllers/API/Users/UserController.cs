using EggStore.Domains.Users.Dto;
using EggStore.Domains.Users.Interface;
using EggStore.Infrastucture.Helpers.ResponseBuilders;
using EggStore.Infrastucture.Shareds.Constants;
using EggStore.Infrastucture.Shareds.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace EggStore.Controllers.API.Users
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUsers _users;
        private readonly ILogger<UserController> _logger;

        public UserController(DataContext dataContext, ILogger<UserController> logger, IUsers users)
        {
            _logger = logger;
            _users = users;
        }

        [HttpGet]
        public async Task<ActionResult> UserList()
        {
            var users = await _users.FindAll();
            _logger.LogInformation("GET UserList called");
            return Ok(ResponseBuilder.SuccessResponse(ResponseConstant.Detail, users));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> UserById(Guid id)
        {
            var users = await _users.FindById(id);
            return Ok(ResponseBuilder.SuccessResponse(ResponseConstant.Detail, users));
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UsersDto param)
        {
            if(!ModelState.IsValid)
                return BadRequest(ResponseBuilder.ErrorResponse(400, "Bad Request", ModelState));

            var users = await _users.Create(param);
            return Ok(ResponseBuilder.SuccessResponse(ResponseConstant.Store, users));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(UsersDto param, Guid id)
        {
            var users = await _users.Update(param, id);
            return Ok(ResponseBuilder.SuccessResponse(ResponseConstant.Update, users));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var users = await _users.Delete(id);
            if (users == null)
            {
                _logger.LogWarning("User NOT FOUND", id);
                return NotFound(ResponseBuilder.ErrorResponse(404, "Data not found", null));
            }

            return Ok(ResponseBuilder.SuccessResponse(ResponseConstant.Delete, users));
        }
    }
}
