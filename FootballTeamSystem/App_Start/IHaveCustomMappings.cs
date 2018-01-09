using AutoMapper;

namespace FootballTeamSystem
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}