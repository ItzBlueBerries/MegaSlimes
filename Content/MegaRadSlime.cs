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
    internal class MegaRadSlime
    {
        internal static (SlimeDefinition, GameObject, SlimeAppearance) megaRadSlimeA;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) leftoversAttachment;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) ragingAuraL;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) ragingAuraR;
        internal static (SlimeDefinition, GameObject, SlimeAppearance) megaRadSlimeB;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) personBubbleAttachment;

        public static void RegisterMegaA()
        {
            SlimeAppearance.Palette radPalette = Slime.GetSlimeDef(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].ColorPalette;
            megaRadSlimeA = Slime.CreateSlime(Identifiable.Id.RAD_SLIME, Identifiable.Id.RAD_SLIME, Evonums.MEGA_RAD_SLIME_A, "Mega Rad Slime (A)", LoadResource<Sprite>("iconSlimeRad"), radPalette.Ammo, radPalette.Top, radPalette.Middle, radPalette.Bottom, radPalette.Ammo, Vacuumable.Size.LARGE);

            SlimeDefinition mRadDefA = megaRadSlimeA.Item1;
            GameObject mRadObjA = megaRadSlimeA.Item2;
            SlimeAppearance mRadAppA = megaRadSlimeA.Item3;

            mRadDefA.Diet.Produces = new Identifiable.Id[] { Identifiable.Id.RAD_PLORT, Identifiable.Id.RAD_PLORT, Identifiable.Id.RAD_PLORT };
            mRadDefA.Diet.FavoriteProductionCount = 5;

            mRadDefA.CanLargofy = false;

            mRadObjA.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            mRadObjA.GetComponent<SlimeHealth>().maxHealth = 18;

            SlimeAppearance.SlimeBone[] attachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };

            leftoversAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "radAuraLeftovers", "slime_leftovers", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime);
            leftoversAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimeLeftovers", mRadAppA, new SlimeAppearanceObject[] { leftoversAttachment.Item2 }, 1);

            ragingAuraL = Structure.CreateBasicStructure(Bundles.evo_structures, "radRagingAuraL", "slime_raging_auraL", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime, false, true);
            ragingAuraL.Item2.IgnoreLODIndex = true;
            ragingAuraL.Item1.AddComponent<vp_Spin>().RotationSpeed = new Vector3(0, 360, 0);
            Structure.SetStructureElement("slimeRagingAuraL", mRadAppA, new SlimeAppearanceObject[] { ragingAuraL.Item2 }, 2);

            ragingAuraR = Structure.CreateBasicStructure(Bundles.evo_structures, "radRagingAuraR", "slime_raging_auraR", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime, false, true);
            ragingAuraR.Item2.IgnoreLODIndex = true;
            ragingAuraR.Item1.AddComponent<vp_Spin>().RotationSpeed = new Vector3(0, 360, 0);
            Structure.SetStructureElement("slimeRagingAuraR", mRadAppA, new SlimeAppearanceObject[] { ragingAuraR.Item2 }, 3);

            mRadAppA.Structures[1].DefaultMaterials[0] = Slime.GetSlimeDef(Identifiable.Id.RAD_SLIME).GetSlimeMat(1);
            mRadAppA.Structures[2].DefaultMaterials[0] = Slime.GetSlimeDef(Identifiable.Id.RAD_SLIME).GetSlimeMat(1);
            mRadAppA.Structures[3].DefaultMaterials[0] = Slime.GetSlimeDef(Identifiable.Id.RAD_SLIME).GetSlimeMat(1);

            EatMap.CreateBecomeMap(Identifiable.Id.RAD_SLIME, Evonums.MEGA_RAD_SLIME_A, Stonums.RADINITE_A, slimeDriver: SlimeEmotions.Emotion.NONE);
        }

        public static void RegisterMegaB()
        {
            SlimeAppearance.Palette radPalette = Slime.GetSlimeDef(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].ColorPalette;
            megaRadSlimeB = Slime.CreateSlime(Identifiable.Id.RAD_SLIME, Identifiable.Id.RAD_SLIME, Evonums.MEGA_RAD_SLIME_B, "Mega Rad Slime (B)", LoadResource<Sprite>("iconSlimeRad"), radPalette.Ammo, radPalette.Top, radPalette.Middle, radPalette.Bottom, radPalette.Ammo, Vacuumable.Size.LARGE);

            SlimeDefinition mRadDefB = megaRadSlimeB.Item1;
            GameObject mRadObjB = megaRadSlimeB.Item2;
            SlimeAppearance mRadAppB = megaRadSlimeB.Item3;

            mRadDefB.Diet.Produces = new Identifiable.Id[] { Identifiable.Id.RAD_PLORT, Identifiable.Id.RAD_PLORT, Identifiable.Id.RAD_PLORT };
            mRadDefB.Diet.FavoriteProductionCount = 5;

            mRadDefB.CanLargofy = false;

            mRadObjB.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            mRadObjB.GetComponent<SlimeHealth>().maxHealth = 38;

            SlimeAppearance.SlimeBone[] attachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };

            personBubbleAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "radPersonBubble", "slime_person_bubble", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime);
            personBubbleAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimePersonBubble", mRadAppB, new SlimeAppearanceObject[] { personBubbleAttachment.Item2 }, 1);

            mRadAppB.Structures[1].DefaultMaterials[0] = Slime.GetSlimeDef(Identifiable.Id.RAD_SLIME).GetSlimeMat(1);

            EatMap.CreateBecomeMap(Identifiable.Id.RAD_SLIME, Evonums.MEGA_RAD_SLIME_B, Stonums.RADINITE_B, slimeDriver: SlimeEmotions.Emotion.NONE);
        }
    }
}
