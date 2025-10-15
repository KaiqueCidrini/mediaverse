using MediaVerse.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaVerse.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; }
        
        public Email(string typedEmail) 
        {
            if (string.IsNullOrEmpty(typedEmail))
                throw new DomainException("Preencha endereço de e-mail");

            typedEmail = typedEmail.Trim();

            if (!typedEmail.Contains("@"))
                throw new DomainException("Digite seu endereço de e-mail corretamente.");

            var parts = typedEmail.Split('@');
            if (parts.Length < 2 || !parts[1].Contains("."))
                throw new DomainException("Digite seu endereço de e-mail corretamente.");
            Value = typedEmail;
        }

        public static implicit operator string(Email email) => email.Value;
        public override string ToString() => Value;
    }
}
