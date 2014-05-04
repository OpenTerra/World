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
    public sealed class Layer<TileType> where TileType : Tile, new()
    {
        /// <summary>
        /// The Rows in this Layer. From bottom to top.
        /// </summary>
        public ChunkRow<TileType>[] ChunkRows { get; set; }
    }
}