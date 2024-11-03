using AutoMapper;
using UserForgeAPI.DTOs;
using UserForgeAPI.Models;

/// <summary>
/// Defines the mapping configuration between data transfer objects (DTOs) and domain models.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingProfile"/> class.
    /// </summary>
    public MappingProfile()
    {
        // Mapping configuration for user registration
        CreateMap<UserRegisterDto, User>()
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Modified, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.LastLogin, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));


        // Mapping configuration for user registration response
        CreateMap<User, UserResponseDto>();


        // Mapping configuration for phone information
        CreateMap<PhoneDto, Phone>();
    }
}

