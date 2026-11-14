using Blocks.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Submission.Domain.ValueObjects
{
    public class EmailAdress
    {

        public string value { get; private set; }
        private EmailAdress(string _value)
        {
            value = _value;
        }
        public static EmailAdress Create(string _value)
        {
            Guard.ThrowIfNullorWhiteSpace(_value);

            if (!Regex.IsMatch(_value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new ArgumentException("Invalid email address format.");
            }
            return new EmailAdress(_value);
        }
        public static bool IsValidEmail(string _value)
        {
            if (string.IsNullOrWhiteSpace(_value))
            {
                return false;
            }
         
            return Regex.IsMatch(_value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$",RegexOptions.IgnoreCase);
        }
    }
}
