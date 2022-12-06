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
    internal class MegaRockSlime
    {
        internal static (SlimeDefinition, GameObject, SlimeAppearance) megaRockSlimeA;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) spinesAttachment;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) floatingRocksAttachment;
        internal static (SlimeDefinition, GameObject, SlimeAppearance) megaRockSlimeB;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) headRocksAttachment;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) shieldAttachment;

        public static void RegisterMegaA()
        {
            SlimeAppearance.Palette rockPalette = Slime.GetSlimeDef(Identifiable.Id.ROCK_SLIME).AppearancesDefault[0].ColorPalette;
            megaRockSlimeA = Slime.CreateSlime(Identifiable.Id.ROCK_SLIME, Identifiable.Id.ROCK_SLIME, Evonums.MEGA_ROCK_SLIME_A, "Mega Rock Slime (A)", LoadResource<Sprite>("iconSlimeRock"), rockPalette.Ammo, rockPalette.Top, rockPalette.Middle, rockPalette.Bottom, rockPalette.Ammo, Vacuumable.Size.LARGE);

            SlimeDefinition mRockDefA = megaRockSlimeA.Item1;
            GameObject mRockObjA = megaRockSlimeA.Item2;
            SlimeAppearance mRockAppA = megaRockSlimeA.Item3;

            mRockDefA.Diet.Produces = new Identifiable.Id[] { Identifiable.Id.ROCK_PLORT, Identifiable.Id.ROCK_PLORT, Identifiable.Id.ROCK_PLORT };
            mRockDefA.Diet.FavoriteProductionCount = 5;

            mRockDefA.CanLargofy = false;

            mRockObjA.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            mRockObjA.GetComponent<DamagePlayerOnTouch>().damagePerTouch = 50;
            mRockObjA.GetComponent<SlimeHealth>().maxHealth = 16;

            SlimeAppearance.SlimeBone[] attachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };

            spinesAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "rockSpines", "slime_spines", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime);
            spinesAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimeSpines", mRockAppA, new SlimeAppearanceObject[] { spinesAttachment.Item2 }, 1);

            floatingRocksAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "rockFloatingRocks", "slime_floating_rocks", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime, false, true);
            floatingRocksAttachment.Item2.IgnoreLODIndex = true;
            floatingRocksAttachment.Item1.AddComponent<vp_Spin>().RotationSpeed = new Vector3(0, 130, 0);
            Structure.SetStructureElement("slimeFloatingRocks", mRockAppA, new SlimeAppearanceObject[] { floatingRocksAttachment.Item2 }, 2);

            mRockAppA.Structures[1].DefaultMaterials[0] = Slime.GetSlimeDef(Identifiable.Id.ROCK_SLIME).GetSlimeMat(1);
            mRockAppA.Structures[2].DefaultMaterials[0] = Slime.GetSlimeDef(Identifiable.Id.ROCK_SLIME).GetSlimeMat(1);
        }

        public static void RegisterMegaB()
        {
            SlimeAppearance.Palette rockPalette = Slime.GetSlimeDef(Identifiable.Id.ROCK_SLIME).AppearancesDefault[0].ColorPalette;
            megaRockSlimeB = Slime.CreateSlime(Identifiable.Id.ROCK_SLIME, Identifiable.Id.ROCK_SLIME, Evonums.MEGA_ROCK_SLIME_B, "Mega Rock Slime (B)", LoadResource<Sprite>("iconSlimeRock"), rockPalette.Ammo, rockPalette.Top, rockPalette.Middle, rockPalette.Bottom, rockPalette.Ammo, Vacuumable.Size.LARGE);

            SlimeDefinition mRockDefB = megaRockSlimeB.Item1;
            GameObject mRockObjB = megaRockSlimeB.Item2;
            SlimeAppearance mRockAppB = megaRockSlimeB.Item3;

            mRockDefB.Diet.Produces = new Identifiable.Id[] { Identifiable.Id.ROCK_PLORT, Identifiable.Id.ROCK_PLORT, Identifiable.Id.ROCK_PLORT };
            mRockDefB.Diet.FavoriteProductionCount = 5;

            mRockDefB.CanLargofy = false;

            mRockObjB.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            UnityEngine.Object.Destroy(mRockObjB.GetComponent<DamagePlayerOnTouch>());
            mRockObjB.GetComponent<SlimeHealth>().maxHealth = 26;

            SlimeAppearance.SlimeBone[] attachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };

            headRocksAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "rockHeadRocks", "slime_head_rocks", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime);
            headRocksAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimeHeadRocks", mRockAppB, new SlimeAppearanceObject[] { headRocksAttachment.Item2 }, 1);

            shieldAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "rockShield", "slime_shield", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime);
            shieldAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimeShield", mRockAppB, new SlimeAppearanceObject[] { shieldAttachment.Item2 }, 2);

            mRockAppB.Structures[1].DefaultMaterials[0] = Slime.GetSlimeDef(Identifiable.Id.ROCK_SLIME).GetSlimeMat(1);
            mRockAppB.Structures[2].DefaultMaterials[0] = Slime.GetSlimeDef(Identifiable.Id.ROCK_SLIME).GetSlimeMat(1);

            EatMap.CreateBecomeMap(Identifiable.Id.ROCK_SLIME, Evonums.MEGA_ROCK_SLIME_A, Stonums.ROCKITE_A, slimeDriver: SlimeEmotions.Emotion.NONE);
            EatMap.CreateBecomeMap(Identifiable.Id.ROCK_SLIME, Evonums.MEGA_ROCK_SLIME_B, Stonums.ROCKITE_B, slimeDriver: SlimeEmotions.Emotion.NONE);
        }
    }
}
