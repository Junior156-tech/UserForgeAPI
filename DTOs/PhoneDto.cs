namespace UserForgeAPI.DTOs
{
    /// <summary>
    /// Data Transfer Object for phone information.
    /// </summary>
    public class PhoneDto
    {
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the city code of the phone number.
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// Gets or sets the country code of the phone number.
        /// </summary>
        public string CountryCode { get; set; }
    }
}
