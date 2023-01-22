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
    internal class MegaPuddleSlime
    {
        internal static (SlimeDefinition, GameObject, SlimeAppearance) megaPuddleSlime;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) crownAttachment;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) orbAttachment;

        public static void RegisterMega()
        {
            SlimeAppearance.Palette puddlePalette = Slime.GetSlimeDef(Identifiable.Id.PUDDLE_SLIME).AppearancesDefault[0].ColorPalette;
            megaPuddleSlime = Slime.CreateSlime(Identifiable.Id.PUDDLE_SLIME, Identifiable.Id.PUDDLE_SLIME, Evonums.MEGA_PUDDLE_SLIME, "Mega Puddle Slime", LoadResource<Sprite>("iconSlimePuddle"), puddlePalette.Ammo, puddlePalette.Top, puddlePalette.Middle, puddlePalette.Bottom, puddlePalette.Ammo, Vacuumable.Size.LARGE);

            SlimeDefinition mPuddleDef = megaPuddleSlime.Item1;
            GameObject mPuddleObj = megaPuddleSlime.Item2;
            SlimeAppearance mPuddleApp = megaPuddleSlime.Item3;

            mPuddleDef.Diet.Produces = new Identifiable.Id[] { Identifiable.Id.PUDDLE_PLORT, Identifiable.Id.PUDDLE_PLORT, Identifiable.Id.PUDDLE_PLORT };
            mPuddleDef.Diet.FavoriteProductionCount = 5;

            mPuddleDef.CanLargofy = false;

            mPuddleObj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            UnityEngine.Object.Destroy(mPuddleObj.GetComponent<DestroyOnTouching>());

            SlimeAppearance.SlimeBone[] attachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };

            crownAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "puddleCrown", "slime_crown", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime);
            crownAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimeCrown", mPuddleApp, new SlimeAppearanceObject[] { crownAttachment.Item2 }, 1);

            orbAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "puddleOrbs", "slime_wOrbs", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime, false, true);
            orbAttachment.Item2.IgnoreLODIndex = true;
            orbAttachment.Item1.AddComponent<vp_Spin>().RotationSpeed = new Vector3(0f, 130f, 0f);
            Structure.SetStructureElement("slimeWOrbs", mPuddleApp, new SlimeAppearanceObject[] { orbAttachment.Item2 }, 2);

            Material crownMat = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.RAD_SLIME).GetSlimeMat(1));
            crownMat.SetColor("_MiddleColor", Color.white);
            crownMat.SetColor("_EdgeColor", Color.yellow);
            Material wOrbsMat = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.RAD_SLIME).GetSlimeMat(1));
            wOrbsMat.SetColor("_MiddleColor", Color.blue);
            wOrbsMat.SetColor("_EdgeColor", Color.cyan);

            mPuddleApp.Structures[0].DefaultMaterials[0] = wOrbsMat;
            mPuddleApp.Structures[1].DefaultMaterials[0] = crownMat;
            mPuddleApp.Structures[2].DefaultMaterials[0] = wOrbsMat;

            EatMap.CreateBecomeMap(Identifiable.Id.PUDDLE_SLIME, Evonums.MEGA_PUDDLE_SLIME, Stonums.PUDDINITE, slimeDriver: SlimeEmotions.Emotion.NONE);
        }
    }
}
