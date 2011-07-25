using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Domain.Queries.People
{
    public static class UserQueries
    {
        public static User GetUserByLogin(this IQueryable<User> users, string login)
        {
            return users.Where(u => u.Login == login).FirstOrDefault();
        }

        public static IQueryable<User> GetUserByEmail(this IQueryable<User> users, string email)
        {
            return users.Where(u => u.Email == email);
        }

        public static User GetUserById(this IQueryable<User> users, int id)
        {
            return users.Where(u => u.Id == id).FirstOrDefault();
        }

        public static IQueryable<User> GetUsersForSchool(this IQueryable<User> users, int schoolid)
        {
            return users.Where(u => u.School.Id == schoolid);
        }
    }
}
