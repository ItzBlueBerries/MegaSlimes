using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ShortcutLib.Shortcut;
using static MegaSlimes.OtherFunc;
using SRML.SR;

namespace MegaSlimes.Content
{
    internal class MegaCrateReef
    {
        internal static GameObject megaCrateReef;

        public static void RegisterCrate()
        {
            megaCrateReef = Resource.CreateCrate(Identifiable.Id.CRATE_REEF_01, Crates.MEGA_CRATE_REEF, "Mega Crate", Color.black, crateTexture: LoadImage("Assets.tex.mega_crate_tex"), textureCrate: true, minSpawn: 3, maxSpawn: 3);

            var stonesToSpawn = new List<BreakOnImpact.SpawnOption>
            {
                new BreakOnImpact.SpawnOption()
                {
                    spawn = Prefab.GetPrefab(Stonums.PINKINITE),
                    weight = 1f
                },
                new BreakOnImpact.SpawnOption()
                {
                    spawn = Prefab.GetPrefab(Stonums.TABBINITE),
                    weight = 0.5f
                },
                new BreakOnImpact.SpawnOption()
                {
                    spawn = Prefab.GetPrefab(Stonums.ROCKITE_B),
                    weight = 0.3f
                },
                new BreakOnImpact.SpawnOption()
                {
                    spawn = Prefab.GetPrefab(Stonums.ROCKITE_A),
                    weight = 0.1f
                },
            };

            megaCrateReef.GetComponent<BreakOnImpact>().spawnOptions = stonesToSpawn;
        }
    }
}
