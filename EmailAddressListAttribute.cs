using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Threax.AspNetCore.Validators
{
    public class EmailAddressListAttribute : ValidationAttribute
    {
        private EmailAddressAttribute emailAddressAttribute = new EmailAddressAttribute();

        public EmailAddressListAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            var emails = value as IEnumerable<String>;
            if (emails != null)
            {
                foreach (var email in emails)
                {
                    if (!emailAddressAttribute.IsValid(email))
                    {
                        return false;
                    }
                }
                return true;
            }
            throw new InvalidOperationException($"Cannot validate email address list, type was {value.GetType().Name}, must be an IEnumerable<String>.");
        }
    }
}
