using MovieNotice.Common.ModelsDto;

namespace MovieNotice.API.Interfaces
{
    public interface IAccountService
    {
        public string? GenerateJwt(LoginDto dto);
        public void RegisterUserAsync(RegisterUserDto dto);
    }
}
