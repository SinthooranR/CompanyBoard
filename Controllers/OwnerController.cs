﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayrollManagerAPI.Data;
using PayrollManagerAPI.Methods;
using PayrollManagerAPI.Models.Dto;
using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly Mapping _mapping;

        public OwnerController(DataContext dataContext, UserManager<AppUser> userManager, Mapping mapping)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _mapping = mapping;
        }

        [HttpGet]
        public async Task<IActionResult> getOwners()
        {
            var owners = _dataContext.Owners.ToList();
            return Ok(owners);
        }


        [HttpPost]
        public async Task<IActionResult> registerOwner([FromBody] OwnerCreateDto ownerDto)
        {
            try
            {
                var checkEmailExists = _dataContext.Users.Where(o => o.Email == ownerDto.Email).ToList();

                if (checkEmailExists.Any())
                {
                    ModelState.AddModelError("", "Email already exists, use another one");
                }

                var newOwner = _mapping.OwnerDtotoMain(ownerDto);

                var result = await _userManager.CreateAsync(newOwner, ownerDto.Password);

                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

    }
}
