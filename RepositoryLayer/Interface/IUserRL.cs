using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserRL
    {
        List<User> GetAllUsers();
        bool RegisterUser(UserModel userModel);
        User UserLogIn(LogInModel logInModel);
        User ForgotPassword(ForgotPassWord forgotPassWord);
        User ResetPassword(ResetPassword resetPassWord, long id);
        User GetUserByEmail(string emailId);
    }
}
