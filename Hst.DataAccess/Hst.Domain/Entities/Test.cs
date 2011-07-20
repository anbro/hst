//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Hst.Domain.Entities
{
    [Serializable]
    public partial class Test
    {
        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual string TestName
        {
            get;
            set;
        }
    
        public virtual int Questions
        {
            get;
            set;
        }
    
        public virtual System.DateTime TestDate
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<TestResult> TestResults
        {
            get
            {
                if (_testResults == null)
                {
                    var newCollection = new FixupCollection<TestResult>();
                    newCollection.CollectionChanged += FixupTestResults;
                    _testResults = newCollection;
                }
                return _testResults;
            }
            set
            {
                if (!ReferenceEquals(_testResults, value))
                {
                    var previousValue = _testResults as FixupCollection<TestResult>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupTestResults;
                    }
                    _testResults = value;
                    var newValue = value as FixupCollection<TestResult>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupTestResults;
                    }
                }
            }
        }
        private ICollection<TestResult> _testResults;
    
        public virtual ICollection<User> Users
        {
            get
            {
                if (_users == null)
                {
                    var newCollection = new FixupCollection<User>();
                    newCollection.CollectionChanged += FixupUsers;
                    _users = newCollection;
                }
                return _users;
            }
            set
            {
                if (!ReferenceEquals(_users, value))
                {
                    var previousValue = _users as FixupCollection<User>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupUsers;
                    }
                    _users = value;
                    var newValue = value as FixupCollection<User>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupUsers;
                    }
                }
            }
        }
        private ICollection<User> _users;
    
        public virtual ICollection<Subject> Subjects
        {
            get
            {
                if (_subjects == null)
                {
                    var newCollection = new FixupCollection<Subject>();
                    newCollection.CollectionChanged += FixupSubjects;
                    _subjects = newCollection;
                }
                return _subjects;
            }
            set
            {
                if (!ReferenceEquals(_subjects, value))
                {
                    var previousValue = _subjects as FixupCollection<Subject>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupSubjects;
                    }
                    _subjects = value;
                    var newValue = value as FixupCollection<Subject>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupSubjects;
                    }
                }
            }
        }
        private ICollection<Subject> _subjects;

        #endregion
        #region Association Fixup
    
        private void FixupTestResults(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (TestResult item in e.NewItems)
                {
                    if (!item.Tests.Contains(this))
                    {
                        item.Tests.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (TestResult item in e.OldItems)
                {
                    if (item.Tests.Contains(this))
                    {
                        item.Tests.Remove(this);
                    }
                }
            }
        }
    
        private void FixupUsers(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (User item in e.NewItems)
                {
                    if (!item.Tests.Contains(this))
                    {
                        item.Tests.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (User item in e.OldItems)
                {
                    if (item.Tests.Contains(this))
                    {
                        item.Tests.Remove(this);
                    }
                }
            }
        }
    
        private void FixupSubjects(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Subject item in e.NewItems)
                {
                    if (!item.Tests.Contains(this))
                    {
                        item.Tests.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Subject item in e.OldItems)
                {
                    if (item.Tests.Contains(this))
                    {
                        item.Tests.Remove(this);
                    }
                }
            }
        }

        #endregion
    }
}
