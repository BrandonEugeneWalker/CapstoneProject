namespace Capstone_Web_Members.Settings
{
    /// <summary>
    ///     Contains settings for Rentals
    /// </summary>
    public class RentalSettings
    {
        #region Data members

        /// <summary>
        ///     The maximum current rentals a Member can have
        /// </summary>
        public static int MaxCurrentRentals = 3;

        /// <summary>
        ///     The standard rental duration until media is considered Past Due
        /// </summary>
        public static int RentalPeriod = 14;

        #endregion
    }
}