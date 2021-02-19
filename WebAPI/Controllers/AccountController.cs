using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtService _jwtTokenService;
        private readonly ApplicationDbContext _dbContext;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IJwtService jwtTokenService,
            ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
            _dbContext = dbContext;
        }

        // POST: api/account/login
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> PostLoginAsync(Login login)
        {
            // Ищем пользователя в системе по адресу эл. почты
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            // Проверяем учётные данные пользователя
            var result = await _signInManager.CheckPasswordSignInAsync(
                user, login.Password, false);
            if (!result.Succeeded)
            {
                throw new Exception("User authentication error.");
            }

            return new User
            { 
                Name = user.Name,
                JwtToken = _jwtTokenService.CreateToken(user),
                UserName = user.UserName
            };
        }

        // GET: api/<AccountController>
        [HttpGet]
        [Route("read")]
        [AllowAnonymous]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/<AccountController>
        [HttpGet]
        [Route("read2")]
        public IEnumerable<string> Get2()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
