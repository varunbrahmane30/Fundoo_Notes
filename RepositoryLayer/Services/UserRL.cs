using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class UserRL : IUserRL
    {
        readonly private UserContext _userContext;

        public UserRL(UserContext userContext)
        {
            this._userContext = userContext;
        }

        public List<User> GetAllUsers()
        { 
                var result = _userContext.Users.ToList();

                return result;     
        }

        public bool RegisterUser(UserModel userModel)
        {
            try
            {
                User user = new User()
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Email = userModel.Email,
                    Password = userModel.Password,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = null
                };

                this._userContext.Users.Add(user);
                int result = _userContext.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception )
            {
                throw;
            }
        }

        public User UserLogIn(LogInModel logInModel)
        {
            try
            {
                User resultData = _userContext.Users.SingleOrDefault(e =>
                            e.Email == logInModel.Email
                            && e.Password == logInModel.Password);

                return resultData;
            }
            catch (Exception )
            {
                throw;
            }
        }

        public User ForgotPassword(ForgotPassWord forgotPassWord)
        {
            try
            {
                User resultData = _userContext.Users.SingleOrDefault(e =>
                           e.Email == forgotPassWord.Email);

                return resultData;           
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User ResetPassword(ResetPassword resetPassWord, long id)
        {
            try
            {
                var result = _userContext.Users.SingleOrDefault(e => e.Id == id);
                
                if (result != null)
                {
                    result.Password = resetPassWord.Password;
                    result.ModifiedAt = DateTime.Now;
                    _userContext.SaveChanges();

                }

                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public User GetUserByEmail(string emailId)
        {
            return _userContext.Users.SingleOrDefault(user => user.Email.Equals(emailId));
        }
    }
}
