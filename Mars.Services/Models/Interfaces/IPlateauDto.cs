using Mars.Model;
using System.Collections.Generic;

namespace Mars.Services
{
    public interface IPlateauDto : IPlateau
    {
        new ICollection<IRover> Rovers { get; }

    }
}
