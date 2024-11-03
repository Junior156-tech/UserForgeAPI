namespace UserForgeAPI.Models
{
    /// <summary>
    /// Represents the data transfer object for user responses.
    /// This class is used to encapsulate the information that will be returned
    /// to the client upon successful user registration or when querying user details.
    /// </summary>
    public class UserResponseDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// This is typically a GUID generated for each user upon registration.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was created.
        /// This value is set when the user account is initially registered.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user information was last modified.
        /// This value is updated whenever the user's details are changed.
        /// </summary>
        public DateTime Modified { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the user's last login.
        /// This is updated every time the user successfully logs into the system.
        /// </summary>
        public DateTime LastLogin { get; set; }

        /// <summary>
        /// Gets or sets the access token for the user.
        /// This token is used for authenticating API requests on behalf of the user.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is currently active.
        /// This status determines if the user account is enabled or disabled within the system.
        /// </summary>
        public bool IsActive { get; set; }

    }
}
