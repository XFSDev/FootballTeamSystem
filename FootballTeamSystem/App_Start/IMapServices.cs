namespace FootballTeamSystem
{
    public interface IMapServices
    {
        T Map<T>(object source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}