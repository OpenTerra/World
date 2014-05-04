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
            : this()
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Takes the current Location as absolute Location for a Tile and returns the Location for the Chunk it's in.
        /// </summary>
        /// <returns>Location for the Chunk the Tile is in.</returns>
        public Location ToChunkLocation()
        {
            return new Location((ushort)((X - (X % Chunk.Width)) / Chunk.Width), (ushort)((Y - (Y % Chunk.Height)) / Chunk.Height));
        }

        /// <summary>
        /// Takes the current Location as an absolute Location for a Tile and returns its Location relative to its Chunk.
        /// </summary>
        /// <returns>Location relative to the Tile's Chunk.</returns>
        public Location ToTileLocationInChunk()
        {
            return new Location((ushort)(X % Chunk.Width), (ushort)(Y % Chunk.Height));
        }
    }
}