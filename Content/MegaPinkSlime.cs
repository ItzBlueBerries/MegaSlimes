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
    internal class MegaPinkSlime
    {
        internal static (SlimeDefinition, GameObject, SlimeAppearance) megaPinkSlime;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) stubAttachment;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) armAttachment;

        public static void RegisterMega()
        {
            SlimeAppearance.Palette pinkPalette = Slime.GetSlimeDef(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].ColorPalette;
            megaPinkSlime = Slime.CreateSlime(Identifiable.Id.PINK_SLIME, Identifiable.Id.PINK_SLIME, Evonums.MEGA_PINK_SLIME, "Mega Pink Slime", LoadResource<Sprite>("iconSlimePink"), pinkPalette.Ammo, pinkPalette.Top, pinkPalette.Middle, pinkPalette.Bottom, pinkPalette.Ammo, Vacuumable.Size.LARGE);

            SlimeDefinition mPinkDef = megaPinkSlime.Item1;
            GameObject mPinkObj = megaPinkSlime.Item2;
            SlimeAppearance mPinkApp = megaPinkSlime.Item3;

            mPinkDef.Diet.Produces = new Identifiable.Id[] { Identifiable.Id.PINK_PLORT, Identifiable.Id.PINK_PLORT, Identifiable.Id.PINK_PLORT };
            mPinkDef.Diet.FavoriteProductionCount = 5;

            mPinkDef.CanLargofy = false;

            mPinkObj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            SlimeAppearance.SlimeBone[] attachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };

            stubAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "pinkStubs", "slime_stubs", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime);
            stubAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimeStubs", mPinkApp, new SlimeAppearanceObject[] { stubAttachment.Item2 }, 1);

            armAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "pinkArms", "slime_arms", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime);
            armAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimeArms", mPinkApp, new SlimeAppearanceObject[] { armAttachment.Item2 }, 2);

            mPinkApp.Structures[1].DefaultMaterials[0] = mPinkApp.Structures[0].DefaultMaterials[0];
            mPinkApp.Structures[2].DefaultMaterials[0] = mPinkApp.Structures[0].DefaultMaterials[0];

            EatMap.CreateBecomeMap(Identifiable.Id.PINK_SLIME, Evonums.MEGA_PINK_SLIME, Stonums.PINKINITE, slimeDriver: SlimeEmotions.Emotion.NONE);
        }
    }
}
