using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Domain.Queries.Other
{
    public static class SchoolQueries
    {
        public static string GetSchoolName(this IQueryable<School> schools, User user)
        {
            return schools.Where(s => s.Users.Select(u => u.Id).Contains(user.Id)).FirstOrDefault().SchoolName;
        }

        public static School GetSchoolByUserId(this IQueryable<School> schools, int id)
        {
            return schools.Where(s => s.Users.Select(u => u.Id).Contains(id)).FirstOrDefault();
        }

        
    }
}
