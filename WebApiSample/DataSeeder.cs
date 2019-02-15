using Microsoft.Extensions.DependencyInjection;
using NHibernate.Linq;
using System;
using System.Linq;
using WebapiSample.API.Helpers;
using WebapiSample.API.Services;
using WebapiSample.Data;
using WebapiSample.Data.Entities;

namespace WebapiSample
{
    public class DataSeeder
    {
        /// <summary>
        /// Responsible of seeding the database
        /// </summary>
        /// <param name="serviceProvider"></param>
        public void Initialize(IServiceProvider serviceProvider)
        {
            INHibernateService nHibernateHelper = serviceProvider.GetRequiredService<INHibernateService>();

            using (var session = nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Query<User>().Delete();

                        if (!session.Query<bool>().Any())
                        {

                            var response = HttpClientHelper.GetFromEndpoint<RandomUserDTO>("https://randomuser.me/api/?results=500");

                            foreach (var rndusr in response.results)
                            {
                                var usr = new User { Name = string.Format("{0} {1}", rndusr.name.first, rndusr.name.last), Gender = rndusr.gender, Email = rndusr.email, BirthDate = rndusr.dob.date, UserName = rndusr.login.username, Uuid = rndusr.login.uuid };
                                usr.Location = new Location() { City = rndusr.location.city, PostCode = rndusr.location.postcode, State = rndusr.location.state, Street = rndusr.location.street, User = usr };
                                session.Save(usr);
                            }

                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


    }
}
