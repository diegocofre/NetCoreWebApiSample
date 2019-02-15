using System;

namespace WebapiSample.Data.Entities
{
    public class User
    {
        public virtual int IdValue { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string Uuid { get; set; }
        public virtual string UserName { get; set; }
        public virtual Location Location { get; set; }
    }
}
