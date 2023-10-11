using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopNewsApi.Core.Services;

namespace TopNewsApi.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly RoleService _roleService;
        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var res = (await _roleService.GetAll()).Select(r => r.Name);
            return Ok(new ServiceResponse(true, payload: res));
        }
    }
}
