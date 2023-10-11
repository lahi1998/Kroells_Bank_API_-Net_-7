using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Kroells_Bank_API2.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Kroells_Bank_API.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace Kroells_Bank_API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KroellsBankContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<HomeController> logger, KroellsBankContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }


        [HttpGet("Encryptpass")]
        public ActionResult Encryptpass([FromQuery] UserDTO request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            return Ok(new { passwordHash });
        }


        [HttpPost("login")]
        public async Task<ActionResult<LoginReturn>> Login(UserDTO request)
        {
            try
            {
                if (request.Username != null)
                {
                    // Retrieve user data from the database based on the provided username.
                    _logger.LogInformation("Login POST request received.");
                    var returnlist = await _context.LoginReturn
                        .FromSqlRaw("EXEC GetUsername @Username",
                            new SqlParameter("@Username", request.Username))
                        .ToListAsync();
                    var loginreturn = returnlist.FirstOrDefault();

                    if (loginreturn == null)
                    {
                        throw new InvalidLoginException("Username or password is incorrect.");
                    }

                    // Verify the password hash.
                    if (!BCrypt.Net.BCrypt.Verify(request.Password, loginreturn.PasswordHashed))
                    {
                        throw new InvalidLoginException("Username or password is incorrect.");
                    }

                    int Account_Id = loginreturn.Account_Id;
                    int Client_Id = loginreturn.Client_Id;

                    // call a method that creates a token.
                    string jwtToken = CreateToken(loginreturn);
                    return Ok(new { jwtToken, Account_Id, Client_Id });
                }
                else
                {
                    _logger.LogInformation("Login GET request received.");
                    string denied = "password or username is incorrect";
                    return BadRequest(new { denied });
                }
            }
            catch (InvalidLoginException ex)
            {
                // Handle the custom exception and return a 400 (Bad Request) response with the error message.
                _logger.LogError(ex, "Login failed.");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions here, log them, and return 404 as response
                _logger.LogError(ex, "An error occurred during login.");
                return StatusCode(404, "An error occurred during login."); // 404 (Not Found)
            }
        }

        private string CreateToken(LoginReturn loginreturn)
        {

            List<Claim> Claims = new List<Claim> { new Claim(ClaimTypes.Name, loginreturn.Username) };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:SecretKey").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                    claims: Claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);


            return jwt;
        }
    }
}
