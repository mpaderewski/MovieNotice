using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MovieNotice.Common.ModelsDto
{
    public class RegisterUserDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Username { get; set; }
    }
}
