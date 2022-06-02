using EggStore.Domains.Packages.Dto;
using EggStore.Domains.Packages.Interface;
using EggStore.Infrastucture.Helpers.ResponseBuilders;
using EggStore.Infrastucture.Shareds.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EggStore.Controllers.API.Packages
{
    [Authorize]
    [Route("api/packages")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackages _IPackages;

        public PackageController(IPackages iPackages)
        {
            _IPackages = iPackages;
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
            var data = await Task.FromResult(_IPackages.Create(param));
            return Ok(ResponseBuilder.SuccessResponse(ResponseConstant.Store, data));
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
