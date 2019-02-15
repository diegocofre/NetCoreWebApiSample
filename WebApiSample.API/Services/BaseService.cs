using AutoMapper;
using WebapiSample.Data;

namespace WebapiSample.API.Services
{
    /// <summary>
    /// Base db service, with embedded nHibernateService for easy db access. 
    /// </summary>
    public abstract class BaseService
    {
        protected INHibernateService NHibernate { get; private set; }
        protected IMapper Mapper { get; private set; }

        public BaseService(INHibernateService nHibernate, IMapper mapper)
        {
            NHibernate = nHibernate;
            Mapper = mapper;
        }
    }
}
