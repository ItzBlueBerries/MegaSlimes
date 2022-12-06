using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ShortcutLib.Shortcut;
using static ShortcutLib.Assets;

namespace MegaSlimes.Content
{
    internal class StoneDriller_Tier1
    {
        internal static GameObject stoneDrillerTier1;
        internal static GadgetDefinition.CraftCost[] craftCosts;
        internal static Extractor.ProduceEntry[] produceEntries;

        public static void RegisterTier()
        {
            craftCosts = new GadgetDefinition.CraftCost[]
            {
                new GadgetDefinition.CraftCost()
                {
                    id = Identifiable.Id.INDIGONIUM_CRAFT,
                    amount = 80
                },
                new GadgetDefinition.CraftCost()
                {
                    id = Identifiable.Id.SLIME_FOSSIL_CRAFT,
                    amount = 50
                },
                new GadgetDefinition.CraftCost()
                {
                    id = Identifiable.Id.STRANGE_DIAMOND_CRAFT,
                    amount = 20
                }
            };

            produceEntries = new Extractor.ProduceEntry[]
            {
                new Extractor.ProduceEntry()
                {
                    id = Stonums.PINKINITE,
                    weight = 90f
                },
                new Extractor.ProduceEntry()
                {
                    id = Stonums.PHOSPHORITE,
                    weight = 90f
                },
                new Extractor.ProduceEntry()
                {
                    restrictZone = true,
                    zone = ZoneDirector.Zone.MOSS,
                    id = Stonums.TABBINITE,
                    weight = 60f
                },
                new Extractor.ProduceEntry()
                {
                    restrictZone = true,
                    zone = ZoneDirector.Zone.QUARRY,
                    id = Stonums.ROCKITE_B,
                    weight = 30f
                },
                new Extractor.ProduceEntry()
                {
                    restrictZone = true,
                    zone = ZoneDirector.Zone.QUARRY,
                    id = Stonums.ROCKITE_A,
                    weight = 20f
                }
            };

            Color32[] mainColors = new Color32[]
            {
                Color.grey,
                Color.black,
                Other.LoadHex("#964B00"),
                Color.grey,
                Color.black,
                Color.grey,
                Color.black,
                Color.white
            };

            Color32[] extColors1 = new Color32[]
            {
                Color.grey,
                Color.black,
                Other.LoadHex("#964B00"),
                Color.grey,
                Color.black,
                Color.grey,
                Color.black,
                Color.white
            };

            Color32[] extColors2 = new Color32[]
            {
                Color.grey,
                Color.black,
                Other.LoadHex("#964B00"),
                Color.grey,
                Color.black,
                Color.grey,
                Color.black,
                Color.white
            };

            stoneDrillerTier1 = Resource.CreateExtractor(Gadget.Id.EXTRACTOR_DRILL_NOVICE, Gadgets.STONE_DRILLER_TIER1, "Stone Driller : Tier 1", LoadResource<Sprite>("iconSlimePink"),
                "Some may say this particular gadget could find various mysterious stones.",
                10000,
                1,
                craftCosts,
                produceEntries,
                ProgressDirector.ProgressType.UNLOCK_LAB,
                minProduce: 2,
                maxProduce: 5,
                timePerCycle: 24,
                infiniteCycles: true
            );

            Resource.ColorExtractor(Gadgets.STONE_DRILLER_TIER1, mainColors, extColors1, extColors2, 2, isDrill: true);
        }
    }
}
