using System;
using System.Text.RegularExpressions;

namespace Capstone_Desktop.Controller
{
    /// <summary>This class acts as a controller for the AddEmployeeForm. Because of this the class contains methods related to handling data given by the user in its parent form.</summary>
    public class AddEmployeeFormController
    {

        /// <summary>Determines whether [is valid password] [the specified password].</summary>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   <c>true</c> if [is valid password] [the specified password]; otherwise, <c>false</c>.</returns>
        public bool IsValidPassword(string password)
        {
            var lowerCases = 0;
            var upperCases = 0;
            var numbers = 0;
            var specialChars = 0;

            foreach (char currentChar in password)
            {
                if (char.IsNumber(currentChar))
                {
                    numbers++;
                }
                if (char.IsLower(currentChar))
                {
                    lowerCases++;
                }
                if (char.IsUpper(currentChar))
                {
                    upperCases++;
                }
                if (char.IsPunctuation(currentChar) | char.IsSymbol(currentChar))
                {
                    specialChars++;
                }
            }

            var hasLowerCase = lowerCases > 0;
            var hasUpperCase = upperCases > 0;
            var hasNumbers = numbers > 0;
            var hasSpecialChars = specialChars > 0;
            var isMinimumLength = password.Length >= 6;
            var isNotPastMaximumLength = password.Length <= 16;

            var isValid = hasLowerCase && hasUpperCase && hasNumbers && hasSpecialChars && isMinimumLength &&
                          isNotPastMaximumLength;

            return isValid;

        }
    }
}