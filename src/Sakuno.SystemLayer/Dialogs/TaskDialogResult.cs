namespace Sakuno.SystemLayer.Dialogs
{
    public struct TaskDialogResult
    {
        public TaskDialogCommonButton ClickedCommonButton { get; }

        public TaskDialogButton SelectedButton { get; }
        public TaskDialogRadioButton SelectedRadioButton { get; }

        public bool IsFooterCheckBoxChecked { get; }

        internal TaskDialogResult(TaskDialog owner, int selectedButtonId, int selectedRadioButtonId, bool isFooterCheckBoxChecked)
        {
            switch (selectedButtonId)
            {
                case 1:
                    ClickedCommonButton = TaskDialogCommonButton.OK;
                    break;

                case 2:
                    ClickedCommonButton = TaskDialogCommonButton.Cancel;
                    break;

                case 4:
                    ClickedCommonButton = TaskDialogCommonButton.Retry;
                    break;

                case 6:
                    ClickedCommonButton = TaskDialogCommonButton.Yes;
                    break;

                case 7:
                    ClickedCommonButton = TaskDialogCommonButton.No;
                    break;

                case 8:
                    ClickedCommonButton = TaskDialogCommonButton.Close;
                    break;

                default:
                    ClickedCommonButton = TaskDialogCommonButton.None;
                    break;
            }

            SelectedButton = null;
            SelectedRadioButton = null;

            if (ClickedCommonButton == TaskDialogCommonButton.None && owner._buttons != null && owner._buttons.Count > 0)
                foreach (var button in owner._buttons)
                    if (button.Id == selectedButtonId)
                        SelectedButton = button;

            if (selectedRadioButtonId != 0 && owner._radioButtons != null && owner._radioButtons.Count > 0)
                foreach (var radioButton in owner._radioButtons)
                    if (radioButton.Id == selectedRadioButtonId)
                        SelectedRadioButton = radioButton;

            IsFooterCheckBoxChecked = isFooterCheckBoxChecked;
        }
    }
}
