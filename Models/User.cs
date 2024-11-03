namespace UserForgeAPI.Models
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the list of phone numbers associated with the user.
        /// </summary>
        public List<Phone> Phones { get; set; } = new();

        /// <summary>
        /// Gets or sets the creation date of the user.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the date of the last modification of the user.
        /// </summary>
        public DateTime Modified { get; set; }

        /// <summary>
        /// Gets or sets the date of the last login of the user.
        /// </summary>
        public DateTime LastLogin { get; set; }

        /// <summary>
        /// Gets or sets the access token of the user.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Indicates whether the user is active.
        /// </summary>
        public bool IsActive { get; set; } = true;
    }


}
