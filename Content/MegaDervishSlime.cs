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
    internal class MegaDervishSlime
    {
        internal static (SlimeDefinition, GameObject, SlimeAppearance) megaDervishSlime;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) innerRingsAttachment;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) outerRingsAttachment;

        public static void RegisterMega()
        {
            SlimeAppearance.Palette dervishPalette = Slime.GetSlimeDef(Identifiable.Id.DERVISH_SLIME).AppearancesDefault[0].ColorPalette;
            megaDervishSlime = Slime.CreateSlime(Identifiable.Id.DERVISH_SLIME, Identifiable.Id.DERVISH_SLIME, Evonums.MEGA_DERVISH_SLIME, "Mega Dervish Slime", LoadResource<Sprite>("iconSlimePink"), dervishPalette.Ammo, dervishPalette.Top, dervishPalette.Middle, dervishPalette.Bottom, dervishPalette.Ammo, Vacuumable.Size.LARGE);

            SlimeDefinition mDervishDef = megaDervishSlime.Item1;
            GameObject mDervishObj = megaDervishSlime.Item2;
            SlimeAppearance mDervishApp = megaDervishSlime.Item3;

            mDervishDef.Diet.Produces = new Identifiable.Id[] { Identifiable.Id.DERVISH_PLORT, Identifiable.Id.DERVISH_PLORT, Identifiable.Id.DERVISH_PLORT };
            mDervishDef.Diet.FavoriteProductionCount = 5;

            mDervishDef.CanLargofy = false;

            mDervishObj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            mDervishObj.GetComponent<SlimeHealth>().maxHealth = 25;

            SlimeAppearance.SlimeBone[] attachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };

            innerRingsAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "dervishInnerRings", "slime_inner_rings", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.Spinner, attachedBones, RubberBoneEffect.RubberType.Slime, false, true);
            innerRingsAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimeInnerRings", mDervishApp, new SlimeAppearanceObject[] { innerRingsAttachment.Item2 }, 1);

            outerRingsAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "dervishOuterRings", "slime_outer_rings", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.Spinner, attachedBones, RubberBoneEffect.RubberType.Slime, false, true);
            outerRingsAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimeOuterRings", mDervishApp, new SlimeAppearanceObject[] { outerRingsAttachment.Item2 }, 2);

            mDervishApp.Structures[1].DefaultMaterials[0] = Slime.GetSlimeDef(Identifiable.Id.DERVISH_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0];
            mDervishApp.Structures[2].DefaultMaterials[0] = Slime.GetSlimeDef(Identifiable.Id.DERVISH_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0];

            EatMap.CreateBecomeMap(Identifiable.Id.DERVISH_SLIME, Evonums.MEGA_DERVISH_SLIME, Stonums.DERVISHITE, slimeDriver: SlimeEmotions.Emotion.NONE);
        }
    }
}
