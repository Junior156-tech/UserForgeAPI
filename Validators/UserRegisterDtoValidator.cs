using FluentValidation;
using UserForgeAPI.DTOs;

namespace UserForgeAPI.Validators
{
    /// Validates user registration data.
    /// This class uses FluentValidation to apply validation rules defined 
    /// for the properties of the <see cref="UserRegisterDto"/> object.
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRegisterDtoValidator"/> class.
        /// This constructor takes an <see cref="IConfiguration"/> instance to access 
        /// application settings, allowing for configurable validation rules.
        /// </summary>
        /// <param name="configuration">The configuration settings used to retrieve validation parameters.</param>
        public UserRegisterDtoValidator(IConfiguration configuration)
        {
            string? emailRegex = configuration["Validation:EmailRegex"];
            string? passwordRegex = configuration["Validation:PasswordRegex"];

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo es obligatorio.")
                .Matches(emailRegex).WithMessage("Formato de correo inválido.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria.")
                .Matches(passwordRegex).WithMessage("La contraseña no cumple con los requisitos.");
        }
    }
}
