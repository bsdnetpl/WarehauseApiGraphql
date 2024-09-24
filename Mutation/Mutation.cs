using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WarehauseApiGraphql.Models;
using WarehauseApiGraphql.Sttetings;

namespace WarehauseApiGraphql.Mutation
    {
    public class Mutation
        {

        private readonly IConfiguration _configuration;

        public Mutation(IConfiguration configuration)
            {
            _configuration = configuration;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        public async Task<string> LoginAsync(
            [ScopedService] BsdnetphMatgazynMainContext context,
            string email,
            string haslo)
            {
            // Znajdź użytkownika na podstawie emaila
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                {
                throw new Exception("Nieprawidłowy email lub hasło.");
                }

            // Weryfikacja hasła przy użyciu BCrypt
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(haslo, user.Haslo);
            if (!isPasswordValid)
                {
                throw new Exception("Nieprawidłowy email lub hasło.");
                }

            // Tworzenie tokenu JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
                {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Ranga)  // Dodajemy rolę użytkownika do tokenu
            }),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:ExpireMinutes"])),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);  // Zwracamy token JWT
            }



        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        public async Task<User> AddUserAsync(
       [ScopedService] BsdnetphMatgazynMainContext context,
       string login,
       string haslo,
       string email,
       string imieNazwisko,
       string ranga)
            {
            // Hashowanie hasła za pomocą BCrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(haslo);

            var newUser = new User
                {
                Login = login,
                Haslo = hashedPassword,  // Zapisujemy hashowane hasło
                Data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Email = email,
                ImieNazwisko = imieNazwisko,
                Ranga = ranga
                };

            context.Users.Add(newUser);
            await context.SaveChangesAsync();

            return newUser;
            }
   
        }
    }
