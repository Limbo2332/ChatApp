﻿using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChatApp.Common.Security
{
    public static class SecurityHelper
    {
        public static string HashPassword(string password, byte[] salt) =>
            Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8)
                );

        public static byte[] GetRandomBytes(int length = 32)
        {
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                var salt = new byte[length];
                randomNumberGenerator.GetBytes(salt);

                return salt;
            }
        }

        public static byte[] GetSeedingBytes(int length = 32)
        {
            Random r = new Random(0);
            var salt = new byte[length];

            for (int i = 0; i < salt.Length; i++)
                salt[i] = (byte)r.Next(1, 256);

            r.NextBytes(salt);   

            return salt;
        }
    }
}
