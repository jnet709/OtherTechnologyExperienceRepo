using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SpellChecker.Wpf
{
    class IntegerDataRules : ValidationRule
    {
        public IntegerDataRules() { }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int numericValue = 0;
            try
            {
                if (string.IsNullOrEmpty((string)value) == false)
                {
                    numericValue = Int32.Parse((String)value);
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal characters or " + e.Message);
            }

            return new ValidationResult(true, null);
        }
    }

    class DecimalDataRules : ValidationRule
    {
        public DecimalDataRules() { }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal numericValue = 0;
            try
            {
                if (string.IsNullOrEmpty((string)value) == false)
                {
                    numericValue = Decimal.Parse((String)value);
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal characters or " + e.Message);
            }

            return new ValidationResult(true, null);
        }
    }


    class AlphaNumericDataRules : ValidationRule
    {
        public AlphaNumericDataRules() { }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex r = new Regex(@"\w");
            try
            {
                if (string.IsNullOrEmpty((string)value) == false)
                {
                    if (r.IsMatch((string)value) == false)
                    {
                        return new ValidationResult(false, "Illegal characters entered. Allowed are numbers and alphabets.");
                    }
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal characters or " + e.Message);
            }

            return new ValidationResult(true, null);
        }
    }
}
