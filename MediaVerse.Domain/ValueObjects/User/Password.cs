using MediaVerse.Domain.Exceptions;

namespace MediaVerse.Domain.ValueObjects.User
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
