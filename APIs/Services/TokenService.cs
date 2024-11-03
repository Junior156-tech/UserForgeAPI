namespace UserForgeAPI.Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using Microsoft.Extensions.Configuration;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    using UserForgeAPI.Models;

    /// <summary>
    /// Provides functionality for generating JWT tokens for users.
    /// </summary>
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration object containing application settings.</param>
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Generates a JWT token for the specified user.
        /// </summary>
        /// <param name="user">The user for whom the token is to be generated.</param>
        /// <returns>A string representing the generated JWT token.</returns>
        public string GenerateToken(User user)
        {
            IConfigurationSection jwtSettings = _configuration.GetSection("JwtSettings");
            SymmetricSecurityKey? secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            SigningCredentials? signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            List<Claim>? claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("isactive", user.IsActive.ToString())
        };

            JwtSecurityToken? tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signingCredentials
            );

            string? token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }
    }

}
