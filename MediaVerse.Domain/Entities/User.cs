using MediaVerse.Domain.ValueObjects.User;

namespace MediaVerse.Domain.Entities
{
    public class User : BaseEntity
    {
        public UserName UserName { get; private set; }
        public Email Email { get; private set; }
        public Password HashPassword { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string AvatarUrl { get; private set; }
        public string Bio { get; private set; }
        public DateTime LastLogin { get; private set; }
        public bool IsEmailVerified { get; private set; } 

        public User(UserName userName, Email email, Password password) 
        {
            UserName = userName;
            Email = email;
            HashPassword = password;

            CreationDate = DateTime.UtcNow;
            LastLogin = DateTime.UtcNow;
            AvatarUrl = "";
            Bio = "";
            IsEmailVerified = false;
        }

        //Construtor para Dapper
        private User() { }
    }
}
