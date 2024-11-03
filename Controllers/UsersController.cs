using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserForgeAPI.Data;
using UserForgeAPI.DTOs;
using UserForgeAPI.Models;
using UserForgeAPI.Services;
using UserForgeAPI.Validators;

[ApiController]
[Route("api/[controller]")]
/// <summary>
/// Controller for managing users in the application.
/// Provides methods for user registration and management.
/// </summary>
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly TokenService _tokenService;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the UsersController.
    /// </summary>
    /// <param name="context">The database context for accessing data.</param>
    /// <param name="mapper">The service for mapping objects.</param>
    /// <param name="tokenService">The service for handling access tokens.</param>
    /// <param name="configuration">The application configuration.</param>
    public UsersController(ApplicationDbContext context, IMapper mapper, TokenService tokenService, IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _tokenService = tokenService;
        _configuration = configuration;
    
    }
    /// <summary>
    /// Registers a new user in the system.
    /// </summary>
    /// <param name="dto">The object containing the user registration information.</param>
    /// <returns>A UserResponseDto object with the information of the registered user.</returns>
    [HttpPost("register")]
    public async Task<ActionResult<UserResponseDto>> Register(UserRegisterDto dto)
    {
        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            return BadRequest(new { mensaje = "El correo ya registrado" });

        UserRegisterDtoValidator? validator = new UserRegisterDtoValidator(_configuration);
        ValidationResult? result = await validator.ValidateAsync(dto);

        if (!result.IsValid)
            return BadRequest(new { mensaje = result.Errors.Select(e => e.ErrorMessage) });

        User? user = _mapper.Map<User>(dto);
        user.Token = _tokenService.GenerateToken(user);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var userResponse = _mapper.Map<UserResponseDto>(user);

        return CreatedAtAction(nameof(Register), userResponse);
    }

}
