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

        public void PersistLesson(Lesson lesson)
        {
            using (var db = new HstDBContainer(_connectionString))
            {
                var lessons = from l in db.Lessons
                              where l.Id == lesson.Id
                              select l;

                if (lessons.Count() > 0)
                {
                    db.Lessons.Attach(lesson);
                    db.Lessons.ApplyCurrentValues(lesson);
                    db.SaveChanges();
                }
                else
                {
                    db.Lessons.AddObject(lesson);
                    foreach (var child in lesson.Children)
                    {
                        db.ObjectStateManager.ChangeObjectState(child, EntityState.Unchanged);
                    }

                    foreach (var subject in lesson.Subjects)
                    {
                        db.ObjectStateManager.ChangeObjectState(subject, EntityState.Unchanged);
                    }

                    foreach (var user in lesson.Users)
                    {
                        db.ObjectStateManager.ChangeObjectState(user, EntityState.Unchanged);
                    }

                    db.DetectChanges();
                    db.SaveChanges();
                }
            }
        }

        public void PersistTest(Test test)
        {
            using (var db = new HstDBContainer(_connectionString))
            {
                var tl = from t in db.Tests
                        where t.Id == test.Id
                        select t;

                if (tl.Count() > 0)
                {
                    db.Tests.Attach(test);
                    db.Tests.ApplyCurrentValues(test);
                    db.SaveChanges();
                }
                else
                {
                    db.Tests.AddObject(test);

                    foreach (var result in test.TestResults)
                    {
                        db.ObjectStateManager.ChangeObjectState(result, EntityState.Unchanged);
                    }

                    foreach (var subject in test.Subjects)
                    {
                        db.ObjectStateManager.ChangeObjectState(subject, EntityState.Unchanged);
                    }

                    foreach (var user in test.Users)
                    {
                        db.ObjectStateManager.ChangeObjectState(user, EntityState.Unchanged);
                    }

                    db.DetectChanges();
                    db.SaveChanges();
                }

            }
        }

        public void PersistTestScore(TestResult result)
        {
            using (var db = new HstDBContainer(_connectionString))
            {
                var testscores = from ts in db.TestResults
                                 where ts.Id == result.Id
                                 select ts;

                if (testscores.Count() > 0)
                {
                    db.TestResults.Attach(result);
                    db.TestResults.ApplyCurrentValues(result);
                    db.SaveChanges();
                }
                else
                {
                    db.TestResults.AddObject(result);
                    foreach (var child in result.Children)
                    {
                        db.ObjectStateManager.ChangeObjectState(child, EntityState.Unchanged);
                    }

                    foreach (var test in result.Tests)
                    {
                        db.ObjectStateManager.ChangeObjectState(test, EntityState.Unchanged);
                    }

                    db.DetectChanges();
                    db.SaveChanges();
                }
            }
        }

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
