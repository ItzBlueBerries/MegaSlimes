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
    internal class Tabbinite
    {
        internal static GameObject tabbinite;
        internal static Material tabbiniteMat;

        public static void RegisterTabbinite()
        {
            SlimeAppearance.Palette tabbyPalette = Slime.GetSlimeDef(Identifiable.Id.TABBY_SLIME).AppearancesDefault[0].ColorPalette;
            tabbiniteMat = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PINK_SLIME).GetSlimeMat(0));
            tabbiniteMat.shader = Shader.Find("SR/Paintlight/Basic");
            tabbiniteMat.SetTexture("_PrimaryTex", LoadImage("Assets.stone_tex.tabbinite_tex"));

            tabbinite = Other.CreateMeshObject("Tabbinite", (Mesh)Other.LoadAsset(typeof(Mesh), Bundles.external_models, "stoneBase"), typeof(SphereCollider), tabbiniteMat);

            tabbinite.AddComponent<Rigidbody>();
            tabbinite.AddComponent<RegionMember>();
            tabbinite.AddComponent<Identifiable>().id = Stonums.TABBINITE;
            tabbinite.AddComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Registry.RegisterIdentPrefab(tabbinite);
            Registry.RegisterPedia(Stonums.TABBINITE_PEDIA, Stonums.TABBINITE);

            Translate.TranslatePedia("t." + Stonums.TABBINITE.ToString().ToLower(), "Tabbinite");
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, tabbinite);
            Registry.RegisterVac(tabbyPalette.Ammo, Stonums.TABBINITE, CreateSprite(LoadImage("Assets.stone_ico.tabbinite_ico")), "tabbiniteDefinition");
        }

        public static void PreRegisterTabbinite()
        {
            Translate.CreateResourcePedia(Stonums.TABBINITE, Stonums.TABBINITE_PEDIA, CreateSprite(LoadImage("Assets.stone_ico.tabbinite_ico")),
                "Tabbinite",
                "One of various Mega Stones, we call the Tabbinite.",
                "Mega Stone",
                "Tabby Slime",
                "One of a variety of mysterious Mega Stones. Have Tabby eat it, and this stone will enable it to Mega Evolve via its own inner friendship."
            );
        }
    }
}
