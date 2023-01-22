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
    internal class Radinite
    {
        internal static GameObject radinite_a;
        internal static Material radinite_aMat;
        internal static GameObject radinite_b;
        internal static Material radinite_bMat;

        public static void RegisterRadinite()
        {
            #region RADINITE_A
            SlimeAppearance.Palette radPalette = Slime.GetSlimeDef(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].ColorPalette;
            radinite_aMat = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PINK_SLIME).GetSlimeMat(0));
            radinite_aMat.shader = Shader.Find("SR/Paintlight/Basic");
            radinite_aMat.SetTexture("_PrimaryTex", LoadImage("Assets.stone_tex.radinite_a_tex"));

            radinite_a = Other.CreateMeshObject("Radinite_A", (Mesh)Other.LoadAsset(typeof(Mesh), Bundles.external_models, "stoneBase"), typeof(SphereCollider), radinite_aMat);

            radinite_a.AddComponent<Rigidbody>();
            radinite_a.AddComponent<RegionMember>();
            radinite_a.AddComponent<Identifiable>().id = Stonums.RADINITE_A;
            radinite_a.AddComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Registry.RegisterIdentPrefab(radinite_a);
            Registry.RegisterPedia(Stonums.RADINITE_A_PEDIA, Stonums.RADINITE_A);

            Translate.TranslatePedia("t." + Stonums.RADINITE_A.ToString().ToLower(), "Radinite A");
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, radinite_a);
            Registry.RegisterVac(radPalette.Ammo, Stonums.RADINITE_A, CreateSprite(LoadImage("Assets.stone_ico.radinite_a_ico")), "radiniteADefinition");
            #endregion

            #region RADINITE_B
            radinite_bMat = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PINK_SLIME).GetSlimeMat(0));
            radinite_bMat.shader = Shader.Find("SR/Paintlight/Basic");
            radinite_bMat.SetTexture("_PrimaryTex", LoadImage("Assets.stone_tex.radinite_b_tex"));

            radinite_b = Other.CreateMeshObject("Radinite_B", (Mesh)Other.LoadAsset(typeof(Mesh), Bundles.external_models, "stoneBase"), typeof(SphereCollider), radinite_bMat);

            radinite_b.AddComponent<Rigidbody>();
            radinite_b.AddComponent<RegionMember>();
            radinite_b.AddComponent<Identifiable>().id = Stonums.RADINITE_B;
            radinite_b.AddComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Registry.RegisterIdentPrefab(radinite_b);
            Registry.RegisterPedia(Stonums.RADINITE_B_PEDIA, Stonums.RADINITE_B);

            Translate.TranslatePedia("t." + Stonums.RADINITE_B.ToString().ToLower(), "Radinite B");
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, radinite_b);
            Registry.RegisterVac(Color.green, Stonums.RADINITE_B, CreateSprite(LoadImage("Assets.stone_ico.radinite_b_ico")), "radiniteBDefinition");
            #endregion
        }

        public static void PreRegisterRadinite()
        {
            #region RADINITE_A
            Translate.CreateResourcePedia(Stonums.RADINITE_A, Stonums.RADINITE_A_PEDIA, CreateSprite(LoadImage("Assets.stone_ico.radinite_a_ico")),
                "Radinite A",
                "One of various Mega Stones, we call the Radinite A.",
                "Mega Stone",
                "Rad Slime",
                "One of a variety of mysterious Mega Stones. Have Rad eat it, and this stone will enable it to Mega Evolve via its own inner friendship."
            );
            #endregion

            #region RADINITE_B
            Translate.CreateResourcePedia(Stonums.RADINITE_B, Stonums.RADINITE_B_PEDIA, CreateSprite(LoadImage("Assets.stone_ico.radinite_b_ico")),
                "Radinite B",
                "One of various Mega Stones, we call the Radinite B.",
                "Mega Stone",
                "Rad Slime",
                "One of a variety of mysterious Mega Stones. Have Rad eat it, and this stone will enable it to Mega Evolve via its own inner friendship."
            );
            #endregion
        }
    }
}
