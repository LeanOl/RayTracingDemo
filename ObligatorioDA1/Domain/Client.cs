using System;
using System.Linq;

namespace Domain
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public override bool Equals(Object obj)
        {
            Client clientToCompare = obj as Client;
            if (clientToCompare == null)
            {
                return false;
            }
            else
            {
                
                return Username == clientToCompare.Username;
            }
        }

        public void Validate()
        {
            ValidateUsername();
            ValidatePassword();
        }

        public void ValidateUsername()
        {
            ValidateUsernameLengthBelowLimit();
            ValidateUsernameLengthAboveLimit();
            ValidateUsernameNotAlphanumeric();
        }
        public void ValidatePassword()
        {
            ValidatePasswordHasCaps();
            ValidatePasswordHasNumber();
            ValidatePasswordLengthBelowLimit();
            ValidatePasswordLengthAboveLimit();
        }

        private void ValidatePasswordLengthBelowLimit()
        {
            const int minLength = 5;
            if (Password.Length < minLength)
            {
                throw new ArgumentException($"Your password has to be at least {minLength} characters long");
            }
        }

        private void ValidatePasswordHasCaps()
        {
            if (Password == Password.ToLower())
            {
                throw new ArgumentException("Your password has to have at least 1 Capital letter");
            }
        }
        private void ValidateUsernameNotAlphanumeric()
        {
            bool isUsernameAlphanumeric = Username.All(Char.IsLetterOrDigit);
            if (!isUsernameAlphanumeric)
            {
                throw new ArgumentException("Username has to be alphanumeric");
            }
        }

        private void ValidateUsernameLengthAboveLimit()
        {
            const int maxLength = 20;
            if (Username.Length > maxLength)
            {
                throw new ArgumentException($"Username has to be at most {maxLength} characters long");
            }
        }
        private void ValidateUsernameLengthBelowLimit()
        {
            const int minLength = 3;
            if (Username.Length < minLength)
            {
                throw new ArgumentException($"Username has to be at least {minLength} characters long");
            }
        }

        private void ValidatePasswordHasNumber()
        {
            bool passwordHasNumber = Password.Any(Char.IsDigit);
            if (!passwordHasNumber)
            {
                throw new ArgumentException("Your password has to have at least 1 number");
            }
        }

        private void ValidatePasswordLengthAboveLimit()
        {
            const int maxLength = 25;
            if (Password.Length > maxLength)
            {
                throw new ArgumentException($"Your password has to be at most {maxLength} characters long");
            }
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }
    }
    
}
