using WebApp.Server.Models;

namespace WebApp.Server.MockDB
{
    public class UserConstants
    {
        public static List<User> Users = new()
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
}
