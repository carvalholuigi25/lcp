using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using BC = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Authorization;
using LCPApi.Functions;
using LCPApi.Context;
using Microsoft.EntityFrameworkCore;

namespace LCPApi.Controllers
{
    [Route("api/auth/login")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DBContext _dbc;
        public AuthController(IConfiguration config, DBContext dbc)
        {
            _config = config;
            _dbc = dbc;
        }

        /// <summary>
        /// Login authentication for LCP Api
        /// </summary>
        /// <param name="userauth"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DoAuth(UserAuth userauth)
        {
            var users = await _dbc.Employees.SingleOrDefaultAsync(x => x.EmployeeName == userauth.UserAuthName);

            if(users == null || !CheckIfPassOrPinIsValid(userauth.UserAuthPassword, users.EmployeePassword)) {
                return Problem($"The authentication of this user {userauth.UserAuthName} is invalid!");
            }

            return Ok(AuthFunctions.GenToken(_config, userauth));
        }

        private bool CheckIfPassOrPinIsValid(string originalPass, string hashedPass) {
            return BC.Verify(originalPass, hashedPass, false, BCrypt.Net.HashType.SHA512);
        }
    }
}
