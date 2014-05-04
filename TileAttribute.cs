using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTerra.World
{
    public abstract partial class Tile
    {
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
        protected sealed class RegisterTileAttribute : Attribute
        {
            public TileCharacteristics.State State { get; set; }

            public TileCharacteristics.Opacity Opacity { get; set; }

            public TileCharacteristics.IsLightSource IsLightSource { get; set; }

            public TileCharacteristics.PlayerPenetratable PlayerPenetratable { get; set; }

            public TileCharacteristics.ProjectilePenetratable ProjectilePenetratable { get; set; }

            public TileCharacteristics.GasPenetratable GasPenetratable { get; set; }

            public TileCharacteristics.LiquidPenetratable LiquidPenetratable { get; set; }

            public bool IsSingleton { get; set; }

            public ushort Id { get; private set; }

            public string Name { get; private set; }

            public RegisterTileAttribute(ushort id, string name)
            {
                Id = id;
                Name = name;

                initializeDefaults();
            }

            private void initializeDefaults()
            {
                State = TileCharacteristics.State.All;
                Opacity = TileCharacteristics.Opacity.Both;
                IsLightSource = TileCharacteristics.IsLightSource.Both;
                PlayerPenetratable = TileCharacteristics.PlayerPenetratable.Both;
                ProjectilePenetratable = TileCharacteristics.ProjectilePenetratable.Both;
                GasPenetratable = TileCharacteristics.GasPenetratable.Both;
                LiquidPenetratable = TileCharacteristics.LiquidPenetratable.Both;
                IsSingleton = false;
            }
        }

        public static bool IsRegisteredTile(Type type)
        {
            if (!typeof(Tile).IsAssignableFrom(type))
                return false;

            return type.GetCustomAttributes(typeof(RegisterTileAttribute), false).Length > 0;
        }

        public static bool IsSingletonTile(Type tileType)
        {
            if (!typeof(Tile).IsAssignableFrom(tileType))
                throw new ArgumentException("Type has to derive from OpenTerra.World.Tile", "tileType");

            RegisterTileAttribute attribute = (RegisterTileAttribute)tileType.GetCustomAttributes(typeof(RegisterTileAttribute), false).FirstOrDefault();
            return attribute.IsSingleton;
        }
    }
}