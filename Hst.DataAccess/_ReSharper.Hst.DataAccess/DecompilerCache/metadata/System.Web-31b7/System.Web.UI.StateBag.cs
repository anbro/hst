// Type: System.Web.UI.StateBag
// Assembly: System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// Assembly location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.Web.dll

using System;
using System.Collections;
using System.Runtime;

namespace System.Web.UI
{
    public sealed class StateBag : IStateManager, IDictionary, ICollection, IEnumerable
    {
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public StateBag();

        public StateBag(bool ignoreCase);
        public object this[string key] { get; set; }

        #region IDictionary Members

        void IDictionary.Add(object key, object value);
        public void Clear();
        public IDictionaryEnumerator GetEnumerator();
        void IDictionary.Remove(object key);
        bool IDictionary.Contains(object key);
        IEnumerator IEnumerable.GetEnumerator();
        void ICollection.CopyTo(Array array, int index);

        public int Count { get; }
        public ICollection Keys { get; }
        public ICollection Values { get; }
        object IDictionary.this[object key] { get; set; }
        bool IDictionary.IsFixedSize { get; }
        bool IDictionary.IsReadOnly { get; }
        bool ICollection.IsSynchronized { get; }
        object ICollection.SyncRoot { get; }

        #endregion

        #region IStateManager Members

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        void IStateManager.LoadViewState(object state);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        void IStateManager.TrackViewState();

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        object IStateManager.SaveViewState();

        bool IStateManager.IsTrackingViewState { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; }

        #endregion

        public StateItem Add(string key, object value);
        public bool IsItemDirty(string key);
        public void Remove(string key);
        public void SetDirty(bool dirty);
        public void SetItemDirty(string key, bool dirty);
    }
}
