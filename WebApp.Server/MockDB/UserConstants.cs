using WebApp.Server.Models;

namespace WebApp.Server.MockDB;

/// <summary>
/// Constants related to the User. This is a stand in for a DB table.
/// </summary>
public class UserConstants
{
    public static List<UserModel> Users = new()
    {
        new()
        {
            UserName = "UserOne",
            PassWord = "PasswordOne",
            EmailAddress = "userOne@someDomain.com",
            Role = "Administrator",
            FirstName = "UserOne_FName",
            LastName = "UserOne_LName"
        },
        new()
        {
            UserName = "UserTwo",
            PassWord = "PasswordTwo",
            EmailAddress = "userTwo@someDomain.com",
            Role = "PowerUser",
            FirstName = "UserTwo_FName",
            LastName = "UserTwo_LName"
        },
        new()
        {
            UserName = "UserThree",
            PassWord = "PasswordThree",
            EmailAddress = "userThree@someDomain.com",
            Role = "User",
            FirstName = "UserThree_FName",
            LastName = "UserThre_LName"
        }
    };
}
