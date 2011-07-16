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
    public partial class Activity
    {
        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual string ActivityName
        {
            get;
            set;
        }
    
        public virtual System.DateTime ActivityDate
        {
            get;
            set;
        }
    
        public virtual string Notes
        {
            get;
            set;
        }
    
        public virtual string TimeSpent
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<Child> Children
        {
            get
            {
                if (_children == null)
                {
                    var newCollection = new FixupCollection<Child>();
                    newCollection.CollectionChanged += FixupChildren;
                    _children = newCollection;
                }
                return _children;
            }
            set
            {
                if (!ReferenceEquals(_children, value))
                {
                    var previousValue = _children as FixupCollection<Child>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupChildren;
                    }
                    _children = value;
                    var newValue = value as FixupCollection<Child>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupChildren;
                    }
                }
            }
        }
        private ICollection<Child> _children;
    
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
    
        private void FixupChildren(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Child item in e.NewItems)
                {
                    if (!item.Activities.Contains(this))
                    {
                        item.Activities.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Child item in e.OldItems)
                {
                    if (item.Activities.Contains(this))
                    {
                        item.Activities.Remove(this);
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
                    if (!item.Activities.Contains(this))
                    {
                        item.Activities.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (User item in e.OldItems)
                {
                    if (item.Activities.Contains(this))
                    {
                        item.Activities.Remove(this);
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
                    if (!item.Activities.Contains(this))
                    {
                        item.Activities.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Subject item in e.OldItems)
                {
                    if (item.Activities.Contains(this))
                    {
                        item.Activities.Remove(this);
                    }
                }
            }
        }

        #endregion
    }
}
