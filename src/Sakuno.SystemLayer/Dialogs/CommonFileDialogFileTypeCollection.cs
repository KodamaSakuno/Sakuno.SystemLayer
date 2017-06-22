using System.Collections.ObjectModel;

namespace Sakuno.SystemLayer.Dialogs
{
    class CommonFileDialogFileTypeCollection : Collection<CommonFileDialogFileType>
    {
        internal NativeStructs.COMDLG_FILTERSPEC[] ToFilterSpec()
        {
            var result = new NativeStructs.COMDLG_FILTERSPEC[Count];

            for (var i = 0; i < result.Length; i++)
                result[i] = this[i].ToFilterSpec();

            return result;
        }
    }
}
