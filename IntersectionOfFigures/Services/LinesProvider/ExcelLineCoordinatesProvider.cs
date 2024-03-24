using ExcelDataReader;
using IntersectionOfFigures.Exceptions;
using IntersectionOfFigures.Models;
using System.IO;
using System.Threading.Tasks;

namespace IntersectionOfFigures.Services
{
    public class ExcelLineCoordinatesProvider : ILineCoordinatesProvider
    {
        private readonly IDialogService dialogService;

        public ExcelLineCoordinatesProvider(
            IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }
        public List<LineCoordinates> GetLineCoordinates()
        {
            var result = new List<LineCoordinates>();
            if (dialogService.OpenFileDialog("Выберите файл", "Excel|*.xls; *.xlsx"))
            {
                var path = dialogService.FilePath;
                ThrowIfFileNotExists(path);
                using var stream = File.OpenRead(path);
                using var reader = ExcelReaderFactory.CreateReader(stream);
                while (reader.Read())
                {
                    try
                    {
                        var lineCoordinates = new LineCoordinates()
                        {
                            StartX = reader.GetFloat(0),
                            StartY = reader.GetFloat(1),
                            EndX = reader.GetFloat(2),
                            EndY = reader.GetFloat(3),
                        };
                        result.Add(lineCoordinates);
                    }
                    catch (Exception ex)
                    {
                        throw new ReaderReadValueException("Ошибка при чтении значений из файла");
                    }
                }
            }
            return result;
        }

        private static void ThrowIfFileNotExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new TargetFileNotFoundException("Указанный файл не найден.");
            }
        }
    }
}
