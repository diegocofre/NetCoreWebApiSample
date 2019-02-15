using System.Collections.Generic;

namespace WebapiSample.API.Services
{
    public interface IUserService
    {
        bool Delete(int IdValue);
        IList<UserDTO> GetAll(int page, int rows);
        UserDTO GetbyIdValue(int idValue);
        IList<UserDTO> MarkOldest(IList<UserDTO> users);
        UserDTO Update(UserDTO user);
    }
}