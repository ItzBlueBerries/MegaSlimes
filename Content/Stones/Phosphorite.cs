using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ShortcutLib.Shortcut;
using static MegaSlimes.OtherFunc;
using MonomiPark.SlimeRancher.Regions;
using SRML.SR;

namespace MegaSlimes.Content
{
    internal class Phosphorite
    {
        internal static GameObject phosphorite;
        internal static Material phosphoriteMat;

        public static void RegisterPhosphorite()
        {
            SlimeAppearance.Palette phosphorPalette = Slime.GetSlimeDef(Identifiable.Id.PHOSPHOR_SLIME).AppearancesDefault[0].ColorPalette;
            phosphoriteMat = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PINK_SLIME).GetSlimeMat(0));
            phosphoriteMat.shader = Shader.Find("SR/Paintlight/Basic");
            phosphoriteMat.SetTexture("_PrimaryTex", LoadImage("Assets.stone_tex.phosphorite_tex"));

            phosphorite = Other.CreateMeshObject("Phosphorite", (Mesh)Other.LoadAsset(typeof(Mesh), Bundles.external_models, "stoneBase"), typeof(SphereCollider), phosphoriteMat);

            phosphorite.AddComponent<Rigidbody>();
            phosphorite.AddComponent<RegionMember>();
            phosphorite.AddComponent<Identifiable>().id = Stonums.PHOSPHORITE;
            phosphorite.AddComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Registry.RegisterIdentPrefab(phosphorite);
            Registry.RegisterPedia(Stonums.PHOSPHORITE_PEDIA, Stonums.PHOSPHORITE);

            Translate.TranslatePedia("t." + Stonums.PHOSPHORITE.ToString().ToLower(), "Phosphorite");
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, phosphorite);
            Registry.RegisterVac(phosphorPalette.Ammo, Stonums.PHOSPHORITE, CreateSprite(LoadImage("Assets.stone_ico.phosphorite_ico")), "phosphoriteDefinition");
        }

        public static void PreRegisterPhosphorite()
        {
            Translate.CreateResourcePedia(Stonums.PHOSPHORITE, Stonums.PHOSPHORITE_PEDIA, CreateSprite(LoadImage("Assets.stone_ico.phosphorite_ico")),
                "Phosphorite",
                "One of various Mega Stones, we call the Phosphorite.",
                "Mega Stone",
                "Phosphor Slime",
                "One of a variety of mysterious Mega Stones. Have Phosphor eat it, and this stone will enable it to Mega Evolve via its own inner friendship."
            );
        }
    }
}
