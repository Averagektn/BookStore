using AutoMapper;

using BookStoreApi.Model.MappingProfiles;

namespace BookStoreApi.Extensions.Mapper;

public static class AutoMapperConfigExtension
{
    public static void ApplyAutoMapperConfiguration(this IMapperConfigurationExpression config)
    {
        config.AddProfile<BookMappingProfile>();
        config.AddProfile<OrderMappingProfile>();
    }
}
