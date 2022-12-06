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
    internal class Rockite
    {
        internal static GameObject rockite_a;
        internal static Material rockite_aMat;
        internal static GameObject rockite_b;
        internal static Material rockite_bMat;

        public static void RegisterRockite()
        {
            #region ROCKITE_A
            SlimeAppearance.Palette rockPalette = Slime.GetSlimeDef(Identifiable.Id.ROCK_SLIME).AppearancesDefault[0].ColorPalette;
            rockite_aMat = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PINK_SLIME).GetSlimeMat(0));
            rockite_aMat.shader = Shader.Find("SR/Paintlight/Basic");
            rockite_aMat.SetTexture("_PrimaryTex", LoadImage("Assets.stone_tex.rockite_a_tex"));

            rockite_a = Other.CreateMeshObject("Rockite_A", (Mesh)Other.LoadAsset(typeof(Mesh), Bundles.external_models, "stoneBase"), typeof(SphereCollider), rockite_aMat);

            rockite_a.AddComponent<Rigidbody>();
            rockite_a.AddComponent<RegionMember>();
            rockite_a.AddComponent<Identifiable>().id = Stonums.ROCKITE_A;
            rockite_a.AddComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Registry.RegisterIdentPrefab(rockite_a);
            Registry.RegisterPedia(Stonums.ROCKITE_A_PEDIA, Stonums.ROCKITE_A);

            Translate.TranslatePedia("t." + Stonums.ROCKITE_A.ToString().ToLower(), "Rockite A");
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, rockite_a);
            Registry.RegisterVac(Color.grey, Stonums.ROCKITE_A, CreateSprite(LoadImage("Assets.stone_ico.rockite_a_ico")), "rockiteADefinition");
            #endregion

            #region ROCKITE_B
            rockite_bMat = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PINK_SLIME).GetSlimeMat(0));
            rockite_bMat.shader = Shader.Find("SR/Paintlight/Basic");
            rockite_bMat.SetTexture("_PrimaryTex", LoadImage("Assets.stone_tex.rockite_b_tex"));

            rockite_b = Other.CreateMeshObject("Rockite_B", (Mesh)Other.LoadAsset(typeof(Mesh), Bundles.external_models, "stoneBase"), typeof(SphereCollider), rockite_bMat);

            rockite_b.AddComponent<Rigidbody>();
            rockite_b.AddComponent<RegionMember>();
            rockite_b.AddComponent<Identifiable>().id = Stonums.ROCKITE_B;
            rockite_b.AddComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Registry.RegisterIdentPrefab(rockite_b);
            Registry.RegisterPedia(Stonums.ROCKITE_B_PEDIA, Stonums.ROCKITE_B);

            Translate.TranslatePedia("t." + Stonums.ROCKITE_B.ToString().ToLower(), "Rockite B");
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, rockite_b);
            Registry.RegisterVac(rockPalette.Ammo, Stonums.ROCKITE_B, CreateSprite(LoadImage("Assets.stone_ico.rockite_b_ico")), "rockiteBDefinition");
            #endregion
        }

        public static void PreRegisterRockite()
        {
            #region ROCKITE_A
            Translate.CreateResourcePedia(Stonums.ROCKITE_A, Stonums.ROCKITE_A_PEDIA, CreateSprite(LoadImage("Assets.stone_ico.rockite_a_ico")),
                "Rockite A",
                "One of various Mega Stones, we call the Rockite A.",
                "Mega Stone",
                "Rock Slime",
                "One of a variety of mysterious Mega Stones. Have Rock eat it, and this stone will enable it to Mega Evolve via its own inner friendship."
            );
            #endregion

            #region ROCKITE_B
            Translate.CreateResourcePedia(Stonums.ROCKITE_B, Stonums.ROCKITE_B_PEDIA, CreateSprite(LoadImage("Assets.stone_ico.rockite_b_ico")),
                "Rockite B",
                "One of various Mega Stones, we call the Rockite B.",
                "Mega Stone",
                "Rock Slime",
                "One of a variety of mysterious Mega Stones. Have Rock eat it, and this stone will enable it to Mega Evolve via its own inner friendship."
            );
            #endregion
        }
    }
}
