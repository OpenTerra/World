using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenTerra.World
{
    public static class TileLoader
    {
        public static void Load(string path)
        {
            foreach (string tileAssemblyPath in Directory.EnumerateFiles(path, "*.dll", SearchOption.AllDirectories))
            {
                Assembly tileAssembly = Assembly.LoadFrom(tileAssemblyPath);

                IEnumerable<Type> tileTypes = tileAssembly.GetExportedTypes().Where(type => Tile.IsRegisteredTile(type));
            }
        }
    }
}