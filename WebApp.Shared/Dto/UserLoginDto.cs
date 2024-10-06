namespace WebApp.Server.Models
{
    public class UserLoginDto
    {
        /// <summary>
        /// The unique username.
        /// </summary>
        public string UserName { get; set; } = string.Empty;
        /// <summary>
        /// The individual's password.
        /// </summary>
        public string PassWord { get; set; } = string.Empty;
    }
}
