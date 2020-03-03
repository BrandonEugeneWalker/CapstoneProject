namespace Capstone_Desktop.Controller
{
    /// <summary>
    ///     This class acts as a controller for the AddEmployeeForm. Because of this the class contains methods related to
    ///     handling data given by the user in its parent form.
    /// </summary>
    public class AddEmployeeFormController
    {
        #region Methods

        /// <summary>
        ///   <para>Determines whether [is valid password] [the specified password]. </para>
        ///   <para>Password requirements are as follows:</para>
        ///   <para>* Contains at least one lowercase letter.</para>
        ///   <para>* Contains at least one uppercase letter.</para>
        ///   <para>* Contains at least one symbol.</para>
        ///   <para>* Must be a minimum of 6 characters long.</para>
        ///   <para>* Cannot be longer than 16 characters.</para>
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <returns>
        ///   <c>true</c> if [is valid password] [the specified password]; otherwise, <c>false</c>.</returns>
        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
            var lowerCases = 0;
            var upperCases = 0;
            var numbers = 0;
            var specialChars = 0;

            foreach (var currentChar in password)
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

        #endregion
    }
}