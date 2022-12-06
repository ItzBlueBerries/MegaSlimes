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
    internal class MegaPhosphorSlime
    {
        internal static (SlimeDefinition, GameObject, SlimeAppearance) megaPhosphorSlime;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) antenAttachment;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) wingAttachmentL;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) wingAttachmentR;

        public static void RegisterMega()
        {
            SlimeAppearance.Palette phosphorPalette = Slime.GetSlimeDef(Identifiable.Id.PHOSPHOR_SLIME).AppearancesDefault[0].ColorPalette;
            megaPhosphorSlime = Slime.CreateSlime(Identifiable.Id.PHOSPHOR_SLIME, Identifiable.Id.PHOSPHOR_SLIME, Evonums.MEGA_PHOSPHOR_SLIME, "Mega Phosphor Slime", LoadResource<Sprite>("iconSlimePhosphor"), phosphorPalette.Ammo, phosphorPalette.Top, phosphorPalette.Middle, phosphorPalette.Bottom, phosphorPalette.Ammo, Vacuumable.Size.LARGE);

            SlimeDefinition mPhosDef = megaPhosphorSlime.Item1;
            GameObject mPhosObj = megaPhosphorSlime.Item2;
            SlimeAppearance mPhosApp = megaPhosphorSlime.Item3;

            mPhosDef.Diet.Produces = new Identifiable.Id[] { Identifiable.Id.PHOSPHOR_PLORT, Identifiable.Id.PHOSPHOR_PLORT, Identifiable.Id.PHOSPHOR_PLORT };
            mPhosDef.Diet.FavoriteProductionCount = 5;

            mPhosDef.CanLargofy = false;

            mPhosObj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            UnityEngine.Object.Destroy(mPhosObj.GetComponent<DestroyOutsideHoursOfDay>());

            SlimeAppearance.SlimeBone[] attachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };

            antenAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "phosphorAnten", "slime_anten", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime);
            antenAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimeAnten", mPhosApp, new SlimeAppearanceObject[] { antenAttachment.Item2 }, 1);

            wingAttachmentL = Structure.CreateBasicStructure(Bundles.evo_structures, "phosphorWingL", "slime_wing_l", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.LeftWing, attachedBones, RubberBoneEffect.RubberType.Slime, false, true);
            wingAttachmentL.Item2.IgnoreLODIndex = true;
            wingAttachmentR = Structure.CreateBasicStructure(Bundles.evo_structures, "phosphorWingR", "slime_wing_r", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.RightWing, attachedBones, RubberBoneEffect.RubberType.Slime, false, true);
            wingAttachmentR.Item2.IgnoreLODIndex = true;

            Structure.SetStructureElement("slimeWings", mPhosApp, new SlimeAppearanceObject[] { wingAttachmentL.Item2, wingAttachmentR.Item2 }, 2);

            EatMap.CreateBecomeMap(Identifiable.Id.PHOSPHOR_SLIME, Evonums.MEGA_PHOSPHOR_SLIME, Stonums.PHOSPHORITE, slimeDriver: SlimeEmotions.Emotion.NONE);
        }
    }
}
