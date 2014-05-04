using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTerra.World
{
    /// <summary>
    /// Represents a Layer containing Tiles of generic Type.
    /// </summary>
    /// <typeparam name="TileType">The Type of Tiles contained in this Layer. Must derive from <see cref="OpenTerra.World.Tile"/>.</typeparam>
    public sealed class Layer<TileType> where TileType : Tile
    {
        /// <summary>
        /// The Rows in this Layer. From bottom to top.
        /// </summary>
        public ChunkRow<TileType>[] ChunkRows { get; set; }
    }

    /// <summary>
    /// Contains static information about Layers.
    /// </summary>
    public static class Layer
    {
        /// <summary>
        /// Gets the maximum number of ChunkRows in a Layer.
        /// </summary>
        public static byte MaximumRows
        {
            get { return 255; }
        }

        /// <summary>
        /// Gets the maximum width of a Layer.
        /// </summary>
        public static ushort MaximumWidth
        {
            get { return ChunkRow.MaximumWidth; }
        }

        /// <summary>
        /// Gets the maximum height of a Layer.
        /// </summary>
        public static ushort MaximumHeight
        {
            get { return (ushort)(ChunkRow.Height * MaximumRows); }
        }
    }
}