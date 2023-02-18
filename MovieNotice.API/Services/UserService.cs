using AutoMapper;
using MovieNotice.API.Entities;
using MovieNotice.API.Interfaces;
using MovieNotice.Common.ModelsDto;

namespace MovieNotice.API.Services
{
    public class UserService : IUserService
    {
        private readonly MovieNoticeDbContext _context;
        private readonly IMapper _mapper;

        public UserService(MovieNoticeDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public UserDto? GetUser(int id)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<UserDto>(user);
        }
    }
}
