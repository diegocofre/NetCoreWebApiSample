using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using WebapiSample.Data.Entities;

namespace WebapiSample.Data
{
    public class NHibernateService : INHibernateService
    {
        private readonly string _connectionString;
        private readonly object _lockObject = new object();
        private ISessionFactory _sessionFactory;

        public NHibernateService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Sqlite");
        }

        private ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    CreateSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private void CreateSessionFactory()
        {
            lock (_lockObject)
            {
                var fluentConfiguration = Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard.ConnectionString(_connectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                    .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                    .BuildConfiguration();

                var exporter = new SchemaExport(fluentConfiguration);
                exporter.Execute(true, true, false);

                _sessionFactory = fluentConfiguration.BuildSessionFactory();
            }
        }
    }
}
