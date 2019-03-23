using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer.Dialogs
{
    class TaskDialogButtonCollection<T> : Collection<T> where T : TaskDialogButtonBase
    {
        TaskDialog _owner;

        IntPtr _nativeData;
        int _nativeDataElementCount;

        public TaskDialogButtonCollection(TaskDialog owner)
        {
            _owner = owner;
        }

        public T GetButtonById(int id)
        {
            if (Count == 0)
                return null;

            foreach (var button in this)
                if (button.Id == id)
                    return button;

            return null;
        }
        public T GetDefaultButton()
        {
            if (Count == 0)
                return null;

            foreach (var button in this)
                if (button.Default)
                    return button;

            return this[0];
        }

        public unsafe IntPtr GetNativeData()
        {
            Cleanup();

            _nativeData = Marshal.AllocHGlobal(sizeof(NativeStructs.TASKDIALOG_BUTTON) * Count);
            _nativeDataElementCount = Count;

            var current = (NativeStructs.TASKDIALOG_BUTTON*)_nativeData;

            foreach (var button in this)
            {
                current->nButtonID = button.Id;
                current->pszButtonText = Marshal.StringToHGlobalUni(button.Text);

                current++;
            }

            return _nativeData;
        }

        public unsafe void Cleanup()
        {
            if (_nativeData == IntPtr.Zero)
                return;

            var current = (NativeStructs.TASKDIALOG_BUTTON*)_nativeData;

            for (var i = 0; i < _nativeDataElementCount; i++)
            {
                Marshal.FreeHGlobal(current->pszButtonText);

                current++;
            }

            Marshal.FreeHGlobal(_nativeData);
            _nativeData = IntPtr.Zero;
        }

        protected override void InsertItem(int index, T item)
        {
            item.Owner = _owner;

            base.InsertItem(index, item);
        }
        protected override void SetItem(int index, T item)
        {
            item.Owner = _owner;

            base.SetItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            this[index].Owner = null;

            base.RemoveItem(index);
        }
        protected override void ClearItems()
        {
            foreach (var item in this)
                item.Owner = null;

            base.ClearItems();
        }
    }
}
