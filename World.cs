using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTerra.World
{
    /// <summary>
    /// Represents a whole game World.
    /// </summary>
    public sealed class World
    {
        /// <summary>
        /// Gets the path to the root folder of the World.
        /// </summary>
        public string StoragePath { get; private set; }

        /// <summary>
        /// Gets or sets the name of the World.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Layers of the World.
        /// </summary>
        public Layer<Tile>[] Layers { get; set; } //TODO: Add stuff that loads stuff from the world dynamically when required.

        /// <summary>
        /// Creates a new instance of the <see cref="OpenTerra.World.World"/> class, with data from the given path.
        /// </summary>
        /// <param name="storagePath">Path to the root folder of the World.</param>
        public World(string storagePath)
        {
            StoragePath = storagePath;
        }
    }
}