using EggStore.Domains.Eggs.Dto;
using EggStore.Domains.Eggs.Repositories;
using EggStore.Domains.Eggs.Validators;
using EggStore.Infrastucture.Helpers.ResponseBuilders;
using EggStore.Infrastucture.Shareds.Constants;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EggStore.Controllers.API.Eggs
{
    [Route("api/eggs")]
    [ApiController]
    public class EggController : ControllerBase
    {
        private readonly EggsRepository _repositoryEgg;
        private readonly EggsValidator _validatorEgg;

        public EggController(
            EggsRepository eggsRepository,
            EggsValidator eggsValidator)
        {
            _repositoryEgg = eggsRepository;
            _validatorEgg = eggsValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GetEggList()
        {
            var data = _repositoryEgg.FindAll();
            return Ok(ResponseBuilder.SuccessResponse(ResponseConstant.Detail, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEggById(Guid id)
        {
            var data = _repositoryEgg.FindById(id);
            return Ok(ResponseBuilder.SuccessResponse(ResponseConstant.Detail, data));
        }

        [HttpPost]
        public async Task<ActionResult> CreateEgg(EggsDto param)
        {
            _validatorEgg.ValidateAndThrow(param);
            var data = _repositoryEgg.Create(param);
            return Ok(ResponseBuilder.SuccessResponse(ResponseConstant.Store, data));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEgg(Guid id, EggsDto param)
        {
            param.Id = id;
            //_validatorEgg.ValidateAndThrow(param);
            var data = _repositoryEgg.Update(param, id);
            return Ok(ResponseBuilder.SuccessResponse(ResponseConstant.Update, data));
        }
    }
}
