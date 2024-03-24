namespace IntersectionOfFigures.Services
{
    public interface IDialogService
    {
        void ShowMessage(string message);
        string FilePath { get; set; }
        bool OpenFileDialog(string title, string filter);
    }
}
