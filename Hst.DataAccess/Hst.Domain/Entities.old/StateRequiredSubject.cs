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
    public partial class StateRequiredSubject
    {
        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
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
    
        private void FixupSubjects(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Subject item in e.NewItems)
                {
                    if (!item.StateRequiredSubjects.Contains(this))
                    {
                        item.StateRequiredSubjects.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Subject item in e.OldItems)
                {
                    if (item.StateRequiredSubjects.Contains(this))
                    {
                        item.StateRequiredSubjects.Remove(this);
                    }
                }
            }
        }

        #endregion
    }
}