namespace FootballTeamSystem.Infrastructure.Mapping
{
    public interface IMapServices
    {
        T Map<T>(object source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}