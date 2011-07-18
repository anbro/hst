using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Entities;

namespace Hst.DataAccess
{
    public class ChildAccessor
    {
        public ChildAccessor(string connectionString)
        {
            _connectionString = connectionString;
        }

        private string _connectionString;

        public void PersistChild(Child child)
        {
            using (var db = new HstDBContainer(_connectionString))
            {
                var children = from c in db.Children
                            where c.Id == child.Id
                            select c;

                if (children.Count() > 0)
                {
                    db.Children.Attach(child);
                    db.Children.ApplyCurrentValues(child);
                    db.SaveChanges();
                }
                else
                {
                    db.Children.AddObject(child);
                    db.SaveChanges();
                }
            }
        }

        public List<Child> GetChildrenByUser(User user)
        {
            var result = new List<Child>();

            using (var db = new HstDBContainer(_connectionString))
            {
                var children = (from c in db.Children
                               where c.Users.Any(a => a.Login == user.Login)
                               select c).AsEnumerable();

                foreach (var child in children)
                {
                    result.Add(child);
                }
            }

            return result;
        }

        public List<Child> GetChildrenByIds(List<int> ids)
        {
            var result = new List<Child>();

            using (var db = new HstDBContainer(_connectionString))
            {
                var children = (from c in db.Children
                                where ids.Contains(c.Id)
                                select c).AsEnumerable();

                foreach (var child in children)
                {
                    result.Add(child);
                }
            }

            return result;
        }


    }
}
