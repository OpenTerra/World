using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTerra.World
{
    public static class TileCharacteristics
    {
        public enum State : byte
        {
            All,
            Solid,
            Liquid,
            Gaseous
        }

        public enum Opacity : byte
        {
            Both,
            Opaque,
            Transparent
        }

        public enum IsLightSource : byte
        {
            Both,
            Yes,
            No
        }

        public enum PlayerPenetratable : byte
        {
            Both,
            Yes,
            No
        }

        public enum ProjectilePenetratable : byte
        {
            Both,
            Yes,
            No
        }

        public enum GasPenetratable : byte
        {
            Both,
            Yes,
            No
        }

        public enum LiquidPenetratable : byte
        {
            Both,
            Yes,
            No
        }

        public enum SolidPenetratable : byte
        {
            Both,
            Yes,
            No
        }
    }
}