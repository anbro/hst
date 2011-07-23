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
    }
}
