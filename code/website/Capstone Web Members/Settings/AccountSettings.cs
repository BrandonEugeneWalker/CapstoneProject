﻿namespace Capstone_Web_Members.Settings
{
    public class AccountSettings
    {
        /// <summary>
        /// The password requires length of
        /// </summary>
        public static int PasswordRequiredLength = 6;

        /// <summary>
        /// The password requires non letter or digit
        /// </summary>
        public static bool PasswordRequireNonLetterOrDigit = true;

        /// <summary>
        /// The password requires digit
        /// </summary>
        public static bool PasswordRequireDigit = true;

        /// <summary>
        /// The password requires lowercase
        /// </summary>
        public static bool PasswordRequireLowercase = true;

        /// <summary>
        /// The password requires uppercase
        /// </summary>
        public static bool PasswordRequireUppercase = true;
    }
}