﻿using JWTAuthorization.Models;
using JWTAuthorization.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtServices jwtsvc;
        public LoginController(JwtServices jwtsvc)
        {
            this.jwtsvc = jwtsvc;
        }

        [HttpPost("login")]
        public IActionResult ValidateCred(UserCredentials cred)
        {
            if(cred.UserName == "User" && cred.Password == "abc")
            {
                var token = jwtsvc.GenerateToken(cred.UserName, "User");
                return Ok(token);
            }

            if(cred.UserName == "Admin" && cred.Password == "xyz")
            {
                var token = jwtsvc.GenerateToken(cred.UserName, "Admin");
                return Ok(token);
            }

            return Unauthorized();
        }
    }
}