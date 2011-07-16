using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Entities;

namespace Hst.DataAccess
{
    public class StudentAccessor
    {
        public StudentAccessor(string connectionString)
        {
            _connectionString = connectionString;
        }

        private string _connectionString;

        public void PersistStudent(Child student)
        {
            using (var db = new HstDBContainer(_connectionString))
            {
                var students = from c in db.Children
                                 where c.Id == student.Id
                                 select c;

                if (students.Count() > 0)
                {
                    db.Children.Attach(student);
                    db.Children.ApplyCurrentValues(student);
                    db.DetectChanges();
                    db.SaveChanges();
                }
                else
                {
                    db.Children.AddObject(student);
                    db.SaveChanges();
                }
            }
        }
    }
}
