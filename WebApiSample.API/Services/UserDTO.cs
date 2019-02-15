using System;

namespace WebapiSample.API.Services
{
    public class UserDTO
    {
        public int IdValue { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Uuid { get; set; }
        public string UserName { get; set; }
        public LocationDTO Location { get; set; }
        public bool Oldest { get; set; }
    }
}
