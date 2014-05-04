using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTerra.World
{
    /// <summary>
    /// Represents the abstract base for a Tile, including default implementations.
    /// </summary>
    public abstract partial class Tile
    {
        /// <summary>
        /// Gets called when the Tile is saved.
        /// Has to be overridden if the Tile wants to persist any data. Maximum length is 255 bytes.
        /// Default returns an empty byte[].
        /// </summary>
        /// <returns>A maximum of 255 Bytes that get persisted for the Tile.</returns>
        public virtual byte[] Save()
        {
            return new byte[] { };
        }

        /// <summary>
        /// Gets called by the base constructor to load the data that was persisted for the Tile.
        /// Has to be overridden if the Tile wants to persist any data. Maximum length is 255 bytes.
        /// Default does nothing.
        /// </summary>
        /// <param name="data">A maximum of 255 bytes that were persisted for the Tile.</param>
        protected virtual void load(byte[] data)
        {
        }

        public Tile(byte[] data)
        {
            load(data);
        }
    }
}