using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AuthorizeModule.Models;
using AuthorizeModule.Repository;

namespace AuthorizeModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(TokenController));

        private readonly IAuthRepo _authRepo;

        public TokenController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost]
        public IActionResult GenerateJSONWebToken([FromBody] Models.User user)
        {
            //_log4net.Info(" Http GET Request From: " + nameof(TokenController));
            // string token = _authProvider.GetJsonWebToken();
            if (user.EmployeeId == null && user.Password == "") return BadRequest("EmployeeId or password is not provided");

            var userCheck = _authRepo.Users().Where(m => m.EmployeeId == user.EmployeeId && m.Password == user.Password).FirstOrDefault();

            if (userCheck != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Role, "Member"),
                new Claim("EmployeeId", user.EmployeeId.ToString()),
                new Claim("Password", user.Password.ToString())
                };

                var token = new JwtSecurityToken(
                    issuer: "mySystem",
                    audience: "myUsers",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: credentials);

                var returnData = new JwtSecurityTokenHandler().WriteToken(token);



                if (token == null)
                {
                    return BadRequest(returnData);
                }
                else
                {
                    return Ok(new { data = returnData });
                }
            }
            else
            {
                return NotFound(new { status = StatusCodes.Status404NotFound, message = "Employee Not found" });
            }

        }

        [HttpGet]
        public List<User> users()
        {
            List<User> userObj = new List<User>();
            userObj.Add(new User { EmployeeId = 101, Password = "123456" });
            userObj.Add(new User { EmployeeId = 102, Password = "123456" });
            userObj.Add(new User { EmployeeId = 103, Password = "123456" });
            userObj.Add(new User { EmployeeId = 104, Password = "123456" });
            return userObj;
        }

    }
}
