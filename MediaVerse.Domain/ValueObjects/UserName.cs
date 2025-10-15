using MediaVerse.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaVerse.Domain.ValueObjects
{
    public class UserName
    {
        public string Value { get; }
        public UserName(string typedName) 
        {
            if (string.IsNullOrEmpty(typedName))
                throw new DomainException("Preencha o nome de usuário");
            
            typedName = typedName.Trim();

            if (typedName.Length < 6)
                throw new DomainException("Nome de usuario deve ter no mínimo 6 caracteres.");

            if (typedName.Length > 20)
                throw new DomainException("Nome de usuário deve ter no máximo 20 caracteres.");
            
            foreach(char characters in typedName)
            {
                if(!char.IsLetterOrDigit(characters) && characters != '_')
                    throw new DomainException ($"Caractere '{characters}' não permitido.");
            }
            Value = typedName;
        }

        public static implicit operator string(UserName username) => username.Value;
        public override string ToString() => Value;
    }
}
