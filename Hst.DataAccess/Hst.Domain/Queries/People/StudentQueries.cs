using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Domain.Queries.People
{
    public static class StudentQueries
    {
        public static IQueryable<Student> GetStudentsByUser(this IQueryable<Student> students, User user)
        {
            return students.Where(s => s.AssociatedUsers.Select(u => u.Id).Contains(user.Id));
        }

        public static IQueryable<Student> GetStudentsByIds(this IQueryable<Student> students, List<int> ids)
        {
            return students.Where(s => ids.Contains(s.Id));
        }

        public static Student GetStudentById(this IQueryable<Student> students, int id)
        {
            return students.Where(s => s.Id == id).FirstOrDefault();
        }
    }
}
