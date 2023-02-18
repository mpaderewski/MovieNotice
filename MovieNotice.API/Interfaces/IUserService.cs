using MovieNotice.Common.ModelsDto;

namespace MovieNotice.API.Interfaces
{
    public interface IUserService
    {
        public UserDto? GetUser(int id);
    }
}
