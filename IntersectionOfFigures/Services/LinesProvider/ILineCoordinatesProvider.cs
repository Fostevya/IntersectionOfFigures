using IntersectionOfFigures.Models;

namespace IntersectionOfFigures.Services
{
    public interface ILineCoordinatesProvider
    {
        List<LineCoordinates> GetLineCoordinates();
    }
}
