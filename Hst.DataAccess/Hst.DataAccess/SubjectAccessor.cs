using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Entities;

namespace Hst.DataAccess
{
    public class SubjectAccessor
    {
        public SubjectAccessor(string connectionString)
        {
            _connectionString = connectionString;
        }

        private string _connectionString;

        public List<Subject> GetAllSubjects()
        {
            var results = new List<Subject>();

            using (var db = new HstDBContainer(_connectionString))
            {
                var subjects = from s in db.Subjects
                               select s;

                foreach (var subject in subjects)
                {
                    results.Add(subject);
                }
            }

            return results;
        }

        public List<Subject> GetSubjectsByIds(List<int> ids)
        {
            var results = new List<Subject>();

            using (var db = new HstDBContainer(_connectionString))
            {
                var subjects = (from s in db.Subjects
                                where ids.Contains(s.Id)
                                select s).AsEnumerable();

                foreach (var subject in subjects)
                {
                    results.Add(subject);
                }
            }

            return results;
        }

        public void PersistSubject(Subject subject)
        {
            using (var db = new HstDBContainer(_connectionString))
            {
                var subjects = from s in db.Subjects
                               where s.Id == subject.Id
                               select s;

                if (subjects.Count() > 0)
                {
                    db.Subjects.Attach(subject);
                    db.Subjects.ApplyCurrentValues(subject);
                    db.SaveChanges();
                }
                else
                {
                    db.Subjects.AddObject(subject);
                    db.SaveChanges();
                }
            }
        }
    }
}
