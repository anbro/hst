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
    public partial class TestResult
    {
        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual int Correct
        {
            get;
            set;
        }
    
        public virtual int NotAnswered
        {
            get;
            set;
        }
    
        public virtual string Incorrect
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<Test> Tests
        {
            get
            {
                if (_tests == null)
                {
                    var newCollection = new FixupCollection<Test>();
                    newCollection.CollectionChanged += FixupTests;
                    _tests = newCollection;
                }
                return _tests;
            }
            set
            {
                if (!ReferenceEquals(_tests, value))
                {
                    var previousValue = _tests as FixupCollection<Test>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupTests;
                    }
                    _tests = value;
                    var newValue = value as FixupCollection<Test>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupTests;
                    }
                }
            }
        }
        private ICollection<Test> _tests;
    
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

        #endregion
        #region Association Fixup
    
        private void FixupTests(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Test item in e.NewItems)
                {
                    if (!item.TestResults.Contains(this))
                    {
                        item.TestResults.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Test item in e.OldItems)
                {
                    if (item.TestResults.Contains(this))
                    {
                        item.TestResults.Remove(this);
                    }
                }
            }
        }
    
        private void FixupChildren(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Child item in e.NewItems)
                {
                    if (!item.TestResults.Contains(this))
                    {
                        item.TestResults.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Child item in e.OldItems)
                {
                    if (item.TestResults.Contains(this))
                    {
                        item.TestResults.Remove(this);
                    }
                }
            }
        }

        #endregion
    }
}
