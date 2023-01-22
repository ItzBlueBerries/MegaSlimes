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
    internal class MegaBoomSlime
    {
        internal static (SlimeDefinition, GameObject, SlimeAppearance) megaBoomSlime;
        // internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) coneAttachment;
        internal static (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) handAttachment;

        public static void RegisterMega()
        {
            SlimeAppearance.Palette boomPalette = Slime.GetSlimeDef(Identifiable.Id.BOOM_SLIME).AppearancesDefault[0].ColorPalette;
            megaBoomSlime = Slime.CreateSlime(Identifiable.Id.BOOM_SLIME, Identifiable.Id.BOOM_SLIME, Evonums.MEGA_BOOM_SLIME, "Mega Boom Slime", LoadResource<Sprite>("iconSlimeBoom"), boomPalette.Ammo, boomPalette.Top, boomPalette.Middle, boomPalette.Bottom, boomPalette.Ammo, Vacuumable.Size.LARGE);

            SlimeDefinition mBoomDef = megaBoomSlime.Item1;
            GameObject mBoomObj = megaBoomSlime.Item2;
            SlimeAppearance mBoomApp = megaBoomSlime.Item3;

            mBoomDef.Diet.Produces = new Identifiable.Id[] { Identifiable.Id.BOOM_PLORT, Identifiable.Id.BOOM_PLORT, Identifiable.Id.BOOM_PLORT };
            mBoomDef.Diet.FavoriteProductionCount = 5;

            mBoomDef.CanLargofy = false;

            mBoomObj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            mBoomObj.GetComponent<SlimeHealth>().maxHealth = 23;

            SlimeAppearance.SlimeBone[] attachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };

            handAttachment = Structure.CreateBasicStructure(Bundles.evo_structures, "boomHands", "slime_hands", SlimeAppearance.SlimeBone.JiggleTop, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime);
            handAttachment.Item2.IgnoreLODIndex = true;
            Structure.SetStructureElement("slimeArms", mBoomApp, new SlimeAppearanceObject[] { handAttachment.Item2 }, 1);

            mBoomApp.Structures[1].DefaultMaterials[0] = mBoomApp.Structures[0].DefaultMaterials[0];

            EatMap.CreateBecomeMap(Identifiable.Id.BOOM_SLIME, Evonums.MEGA_BOOM_SLIME, Stonums.BOOMITE, slimeDriver: SlimeEmotions.Emotion.NONE);
        }
    }
}
