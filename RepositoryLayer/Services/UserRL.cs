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
        private UserContext _userContext;

        public UserRL(UserContext userContext)
        {
            this._userContext = userContext;
        }

        public List<User> getAllUsers()
        { 
                var result = _userContext.Users.ToList();

                return result;
            
        }

        public bool RegisterUser(UserModel userModel)
        {
            try
            {
                User user = new User();
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.Email = userModel.Email;
                user.Password = userModel.Password;
                user.CreatedAt = DateTime.Now;
                user.ModifiedAt = null;

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
                            e.Email == logInModel.email
                            && e.Password == logInModel.password);

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
    }
}
