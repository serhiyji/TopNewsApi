using Azure.Core;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TopNewsApi.Core.DTOs.User;
using TopNewsApi.Core.Services;
using TopNewsApi.Core.Validation.User;

namespace TopNewsApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok((await _userService.GetAllAsync()).Payload);
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDto model)
        {
            CreateUserValidation validaor = new CreateUserValidation();
            var validationResult = await validaor.ValidateAsync(model);
            if (validationResult.IsValid)
            {
                ServiceResponse response = await _userService.CreateUserAsync(model);
                if (response.Success)
                {
                    return Ok(response.Message);
                }
                return Ok(response.Errors.FirstOrDefault());
            }
            return Ok(validationResult.Errors.FirstOrDefault());
        }
        [HttpPost("UpdateMainInfoUser")]
        public async Task<IActionResult> UpdateMainInfoUser(UpdateUserDto model)
        {
            var validationResult = await new UpdateUserValidation().ValidateAsync(model);
            if (validationResult.IsValid)
            {
                ServiceResponse result = await _userService.ChangeMainInfoUserAsync(model);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return Ok(result.Errors.FirstOrDefault());
            }
            return Ok(validationResult.Errors.FirstOrDefault());
        }
        [HttpPost("UpdatePasswordInfoUser")]
        public async Task<IActionResult> UpdatePasswordInfoUser(UpdatePasswordDto model)
        {
            var validationResult = await new UpdatePasswordValidation().ValidateAsync(model);
            if (validationResult.IsValid)
            {
                ServiceResponse result = await _userService.ChangePasswordAsync(model);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return Ok(result.Errors.FirstOrDefault());
            }
            return Ok(validationResult.Errors.FirstOrDefault());
        }
        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(DeleteUserDto model)
        {
            ServiceResponse result = await _userService.DeleteUserAsync(model);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return Ok(result.Errors.FirstOrDefault());
        }
        [HttpPost("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userid, string token)
        {
            ServiceResponse result = await _userService.ConfirmEmailAsync(userid, token);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return Ok(result.Errors.FirstOrDefault());
        }
    }
}
