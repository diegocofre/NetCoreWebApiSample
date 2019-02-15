using FluentNHibernate.Mapping;

namespace WebapiSample.Data.Entities
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("User");
            LazyLoad();

            Id(x => x.IdValue).GeneratedBy.Identity();
            Map(x => x.Gender);
            Map(x => x.Name);
            Map(x => x.BirthDate);
            Map(x => x.Uuid);
            Map(x => x.UserName);
            HasOne(x => x.Location).Cascade.All();
        }
    }
}
