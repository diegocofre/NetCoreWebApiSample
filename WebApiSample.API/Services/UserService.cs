using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebapiSample.Data;
using WebapiSample.Data.Entities;

namespace WebapiSample.API.Services
{
    public class UserService : BaseService, IUserService
    {
        const int MAX_ROWS = 50;

        public UserService(INHibernateService nHibernateHelper, IMapper mapper) : base(nHibernateHelper, mapper)
        { }

        /// <summary>
        /// Gets a paginated list of users
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public IList<UserDTO> GetAll(int page, int rows)
        {
            if (rows > MAX_ROWS)
            {
                throw new ArgumentException(string.Format("Max size for page is {0} rows", MAX_ROWS));
            }

            if (page < 0)
            {
                page = 0;
            }

            if (rows < 1)
            {
                rows = 1;
            }

            IList<User> users = null;

            using (var session = NHibernate.OpenSession())
            {
                users = session.Query<User>()
                     .OrderBy(u => u.Name)
                     .Skip(page * rows)
                     .Take(rows)
                     .ToList();
            }

            return MarkOldest(Mapper.Map<List<UserDTO>>(users));
        }

        public UserDTO GetbyIdValue(int idValue)
        {
            User user = null;

            using (var session = NHibernate.OpenSession())
            {
                user = session.Query<User>()
                    .Where(u => u.IdValue == idValue)
                    .SingleOrDefault();
            }

            return Mapper.Map<UserDTO>(user);
        }

        public UserDTO Update(UserDTO user)
        {
            User entity = null;

            using (var session = NHibernate.OpenSession())
            {
                entity = session.Query<User>()
                    .Where(u => u.IdValue == user.IdValue)
                    .SingleOrDefault();

                if (entity != null)
                {
                    Mapper.Map(user, entity);
                    session.Update(entity);
                    session.Flush();
                }
            }

            return Mapper.Map<UserDTO>(entity);
        }

        public bool Delete(int IdValue)
        {
            bool retVal;
            User entity = null;

            using (var session = NHibernate.OpenSession())
            {
                entity = session.Query<User>()
                    .Where(u => u.IdValue == IdValue)
                    .SingleOrDefault();

                if (entity != null)
                {
                    session.Delete(entity);
                    session.Flush();
                    retVal = true;
                }
                else
                {
                    retVal = false;
                }
            }

            return retVal;
        }

        /// <summary>
        /// Marks the oldest user of a list with the flag Oldest=true
        /// </summary>
        /// <param name="users"></param>
        public IList<UserDTO> MarkOldest(IList<UserDTO> users)
        {
            UserDTO oldest = users[0];
            oldest.Oldest = true;
            for (int i = 1; i < users.Count; i++)
            {
                UserDTO usr = users[i];
                if (usr.BirthDate < oldest.BirthDate)
                {
                    oldest.Oldest = false;
                    usr.Oldest = true;
                    oldest = usr;
                }
            }
            return users;
        }

    }
}
