using EggStore.Domains.Packages.Dto;
using EggStore.Domains.Packages.Interface;
using EggStore.Domains.Packages.Validators;
using EggStore.Infrastucture.Helpers.ResponseBuilders;
using EggStore.Infrastucture.Shareds.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace EggStore.Controllers.API.Packages
{
    //[Authorize]
    [Route("api/packages")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackages _IPackages;
        private readonly PackagesValidator _packagesValidator;

        public PackageController(
            IPackages iPackages,
            PackagesValidator packagesValidator)
        {
            _IPackages = iPackages;
            _packagesValidator = packagesValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GetPackageList()
        {
            var data = await Task.FromResult(_IPackages.FindAll());
            return Ok(ResponseBuilder.SuccessResponse(ResponseConstant.Detail, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPackageById(Guid id)
        {
            var data = await Task.FromResult(_IPackages.FindById(id));
            return Ok(ResponseBuilder.SuccessResponse(ResponseConstant.Detail, data));
        }

        [HttpPost]
        public async Task<ActionResult> CreatePackage(PackagesDto param)
        {
            //return Ok(param);
            _packagesValidator.ValidateAndThrow(param);
            return Ok(param);

            //var validation = _packagesValidator.Validate(param);
            //if (validation.IsValid)
            //{
            //var data = await Task.FromResult(_IPackages.Create(param));
            //return Ok(ResponseBuilder.SuccessResponse(ResponseConstant.Store, data));
            //}

            //return StatusCode(422, ResponseBuilder.UnprocessableEntityResponse(422, validation));

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePackage(PackagesDto param, Guid id)
        {
            var data = await Task.FromResult(_IPackages.Update(param, id));
            return Ok(ResponseBuilder.SuccessResponse(ResponseConstant.Update, data));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePackage(Guid id)
        {
            var data = await Task.FromResult(_IPackages.Delete(id));
            return Ok(ResponseBuilder.SuccessResponse(ResponseConstant.Delete, data));
        }
    }
}
