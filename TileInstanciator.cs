using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTerra.World
{
    public sealed class TileInstanciator
    {
        private Tile singletonInstance;

        public Type TileType { get; private set; }

        public bool IsSingletonTile { get; private set; }

        public Tile GetTileInstance()
        {
            if (IsSingletonTile)
            {
                return singletonInstance;
            }
            else
            {
                return (Tile)Activator.CreateInstance(TileType, new byte[] { });
            }
        }

        public TileInstanciator(Type tileType)
        {
            if (!typeof(Tile).IsAssignableFrom(tileType))
                throw new ArgumentException("Type has to derive from OpenTerra.World.Tile", "tileType");

            if (Tile.IsSingletonTile(tileType))
            {
                singletonInstance = (Tile)Activator.CreateInstance(tileType, new byte[] { });
                IsSingletonTile = true;
            }
        }
    }
}