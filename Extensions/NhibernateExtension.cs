using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using PruebaTecnicaKaprielian.Models;
using PruebaTecnicaKaprielian.Interfaces;
using PruebaTecnicaKaprielian.Mappings;

namespace PruebaTecnicaKaprielian.Extensions
{
    public static class NhibernateExtension
    {
        public static IServiceCollection AddNhibernate(this IServiceCollection services, string connection)
        {
            var cfg = new AutoMapping();
            var sessionFactory = Fluently.Configure()
             .Database(MySQLConfiguration.Standard.ShowSql().FormatSql().Dialect<MySQLDialect>().ConnectionString(connection))
           .Mappings(m =>
           m.AutoMappings
                   .Add(AutoMap.AssemblyOf<Clientes>(cfg).UseOverridesFromAssemblyOf<ClientesMap>()))
           .ExposeConfiguration(cfg =>
           {
               //new SchemaUpdate(cfg).Execute(true, true);
           })
              .BuildSessionFactory();
            services.AddSingleton(sessionFactory);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<NHibernate.ISession>(factory => factory.GetService<ISessionFactory>().OpenSession());

            return services;
        }
    }

    public class AutoMapping : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == "PruebaTecnicaKaprielian.Models";
        }
    }
}
