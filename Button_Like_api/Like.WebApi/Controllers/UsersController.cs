﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Like.WebApi.Data;
using Like.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Like.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IRepository _repository;
        public UsersController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration, IRepository repository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _repository = repository;
        }
       

        [HttpGet("VerifyUser/{username}")]
        public async Task<ActionResult<bool>> VerifyUser(string username)
        {
            if (await _repository.VerifyUser(username))
            {
                return Ok();
            }

            else
            {
               return BadRequest("Usuário não encontrado");
            }

        }

        [HttpPost("Criar")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
        {
            var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
            var result = await _userManager.CreateAsync(user, "ProjetoLike2021#");
            if (result.Succeeded)
            {
                return BuildToken(model);
            }
            else
            {
                return BadRequest("Usuário ou senha inválidos");
            }
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Username, "ProjetoLike2021#",
                 isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return BuildToken(userInfo);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "login inválido.");
                return BadRequest(ModelState);
            }
        }
        private UserToken BuildToken(UserInfo userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("meuValor", "oque voce quiser"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // tempo de expiração do token: 1 hora
            var expiration = DateTime.Now.AddHours(1);
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);
            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
