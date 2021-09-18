using BusinessLayer.Interface;
using CommonLayer;
using CommonLayer.MSMQ;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using RepositoryLayer.Entity;

namespace FundooNotes.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly private IUserBL _userBL;
        readonly private IConfiguration _config;

        public object MsmqOperation { get; private set; }

        public UserController(IUserBL userBL, IConfiguration config)
        {
            this._userBL = userBL;
            this._config = config;
        }

        private long getTokenID()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllUsers()
        {
            var useList = this._userBL.getAllUsers();
            return this.Ok(new { Success = true, message = "Get User Data SuccessFully.", Data = useList });
        }


        [HttpPost]
        public IActionResult RegisterUser(UserModel userModel)
        {
            try
            {
                bool result = this._userBL.RegisterUser(userModel);

                if(result==true)
                {
                    return this.Ok(new { Success = true, message = "Registered User SuccessFully." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "User registration failed." });
                }
            }
            catch(Exception e)
            {
                return this.BadRequest(new
                {
                    success = false,
                    message= e.Message,
                    stackTrace=e.StackTrace
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult UserLogin([FromBody] LogInModel logInModel)
        {
            try
            {
                IActionResult response = Unauthorized();
                User user = _userBL.UserLogIn(logInModel);
                //bool result = true;
                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(user.Id, user.Email);
                    var userData = new { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, CreatedAt = user.CreatedAt, ModifiedAt = user.ModifiedAt};

                   response = Ok(new { Success = true, Message = "Log In Successful!!", token = tokenString, Data = userData });
                }

                return response;
               
            }
            catch (Exception e)
            {
                return this.BadRequest(new 
                { 
                    Success = false,
                    Message = e.Message,
                    stackTrace = e.StackTrace
                });
            }
        }

        [HttpPost("forgotPassword")]
        [AllowAnonymous]
        public IActionResult ForgotPassword(ForgotPassWord forgotPassword)
        {
            try
            {
                User user = _userBL.ForgotPassword(forgotPassword);

                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(user.Id, user.Email);

                    new MsmqOperation().sendingData(tokenString);
                    return this.Ok(new { Success = true, Message = "Reset password link have send to you via Email" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Email doesn't match" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new
                {
                    Success = false,
                    Message = e.Message,
                    stackTrace = e.StackTrace
                });          
            }
        }

        [HttpPut("resetPassword")]
        [AllowAnonymous]
        public IActionResult ResetPassword(ResetPassword resetPasswordModel)
        {
            try
            {
                if (resetPasswordModel.Password == resetPasswordModel.ConfirmPassword)
                {
                    long UserId = getTokenID();
                    User user = _userBL.ResetPassword(resetPasswordModel, UserId);

                    if (user != null)
                    {
                        return this.Ok(new { Success = true, message = "Password Changed Successfully." });
                    }
                    else

                    {
                        return this.BadRequest(new { Success = false, message = "Something went wrong." });
                    }
             
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Password should be same." });

                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new
                {
                    Success = false,
                    Message = e.Message,
                    stackTrace = e.StackTrace
                });
            }
        }

        private string GenerateJSONWebToken(long Id, String email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Claims = new[]
            {
                new Claim("Id",Id.ToString()),
                new Claim(ClaimTypes.Email,email)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              Claims, 
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


}
