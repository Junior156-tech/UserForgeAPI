using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace UserForgeAPI.DTOs
{
    /// <summary>
    /// Data Transfer Object for user registration.
    /// </summary>
    public class UserRegisterDto
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>

        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the list of phone numbers associated with the user.
        /// </summary>
        public List<PhoneDto> Phones { get; set; } = new();
    }


}
