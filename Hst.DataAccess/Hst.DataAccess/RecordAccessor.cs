using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Hst.Domain.Entities;

namespace Hst.DataAccess
{
    public class RecordAccessor
    {
        public RecordAccessor(string connectionString)
        {
            _connectionString = connectionString;
        }

        private string _connectionString;

        public void PersistActivity(Activity activity)
        {
            using (var db = new HstDBContainer(_connectionString))
            {
                var activities = from a in db.Activities
                               where a.Id == activity.Id
                               select a;

                if (activities.Count() > 0)
                {
                    db.Activities.Attach(activity);
                    db.Activities.ApplyCurrentValues(activity);
                    db.SaveChanges();
                }
                else
                {
                    
                    db.Activities.AddObject(activity);
                    foreach (var child in activity.Children)
                    {
                        db.ObjectStateManager.ChangeObjectState(child, EntityState.Unchanged);
                    }

                    foreach (var subject in activity.Subjects)
                    {
                        db.ObjectStateManager.ChangeObjectState(subject, EntityState.Unchanged);
                    }

                    foreach (var user in activity.Users)
                    {
                        db.ObjectStateManager.ChangeObjectState(user, EntityState.Unchanged);
                    }

                    db.DetectChanges();
                    db.SaveChanges();
                }
            }
        }
    }
}
