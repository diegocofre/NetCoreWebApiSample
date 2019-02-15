using NHibernate;

namespace WebapiSample.Data
{
    public interface INHibernateService
    {
        ISession OpenSession();
    }
}
