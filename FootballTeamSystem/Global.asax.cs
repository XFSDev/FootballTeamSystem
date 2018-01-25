namespace FootballTeamSystem
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using FootballTeamSystem.Data;
    using Infrastructure.Mapping;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MsSqlDbContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MsSqlDbContext, Data.Migrations.Configuration>());

            MapperConfig.Execute(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
