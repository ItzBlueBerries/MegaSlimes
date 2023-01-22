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
    internal class MegaTarrSlime
    {
        internal static (SlimeDefinition, GameObject, SlimeAppearance) megaTarrSlime;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) stackAttachment;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) tWingLAttachment;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) tWingRAttachment;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) tTailAttachment;

        public static void RegisterMega()
        {
            SlimeAppearance.Palette tarrPalette = Slime.GetSlimeDef(Identifiable.Id.TARR_SLIME).AppearancesDefault[0].ColorPalette;
            megaTarrSlime = Slime.CreateSlime(Identifiable.Id.TARR_SLIME, Identifiable.Id.PINK_SLIME, Evonums.MEGA_TARR_SLIME, "Mega Tarr Slime", LoadResource<Sprite>("iconSlimeTarr"), tarrPalette.Ammo, tarrPalette.Top, tarrPalette.Middle, tarrPalette.Bottom, tarrPalette.Ammo, Vacuumable.Size.LARGE);

            SlimeDefinition mTarrDef = megaTarrSlime.Item1;
            GameObject mTarrObj = megaTarrSlime.Item2;
            SlimeAppearance mTarrApp = megaTarrSlime.Item3;

            mTarrDef.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[] { SlimeEat.FoodGroup.NONTARRGOLD_SLIMES, SlimeEat.FoodGroup.MEAT };
            mTarrDef.Diet.Produces = new Identifiable.Id[] { Identifiable.Id.TARR_SLIME, Identifiable.Id.TARR_SLIME, Identifiable.Id.TARR_SLIME };
            mTarrDef.Diet.FavoriteProductionCount = 5;

            mTarrDef.CanLargofy = false;

            mTarrObj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            Identifiable.TARR_CLASS.Add(Evonums.MEGA_TARR_SLIME);
            Identifiable.SLIME_CLASS.Remove(Evonums.MEGA_TARR_SLIME);

            UnityEngine.Object.Destroy(mTarrObj.GetComponent<FleeThreats>());
            mTarrObj.AddComponent<TarrBite>();
            mTarrObj.AddComponent<TarrSterilizeOnWater>();
            mTarrObj.AddComponent<SlimeHover>();
            mTarrObj.GetComponent<SlimeHealth>().maxHealth = 50;

            TentacleGrapple component = Prefab.GetPrefab(Identifiable.Id.TARR_SLIME).GetComponent<TentacleGrapple>();
            mTarrObj.AddComponent<TentacleGrapple>().tentaclePrefab = component.tentaclePrefab;

            SlimeAppearance.SlimeBone[] attachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };

            stackAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "tarrStack", "slime_stack", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime);
            stackAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimeStack", mTarrApp, new SlimeAppearanceObject[] { stackAttachment.Item2 }, 1);

            tWingLAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "tarrWingL", "slime_tWingL", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.LeftWing, attachedBones, RubberBoneEffect.RubberType.Slime, false, true);
            tWingLAttachment.Item2.IgnoreLODIndex = true;
            tWingRAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "tarrWingR", "slime_tWingR", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.RightWing, attachedBones, RubberBoneEffect.RubberType.Slime, false, true);
            tWingRAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimeTWings", mTarrApp, new SlimeAppearanceObject[] { tWingLAttachment.Item2, tWingRAttachment.Item2 }, 2);

            tTailAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "tarrTail", "slime_tTail", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime);
            tTailAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimetTail", mTarrApp, new SlimeAppearanceObject[] { tTailAttachment.Item2 }, 3);

            Material darkGreyMat = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PINK_SLIME).GetSlimeMat(0));
            darkGreyMat.SetSlimeColor(Other.LoadHex("#333333"), Other.LoadHex("#333333"), Other.LoadHex("#333333"));

            mTarrApp.Structures[1].DefaultMaterials[0] = mTarrApp.Structures[0].DefaultMaterials[0];
            mTarrApp.Structures[2].DefaultMaterials[0] = darkGreyMat;
            mTarrApp.Structures[3].DefaultMaterials[0] = darkGreyMat;

            EatMap.CreateBecomeMap(Identifiable.Id.TARR_SLIME, Evonums.MEGA_TARR_SLIME, Stonums.TARRITE, slimeDriver: SlimeEmotions.Emotion.NONE);
        }
    }
}
