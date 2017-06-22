namespace Sakuno.SystemLayer.Dialogs
{
    public class CommonFileDialogCustomPlace
    {
        public string Path { get; }
        public CommonFileDialogCustomPlaceLocation Location { get; }

        public CommonFileDialogCustomPlace(string path) : this(path, CommonFileDialogCustomPlaceLocation.Bottom) { }
        public CommonFileDialogCustomPlace(string path, CommonFileDialogCustomPlaceLocation location)
        {
            Path = path;
            Location = location;
        }
    }
}
