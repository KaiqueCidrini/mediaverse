using MediaVerse.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MediaVerse.Domain.ValueObjects
{
    public class Password
    {
        public string Hash { get; }
        
        public Password(string normalPassword) 
        {
            if (string.IsNullOrEmpty(normalPassword))
                throw new DomainException("Digite sua senha.");

            if (normalPassword.Length < 6)
                throw new DomainException("Senha deve possuir no minimo 6 caracteres.");

            Hash = BCrypt.Net.BCrypt.HashPassword(normalPassword);
        }

        public bool Verify(string typedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(typedPassword, Hash);
        }

        public static implicit operator string(Password password) => password.Hash;
        
    }
}
