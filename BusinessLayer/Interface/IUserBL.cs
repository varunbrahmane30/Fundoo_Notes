//-----------------------------------------------------------------------
// <copyright file="IUser.cs" 
// </copyright>
// <author>Varun Brahmane</author>
//-----------------------------------------------------------------------
namespace BusinessLayer.Interface
{
    using System.Collections.Generic;
    using CommonLayer;
    using RepositoryLayer.Entity;
    
    public interface IUserBL
    {
        List<User> GetAllUsers();
        bool RegisterUser(UserModel userModel);
        User UserLogIn(LogInModel logInModel);
        User ForgotPassword(ForgotPassWord forgotPassWord);
        User ResetPassword(ResetPassword resetPassWord, long id);


    } 
}
