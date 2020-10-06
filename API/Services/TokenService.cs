using API.Entities;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    // Exkluzivan, a felhasznalonak a JWT(JSON Web Token-ek) krealasarol felelos service, amit az AccountControllernek passzol
    public class TokenService :  ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config){
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            // legyen ugyanaz a TokenKey nev hasznalva mint az appsettings.json-okba, illetve a Startup-ban
        }

        // Benefits of JWT : 
        // -> no sessions to manage
        // -> portable, a single token can be used in multiple backends
        // -> no cookies required, mobile friendly
        // -> Performance : once a token is issued, there is no need to make a database request to verify a users authentication

        public string CreateToken(User user)
        {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.NameId, user.userName)
            };

            // defines the security key, algorithm and digest for digital signatures
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            // Information used to create a security token 
            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7), // sets the value of the 'expiration' claim
                SigningCredentials = creds // sets the signing credentials used to create a security token
            };

            // Security Token Handler designed for creating and validating Json Web Tokens
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}