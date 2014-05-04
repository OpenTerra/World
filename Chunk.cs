using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTerra.World
{
    /// <summary>
    /// Represents a chunk containing Tiles of generic Type.
    /// </summary>
    /// <typeparam name="TileType">The Type of Tiles contained in this chunk. Must derive from <see cref="OpenTerra.World.Tile"/>.</typeparam>
    public sealed class Chunk<TileType> where TileType : Tile, new()
    {
        /// <summary>
        /// The Location of the Chunk, based on the number of chunks.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Chunk.Width x Chunk.Height grid of Tiles.
        /// </summary>
        public TileType[,] Tiles { get; set; }

        /// <summary>
        /// Gets or sets the Tile at the given Location, relative to the Chunk border.
        /// </summary>
        /// <param name="x">X coordinate of the Tile. Zero based number of tiles from the left border of the chunk.</param>
        /// <param name="y">Y coordinate of the Tile. Zero based number of tiles from the bottom border fo the chunk.</param>
        /// <returns>The Tile at the given coordinates.</returns>
        public TileType this[byte x, byte y]
        {
            get
            {
                if (x >= Chunk.Width || y >= Chunk.Height)
                    throw new ArgumentOutOfRangeException("X coordinate has to be < " + Chunk.Width + " and Y coordinate has to be < " + Chunk.Height);

                return Tiles[x, y];
            }

            set
            {
                if (x >= Chunk.Width || y >= Chunk.Height)
                    throw new ArgumentOutOfRangeException("X coordinate has to be < " + Chunk.Width + " and Y coordinate has to be < " + Chunk.Height);

                Tiles[x, y] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Tile at the given Location, relative to the Chunk borders.
        /// Use <see cref="OpenTerra.World.Location.Location.GetTileLocationInChunk(Location)"/> to get the relative coordinate.
        /// </summary>
        /// <param name="location">Location of the Tile, relative to the Chunk borders.</param>
        /// <returns>The Tile in the given Location.</returns>
        public TileType this[Location location]
        {
            get
            {
                if (location.X >= Chunk.Width || location.Y >= Chunk.Height)
                    throw new ArgumentOutOfRangeException("X coordinate has to be < " + Chunk.Width + " and Y coordinate has to be < " + Chunk.Height);

                return Tiles[location.X, location.Y];
            }

            set
            {
                if (location.X >= Chunk.Width || location.Y >= Chunk.Height)
                    throw new ArgumentOutOfRangeException("X coordinate has to be < " + Chunk.Width + " and Y coordinate has to be < " + Chunk.Height);

                Tiles[location.X, location.Y] = value;
            }
        }
    }

    /// <summary>
    /// Contains static information about Chunks.
    /// </summary>
    public static class Chunk
    {
        /// <summary>
        /// The Width of a Chunk.
        /// </summary>
        public static byte Width
        {
            get { return 64; }
        }

        /// <summary>
        /// The Height of a Chunk.
        /// </summary>
        public static byte Height
        {
            get { return 64; }
        }

        public static ushort TilesPerChunk
        {
            get { return (ushort)(Width * Height); }
        }
    }
}