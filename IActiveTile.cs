using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTerra.World
{
    public interface IActiveTile
    {
        void Tick(Location location);
    }
}