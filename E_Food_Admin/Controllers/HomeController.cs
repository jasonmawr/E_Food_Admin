using BussinessObject.Models;
using E_Food_Admin.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Repository.IRepository;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace E_Food_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ODataController
    {
        IAccountRepository accountRepository;
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            accountRepository = new AccountRepository();
            _configuration = configuration;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Post([FromBody] LoginRequest loginInf)
        {

            Account result = accountRepository.GetByCredentials(loginInf.email, loginInf.password);
            string role;
            string id;
            if (result == null)
            {
                if (loginInf.email.Equals(_configuration.GetValue<string>("AdminAccount:email"))
                    && loginInf.password.Equals(_configuration.GetValue<string>("AdminAccount:password")))
                {
                    role = "admin";
                    var cookieadminOptions = new CookieOptions()
                    {
                        IsEssential = true,
                        Expires = DateTime.Now.AddMinutes(30),
                        Secure = true,
                        HttpOnly = false,
                        SameSite = SameSiteMode.None
                    };
                    Response.Cookies.Append("Auth", role, cookieadminOptions);
                    return Ok(new ResponseObject
                    {
                        Success = true,
                        Message = "login success",
                        role = 2,
                        Data = new UserModel { role = 2 }
                    });
                }
                return Ok(new ResponseObject
                {
                    Success = false,
                    Message = "wrong password or email"
                });
            }
            if (result.Status == 0)
            {
                return Ok(new ResponseObject
                {
                    Success = false,
                    Message = "account is in-active!"
                });
            }
            role = "user";
            id = result.AccountId.ToString();
            var cookieOptions = new CookieOptions()
            {
                IsEssential = true,
                Expires = DateTime.Now.AddMinutes(30),
                Secure = true,
                HttpOnly = false,
                SameSite = SameSiteMode.None
            };
            Response.Cookies.Append("Auth", role, cookieOptions);
            Response.Cookies.Append("id", id, cookieOptions);
            Response.Cookies.Append("name", result.Email, cookieOptions);
            return Ok(new ResponseObject
            {
                Success = true,
                Message = "login success",
                role = 1,
                Data = new UserModel { role = 1, id = result.AccountId, email = result.Email }
            });
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Get()
        {
            Response.Cookies.Delete("Auth");
            return Ok();
        }
    }
}
