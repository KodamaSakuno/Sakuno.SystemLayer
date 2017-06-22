namespace Sakuno.SystemLayer.Dialogs
{
    public static class TaskDialogExtensions
    {
        public static TaskDialogResult ShowAndDispose(this TaskDialog taskDialog)
        {
            using (taskDialog)
                return taskDialog.Show();
        }
    }
}
