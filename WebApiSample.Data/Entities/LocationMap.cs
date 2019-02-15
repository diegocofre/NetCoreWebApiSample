using FluentNHibernate.Mapping;

namespace WebapiSample.Data.Entities
{
    public class LocationMap : ClassMap<Location>
    {
        public LocationMap()
        {
            Table("Location");

            Id(x => x.IdValue).GeneratedBy.Foreign("User");
            Map(x => x.State);
            Map(x => x.Street);
            Map(x => x.City);
            Map(x => x.PostCode);
            HasOne(x => x.User).Constrained();
        }
    }
}
