using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieNotice.API.Entities;
using MovieNotice.API.Interfaces;
using MovieNotice.API.Settings;
using MovieNotice.Common.ModelsDto;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace MovieNotice.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly MovieNoticeDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenitactionSettings _authenitactionSettings;

        public AccountService(MovieNoticeDbContext context, IPasswordHasher<User> passwordHasher, AuthenitactionSettings authenitactionSettings)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenitactionSettings = authenitactionSettings;
        }

        public string? GenerateJwt(LoginDto dto)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == dto.Email);

            if (user == null) 
            {
                return null;
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if(result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.DisplayName.ToString()),
                new Claim(ClaimTypes.Email, user.Email.ToString())
            };

        
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenitactionSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenitactionSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenitactionSettings.JwtIssuer, _authenitactionSettings.JwtIssuer, claims, expires: expires, signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();


            return tokenHandler.WriteToken(token);

        }

        public void RegisterUserAsync(RegisterUserDto dto)
        {
            var user = new User()
            {
                Email = dto.Email,
                DisplayName = dto.Username
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
