using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UserInfo
    {
        public UserInfo() { }

        public UserInfo(Guid userId, string fullName, string email, string password, string userName, string phoneNumber, bool isAuthenticated)
        {
            IsAuthenticated = isAuthenticated;
            FullName = fullName;
            Email = email;
            Password = password;
            UserId = userId;
            UserName = userName;
            PhoneNumber = phoneNumber;
        }

        static UserInfo NoAuthenticated(Guid userId, string fullname, string email, string password, string userName, string phoneNumber)
        {
            return new UserInfo(userId, fullname, email, password, userName, phoneNumber, false);
        }

        static UserInfo NoPhoneNumber(Guid userId, string fullname, string email, string password, string userName, bool isAuthenticated)
        {
            return new UserInfo(userId, fullname, email, password, userName, "", isAuthenticated);
        }

        static UserInfo GuestMode(string fullname, string phoneNumber)
        {
            return new UserInfo(Guid.NewGuid(), fullname, null, null, fullname, phoneNumber, false);
        }

        public Guid UserId { get; set; }


        public string FullName { get; set; }

        [Required, EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._-]{3,20}$", ErrorMessage = "Username must be between 3 and 20 characters long and can only contain letters, numbers, dots, and underscores.")]

        public string UserName { get; set; }

        [Required, RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Please use a valid Phone Number. It can include a country code and up to 15 digits.")]
        public string PhoneNumber { get; set; }
        public bool IsAuthenticated { get; set; }

    }
}
