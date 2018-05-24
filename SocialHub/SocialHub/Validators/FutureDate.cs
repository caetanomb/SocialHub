using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SocialHub.Validators
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;

            if (!DateTime.TryParseExact(Convert.ToString(value), "dd MMM yyyy",
                CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTime))
            return false;

            return (dateTime > DateTime.Now);
        }
    }
}
