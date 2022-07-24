using Market.Business.Abstract;
using Market.Entities.Dtos.CustomerDtos;
using MarketProject.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Register(CustomerRegisterDto customerRegisterDto)
        {
            var result = await _authService.RegisterAsync(customerRegisterDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CustomerLoginDto customerLoginDto)
        {
            var result = await _authService.LoginAsync(customerLoginDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
