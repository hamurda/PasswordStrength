using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace PasswordStrengthWebAPI.Model
{
    public class PasswordCheck
    {
        Regex lowerCase = new Regex(@"[a-z]");
        Regex upperCase = new Regex(@"[A-Z]");
        Regex numbers = new Regex(@"[0-9]");
        Regex symbols = new Regex(@"[^a-zA-Z0-9]");

        public PasswordStrenght CheckStrength(string password)
        {
            // Empty
            if (password.Length < 1) 
            {
                return PasswordStrenght.Blank;
            }

            // TooShort
            if (password.Length < 6) 
            {
                return PasswordStrenght.VeryWeak;
            }

            //Checks lower case letters
            Match matchLower = lowerCase.Match(password);
            bool isThereLower = matchLower.Success;
            //Checks upper case letters
            Match matchUpper = upperCase.Match(password);
            bool isThereUpper = matchUpper.Success;
            //Checks numbers
            Match matchNumbers = numbers.Match(password);
            bool isThereNumbers = matchNumbers.Success;
            //Checks symbols
            Match matchSymbols = symbols.Match(password);
            bool isThereSymbols = matchSymbols.Success;

            PasswordStrenght strength = PasswordStrenght.VeryWeak; // 1, Very Weak

            if (password.Length >= 6)
            {
                strength++; //2, Weak

                //Only lower case and 1 other type
                if ((isThereLower && (isThereUpper || isThereNumbers || isThereSymbols)))
                {
                    strength++; //3, Medium

                    if (isThereUpper && (isThereNumbers || isThereSymbols)) // lower case, upper case and one other type
                    {
                        strength++; //4, Strong
                    }
                    else if (isThereNumbers && isThereSymbols ) // lower case, numbers and symbol
                    {
                        strength++; //4, Strong
                    }
                }
                //Only upper case and 1 other type (no lower case as checked above)
                else if (isThereUpper && (isThereNumbers || isThereSymbols))
                {
                    strength++; //3, Medium

                    if (isThereNumbers && isThereSymbols) // upper case, number, symbol
                    {
                        strength++; //4, Strong
                    }
                }
                //Only numbers and symbols (no lower case or upper case as checked above)
                else if (isThereNumbers &&  isThereSymbols)
                {
                    strength++; //3, Medium                  
                }
            }

            // more than 6 chars and includes lower case, upper case, numbers and symbols
            if (password.Length>6 && isThereLower && isThereUpper && isThereNumbers && isThereSymbols) 
            {
                strength++; //5, Very Strong
            }

            return (PasswordStrenght)strength;
        }
    }
}