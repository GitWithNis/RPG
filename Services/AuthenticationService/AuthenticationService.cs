using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RPG.Data;
using RPG.Dtos;
using RPG.Dtos.Users;
using RPG.Models;

namespace RPG.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        public AuthenticationService(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public async Task<ApiResponse<string>> Login(UserLoginDto request)
        {
            var user = await _dataContext.Users
                .FirstOrDefaultAsync(u => u.Username.Equals(request.Username));
            if (user is null || !VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                return new ApiResponse<string>()
                {
                    Success = false,
                    Message = $"Incorrect credentials."
                };

            return new ApiResponse<string>()
            {
                Data = CreateToken(user)
            };
        }

        public async Task<ApiResponse<int>> Register(UserRegisterDto request)
        {
            if (_dataContext.Users.Any(u => u.Username == request.Username))
                return new ApiResponse<int>()
                {
                    Success = false,
                    Message = "Username taken."
                };

            CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);
            var user = new User()
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return new ApiResponse<int>()
            {
                Data = user.Id
            };
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual(passwordHash);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private string CreateToken(User user){
            List<Claim> claims = new(){
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            SymmetricSecurityKey key = new(System.Text.Encoding.UTF8
            .GetBytes(_configuration["Authentication:IssuerSigningKey"]!));
            
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new(){
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}