using System.Collections.Generic;

namespace Mars.Model
{
    public class Plateau : IPlateau
    {
        public Plateau(int widht, int heigth)
        {
            Width = widht;
            Heigth = heigth;
            Rovers = new HashSet<IRover>();
        }
        public int Width { get; private set; }
        public int Heigth { get; private set; }
        public ICollection<IRover> Rovers { get; }
        public void AddRover(IRover rover) => Rovers.Add(rover);
    }
}
