﻿using AutoMapper;
using JewelryStoreAPI.Common;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public UserController(IUserService userService, IMapper mapper, IOptions<JwtSettings> jwtSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<UserModel>> GetAll()
        {
            var users = await _userService.GetAll();

            return _mapper.Map<IList<UserModel>>(users);
        }

        [HttpGet("Role/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<UserModel>> GetAllByRoleId(int id)
        {
            var users = await _userService.GetAllByRoleId(id);

            return _mapper.Map<IList<UserModel>>(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<UserModel> GetById(int id)
        {
            var user = await _userService.GetById(id);

            return _mapper.Map<UserModel>(user);
        }

        [HttpGet("Login/{login}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<UserModel> GetByLogin(string login)
        {
            var user = await _userService.GetByLogin(login);

            return _mapper.Map<UserModel>(user);
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<TokenModel> Authenticate([FromBody] AuthenticateModel authenticate)
        {
            var authenticateDto = _mapper.Map<AuthenticateDto>(authenticate);

            var userDto = await _userService.Authenticate(authenticateDto);

            TokenModel token = new TokenModel()
            {
                Id = userDto.Id,
                Token = GenerateToken(userDto)
            };

            return token;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateUserModel createUser)
        {
            var createUserDto = _mapper.Map<CreateUserDto>(createUser);

            var userDto = await _userService.Create(createUserDto);

            var userModel = _mapper.Map<UserModel>(userDto);

            return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel);
        }

        [Authorize]
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateUserModel updateUser)
        {
            var user = _mapper.Map<UpdateUserDto>(updateUser);

            await _userService.Update(user);

            return NoContent();
        }

        [Authorize]
        [HttpPut("ChangePassword/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordModel changeUserPassword)
        {
            var user = _mapper.Map<ChangeUserPasswordDto>(changeUserPassword);

            await _userService.ChangePassword(user);

            return NoContent();
        }

        [HttpPut("ChangeRole/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangeRole([FromBody] ChangeUserRoleModel changeUserRole)
        {
            var user = _mapper.Map<ChangeUserRoleDto>(changeUserRole);

            await _userService.ChangeRole(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] RemoveUserModel removeUser)
        {
            await _userService.Delete(removeUser.Id);

            return NoContent();
        }

        private string GenerateToken(UserDto user)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.Role, user.RoleName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.Lifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
