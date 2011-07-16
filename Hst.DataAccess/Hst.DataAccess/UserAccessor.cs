using System;
using System.Linq;
using Hst.Domain.Entities;

namespace Hst.DataAccess
{
    public class UserAccessor
    {
        public UserAccessor(string connectionString)
        {
            _connectionString = connectionString;

        }
        private readonly string _connectionString;

        public void PersistUser(User u)
        {
            using (var db = new HstDBContainer(_connectionString))
            {
                var user = from users in db.Users
                            where users.Id == u.Id
                            select users;

                if (user.Count() > 0)
                {
                    db.Users.Attach(u);
                    db.Users.ApplyCurrentValues(u);
                    db.SaveChanges();
                }
                else
                {
                    db.Users.AddObject(u);
                    db.SaveChanges();
                }
            }
        }

        public User GetUserByLogin(string login)
        {
            var user = new User();
            using (var db = new HstDBContainer(_connectionString))
            {

                var result = (from u in db.Users
                             where u.Login == login
                             select u).AsEnumerable();


                if (result != null)
                {
                    user = result.First();
                    db.LoadProperty(user, "School");
                    db.Users.Detach(user);
                }
            }

            return user;
        }


        public bool AuthorizeTeacher(User u, Child c)
        {
            using (var db = new HstDBContainer(_connectionString))
            {
                var result = (from child in db.Children
                              where child.Id == c.Id
                              select child).First();

                return result.Users.Contains(u) && u.IsTeacher;
            }
        }

    }
}
