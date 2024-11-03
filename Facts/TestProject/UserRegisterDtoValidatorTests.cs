using FluentValidation.TestHelper;
using Microsoft.Extensions.Configuration;
using UserForgeAPI.DTOs;
using UserForgeAPI.Validators;
using Xunit;

public class UserRegisterDtoValidatorTests
{
    private readonly UserRegisterDtoValidator _validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRegisterDtoValidatorTests"/> class.
    /// This constructor sets up an in-memory configuration for validation rules.
    /// </summary>
    public UserRegisterDtoValidatorTests()
    {
        Dictionary<string, string> inMemorySettings = new Dictionary<string, string>
        {
            { "Validation:EmailRegex", "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$" },
            { "Validation:PasswordRegex", "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$" }
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        _validator = new UserRegisterDtoValidator(configuration);
    }

    /// <summary>
    /// Tests that an invalid email address produces a validation error.
    /// </summary>
    [Fact]
    public void Email_ShouldHaveError_WhenInvalidEmail()
    {
        UserRegisterDto userRegisterDto = new UserRegisterDto { Email = "invalid-email", Password = "Password123" };
        TestValidationResult<UserRegisterDto> result = _validator.TestValidate(userRegisterDto);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    /// <summary>
    /// Tests that a short password produces a validation error.
    /// </summary>
    [Fact]
    public void Password_ShouldHaveError_WhenInvalidPassword()
    {
        UserRegisterDto userRegisterDto = new UserRegisterDto { Email = "test@example.com", Password = "short" };
        TestValidationResult<UserRegisterDto> result = _validator.TestValidate(userRegisterDto);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    /// <summary>
    /// Tests that a valid email address does not produce a validation error.
    /// </summary>
    [Fact]
    public void Email_ShouldNotHaveError_WhenValidEmail()
    {
        UserRegisterDto userRegisterDto = new UserRegisterDto { Email = "test@example.com", Password = "Password123" };
        TestValidationResult<UserRegisterDto> result = _validator.TestValidate(userRegisterDto);
        result.ShouldNotHaveValidationErrorFor(x => x.Email);
    }

    /// <summary>
    /// Tests that a valid password does not produce a validation error.
    /// </summary>
    [Fact]
    public void Password_ShouldNotHaveError_WhenValidPassword()
    {
        UserRegisterDto userRegisterDto = new UserRegisterDto { Email = "test@example.com", Password = "Password123" };
        TestValidationResult<UserRegisterDto> result = _validator.TestValidate(userRegisterDto);
        result.ShouldNotHaveValidationErrorFor(x => x.Password);
    }
}