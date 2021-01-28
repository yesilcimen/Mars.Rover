using Mars.Model;

namespace Mars.Services
{
    internal class PlateauDto : Plateau, IPlateauDto
    {
        public PlateauDto(int widht, int heigth) : base(widht, heigth)
        {
        }
    }
}
