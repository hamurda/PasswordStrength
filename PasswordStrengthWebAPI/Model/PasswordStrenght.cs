using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordStrengthWebAPI.Model
{
    public enum PasswordStrenght
    {
        // Blank Password (empty and/or space chars only)
        Blank = 0,
        // Either too short (less than 6 chars)
        VeryWeak = 1,
        // At least 6 characters and only one type (UC letters, LC letters, numbers & symbols)
        Weak = 2,
        // At least 6 characters, two conditions met (UC letters, LC letters, numbers & symbols)
        Medium = 3,
        // At least 6 characters, three conditions met (UC letters, LC letters, numbers & symbols)
        Strong = 4,
        // More than 6 characters, all conditions met (UC letters, LC letters, numbers & symbols)
        Unbreakable = 5
    }
}