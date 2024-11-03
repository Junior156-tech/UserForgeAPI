namespace UserForgeAPI.Models
{
    /// <summary>
    /// Represents a phone number associated with a user.
    /// </summary>
    public class Phone
    {
        /// <summary>
        /// Gets or sets the unique identifier of the phone.
        /// </summary>
        public int Id { get; set; }

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
