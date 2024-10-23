using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace ShopAppApi.Helpers
{
    public interface IStringHelper
    {
        HashSalt EncryptPassword(string password);
        bool VerifyPassword(string enteredPassword, byte[] salt, string storedPassword);

        String RandomString(int length);
    }

    public class StringHelper : IStringHelper
    {
        private static Random random = new Random();

        public HashSalt EncryptPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // Generate a 128-bit salt using a secure PRNG
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string encryptedPassw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));
            return new HashSalt
            {
                Hash = encryptedPassw,
                Salt = salt
            };
        }

        public bool VerifyPassword(string enteredPassword, byte[] salt, string storedPassword)
        {
            string encryptedPassw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));
            return encryptedPassw == storedPassword;
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    public class HashSalt
    {
        public string? Hash { get; set; } = null;

        public byte[]? Salt { get; set; }
    }

    
}
