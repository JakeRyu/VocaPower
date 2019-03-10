using System.Collections.Generic;
using System.Text.RegularExpressions;
using VocaPower.Domain.Common;

namespace VocaPower.Domain.Users
{
    public class AppUser
    {
        public long Id { get; set; }
//        public Email Email { get; set; }
        public string Username { get; set; }
    }

    
    public class Email : ValueObject
    {
        public string Value { get;}

        private Email(string value)
        {
            Value = value;
        }

        public static Email Create(string email)
        {
            email = (email ?? string.Empty).Trim();

            if (email.Length == 0)
            {
                // handle error
            }

            if (!Regex.IsMatch(email, @"^(.+)@(.+)$"))
            {
                // handle error
            }
            
            return new Email(email);
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}