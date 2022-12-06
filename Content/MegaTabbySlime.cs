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
    internal class MegaTabbySlime
    {
        internal static (SlimeDefinition, GameObject, SlimeAppearance) megaTabbySlime;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) earsAttachment;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) tailsAttachment;

        public static void RegisterMega()
        {
            SlimeAppearance.Palette tabbyPalette = Slime.GetSlimeDef(Identifiable.Id.TABBY_SLIME).AppearancesDefault[0].ColorPalette;
            megaTabbySlime = Slime.CreateSlime(Identifiable.Id.TABBY_SLIME, Identifiable.Id.TABBY_SLIME, Evonums.MEGA_TABBY_SLIME, "Mega Tabby Slime", LoadResource<Sprite>("iconSlimeTabby"), tabbyPalette.Ammo, tabbyPalette.Top, tabbyPalette.Middle, tabbyPalette.Bottom, tabbyPalette.Ammo, Vacuumable.Size.LARGE);

            SlimeDefinition mTabbyDef = megaTabbySlime.Item1;
            GameObject mTabbyObj = megaTabbySlime.Item2;
            SlimeAppearance mTabbyApp = megaTabbySlime.Item3;

            mTabbyDef.Diet.Produces = new Identifiable.Id[] { Identifiable.Id.TABBY_PLORT, Identifiable.Id.TABBY_PLORT, Identifiable.Id.TABBY_PLORT };
            mTabbyDef.Diet.FavoriteProductionCount = 5;

            mTabbyDef.CanLargofy = false;

            mTabbyObj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            UnityEngine.Object.Destroy(mTabbyObj.GetComponent<FleeThreats>());
            mTabbyObj.GetComponent<SlimeHealth>().maxHealth = 36;

            SlimeAppearance.SlimeBone[] attachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };

            earsAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "tabbyEars", "slime_ears", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime);
            earsAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimeEars", mTabbyApp, new SlimeAppearanceObject[] { earsAttachment.Item2 }, 1);

            tailsAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "tabbyTails", "slime_tails", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime);
            tailsAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimeTails", mTabbyApp, new SlimeAppearanceObject[] { tailsAttachment.Item2 }, 2);

            mTabbyApp.Structures[1].DefaultMaterials[0] = Slime.GetSlimeDef(Identifiable.Id.TABBY_SLIME).GetSlimeMat(1);
            mTabbyApp.Structures[2].DefaultMaterials[0] = Slime.GetSlimeDef(Identifiable.Id.TABBY_SLIME).GetSlimeMat(1);

            EatMap.CreateBecomeMap(Identifiable.Id.TABBY_SLIME, Evonums.MEGA_TABBY_SLIME, Stonums.TABBINITE, slimeDriver: SlimeEmotions.Emotion.NONE);
        }
    }
}
