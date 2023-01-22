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
    internal class Dervishite
    {
        internal static GameObject dervishite;
        internal static Material dervishiteMat;

        public static void RegisterDervishite()
        {
            SlimeAppearance.Palette dervishPalette = Slime.GetSlimeDef(Identifiable.Id.DERVISH_SLIME).AppearancesDefault[0].ColorPalette;
            dervishiteMat = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PINK_SLIME).GetSlimeMat(0));
            dervishiteMat.shader = Shader.Find("SR/Paintlight/Basic");
            dervishiteMat.SetTexture("_PrimaryTex", LoadImage("Assets.stone_tex.dervishite_tex"));

            dervishite = Other.CreateMeshObject("Dervishite", (Mesh)Other.LoadAsset(typeof(Mesh), Bundles.external_models, "stoneBase"), typeof(SphereCollider), dervishiteMat);

            dervishite.AddComponent<Rigidbody>();
            dervishite.AddComponent<RegionMember>();
            dervishite.AddComponent<Identifiable>().id = Stonums.DERVISHITE;
            dervishite.AddComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Registry.RegisterIdentPrefab(dervishite);
            Registry.RegisterPedia(Stonums.DERVISHITE_PEDIA, Stonums.DERVISHITE);

            Translate.TranslatePedia("t." + Stonums.DERVISHITE.ToString().ToLower(), "Dervishite");
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, dervishite);
            Registry.RegisterVac(dervishPalette.Ammo, Stonums.DERVISHITE, CreateSprite(LoadImage("Assets.stone_ico.dervishite_ico")), "dervishiteDefinition");
        }

        public static void PreRegisterDervishite()
        {
            Translate.CreateResourcePedia(Stonums.DERVISHITE, Stonums.DERVISHITE_PEDIA, CreateSprite(LoadImage("Assets.stone_ico.dervishite_ico")),
                "Dervishite",
                "One of various Mega Stones, we call the Dervishite.",
                "Mega Stone",
                "Dervish Slime",
                "One of a variety of mysterious Mega Stones. Have Dervish eat it, and this stone will enable it to Mega Evolve via its own inner friendship."
            );
        }
    }
}
