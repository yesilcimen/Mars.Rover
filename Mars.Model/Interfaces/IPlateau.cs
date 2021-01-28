using System.Collections.Generic;

namespace Mars.Model
{
    public interface IPlateau
    {
        int Width { get; }
        int Heigth { get; }
        ICollection<IRover> Rovers { get; }
        void AddRover(IRover rover);
    }
}
