using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Hst.Domain.Entities;

namespace Hst.DataAccess
{
    public class SchoolAccessor
    {
        public SchoolAccessor(string connectionString)
        {
            _connectionString = connectionString;
        }

        private string _connectionString;

        public string GetSchoolName(User u)
        {
            using (var db = new HstDBContainer(_connectionString))
            {
                var result = from s in db.Schools
                             where s.Users.Contains(u)
                             select s;

                if (result.Count() > 0)
                {
                    return result.First().SchoolName;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public void CreateSchool(School s)
        {
            using (var db = new HstDBContainer(_connectionString))
            {
                db.Schools.AddObject(s);
                db.SaveChanges();
            }
        }

    }
}
