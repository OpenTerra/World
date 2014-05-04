using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTerra.World
{
    /// <summary>
    /// Represents a Row of Chunks containing Tiles of generic Type.
    /// </summary>
    /// <typeparam name="TileType">The Type of Tiles contained in this ChunkRow. Must derive from <see cref="OpenTerra.World.Tile"/>.</typeparam>
    public sealed class ChunkRow<TileType> where TileType : Tile
    {
        /// <summary>
        /// The location of the ChunkRow in the stack of Rows making up a Layer. Zero based, from bottom to top.
        /// </summary>
        public byte Index { get; set; }

        /// <summary>
        /// The Chunks in this ChunkRow. From left to right.
        /// </summary>
        public Chunk<TileType>[] Chunks { get; set; }

        /// <summary>
        /// Number of Chunks in this ChunkRow.
        /// </summary>
        public byte Length
        {
            get { return (byte)Chunks.Length; }
        }

        /// <summary>
        /// Gets or sets the Chunk at the given index.
        /// </summary>
        /// <param name="chunkIndex">Zero based index of the Chunk in the row. From left to right.</param>
        /// <returns></returns>
        public Chunk<TileType> this[byte chunkIndex]
        {
            get
            {
                if (chunkIndex >= Length)
                    throw new ArgumentOutOfRangeException("Chunk Index has to be smaller than the number of Chunks.");

                return Chunks[chunkIndex];
            }

            set
            {
                if (chunkIndex >= Length)
                    throw new ArgumentOutOfRangeException("Chunk Index has to be smaller than the number of Chunks.");

                Chunks[chunkIndex] = value;
            }
        }
    }

    /// <summary>
    /// Contains static information about ChunkRows.
    /// </summary>
    public static class ChunkRow
    {
        /// <summary>
        /// The Maximum number of Chunks in a ChunkRow.
        /// </summary>
        public static byte MaximumNumberOfChunks
        {
            get { return 255; }
        }

        /// <summary>
        /// The maximum number of Tiles a Row can be long.
        /// </summary>
        public static ushort MaximumWidth
        {
            get { return (ushort)(Chunk.Width * MaximumNumberOfChunks); }
        }

        /// <summary>
        /// The Height of a ChunkRow.
        /// </summary>
        public static byte Height
        {
            get { return Chunk.Height; }
        }
    }
}