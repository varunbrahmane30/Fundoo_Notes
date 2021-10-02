//-----------------------------------------------------------------------
// <copyright file="UserBL.cs" 
// </copyright>
// <author>Varun Brahmane</author>
//-----------------------------------------------------------------------


namespace BusinessLayer.Services
{
    using BusinessLayer.Interface;
    using CommonLayer;
    using RepositoryLayer.Entity;
    using System;
    using System.Collections.Generic;
   
    public class UserBL : IUserBL
    {
        readonly private IUserRL _userRL;
        public UserBL(IUserRL userRL)
        {
            this._userRL = userRL;
        }
        public List<User> GetAllUsers()
        {
            try
            {
                return this._userRL.GetAllUsers();
            }
            catch(Exception )
            {
                throw;
            }
        }

        public bool RegisterUser(UserModel userModel)
        {
            try
            {
                return this._userRL.RegisterUser(userModel);
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
                return _userRL.UserLogIn(logInModel);
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
                return _userRL.ForgotPassword(forgotPassWord);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User ResetPassword(ResetPassword resetPassword, long id)
        {
            try
            {
                return _userRL.ResetPassword(resetPassword, id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
