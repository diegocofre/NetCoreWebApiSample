using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WebapiSample.API.Services;

namespace WebApiSample.Test
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void CanGetUsers()
        {
            var svc = new UserService(null, null);
            var list = BuildMockList();
            var minbirth = list.Min(u => u.BirthDate);

            var result = svc.MarkOldest(list);

            var oldest = result.Where(u => u.Oldest).ToList();

            Assert.IsTrue(oldest.Any() || oldest.Single().BirthDate == minbirth);
        }

        public IList<UserDTO> BuildMockList()
        {
            int id = 0;
            var retList = new List<UserDTO>();
            retList.Add(new UserDTO() { IdValue = id++, BirthDate = new System.DateTime(1975, 2, 1) });
            retList.Add(new UserDTO() { IdValue = id++, BirthDate = new System.DateTime(1913, 2, 1) });
            retList.Add(new UserDTO() { IdValue = id++, BirthDate = new System.DateTime(2008, 2, 1) });
            retList.Add(new UserDTO() { IdValue = id++, BirthDate = new System.DateTime(1955, 2, 1) });
            retList.Add(new UserDTO() { IdValue = id++, BirthDate = new System.DateTime(2008, 4, 1) });
            retList.Add(new UserDTO() { IdValue = id++, BirthDate = new System.DateTime(1786, 2, 1) });
            return retList;
        }
    }
}
