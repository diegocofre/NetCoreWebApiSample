namespace WebapiSample.Data.Entities
{
    public class Location
    {
        public virtual int IdValue { get; set; }
        public virtual string State { get; set; }
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string PostCode { get; set; }
        public virtual User User { get; set; }
    }
}
