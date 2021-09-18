using CommonLayer;
using RepositoryLayer.Entity;
using System.Collections.Generic;


namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        List<User> getAllUsers();
        bool RegisterUser(UserModel userModel);
        User UserLogIn(LogInModel logInModel);
        User ForgotPassword(ForgotPassWord forgotPassWord);
        User ResetPassword(ResetPassword resetPassWord, long id);


    } 
}
