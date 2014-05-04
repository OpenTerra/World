using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTerra.World
{
    /// <summary>
    /// Represents a pair of coordinates in the world.
    /// </summary>
    public struct Location
    {
        /// <summary>
        /// Gets the X coordinate of the location. Zero based number of tiles from the left end of the map.
        /// </summary>
        public ushort X { get; private set; }

        /// <summary>
        /// Gets the Y coordinate of the location. Zero based number of tiles from the bottom of the map.
        /// </summary>
        public ushort Y { get; private set; }

        /// <summary>
        /// Creates a new instance of the <see cref="OpenTerra.World.Location"/> struct.
        /// </summary>
        /// <param name="x">X coordinate of the location. Zero based number of tiles from the left end of the map.</param>
        /// <param name="y">Y coordinate of the location. Zero based number of tiles from the bottom of the map.</param>
        public Location(ushort x, ushort y)
        {
            X = x;
            Y = y;
        }

        public static Location GetChunkLocation(Location absoluteTileLocation)
        {
            return new Location((ushort)(absoluteTileLocation.X - (absoluteTileLocation.X % Chunk.Width)), (ushort)(absoluteTileLocation.Y - (absoluteTileLocation.Y % Chunk.Height)))
        }

        public static Location GetTileLocationInChunk(Location absoluteTileLocation)
        {
            return new Location((ushort)(absoluteTileLocation.X & Chunk.Width), (ushort)(absoluteTileLocation.Y % Chunk.Height));
        }
    }
}