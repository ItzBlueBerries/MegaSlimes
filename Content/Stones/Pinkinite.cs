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
    internal class Pinkinite
    {
        internal static GameObject pinkinite;
        internal static Material pinkiniteMat;

        public static void RegisterPinkinite()
        {
            SlimeAppearance.Palette pinkPalette = Slime.GetSlimeDef(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].ColorPalette;
            pinkiniteMat = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PINK_SLIME).GetSlimeMat(0));
            pinkiniteMat.shader = Shader.Find("SR/Paintlight/Basic");
            pinkiniteMat.SetTexture("_PrimaryTex", LoadImage("Assets.stone_tex.pinkinite_tex"));

            pinkinite = Other.CreateMeshObject("Pinkinite", (Mesh)Other.LoadAsset(typeof(Mesh), Bundles.external_models, "stoneBase"), typeof(SphereCollider), pinkiniteMat);
            
            pinkinite.AddComponent<Rigidbody>();
            pinkinite.AddComponent<RegionMember>();
            pinkinite.AddComponent<Identifiable>().id = Stonums.PINKINITE;
            pinkinite.AddComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Registry.RegisterIdentPrefab(pinkinite);
            Registry.RegisterPedia(Stonums.PINKINITE_PEDIA, Stonums.PINKINITE);

            Translate.TranslatePedia("t." + Stonums.PINKINITE.ToString().ToLower(), "Pinkinite");
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, pinkinite);
            Registry.RegisterVac(pinkPalette.Ammo, Stonums.PINKINITE, CreateSprite(LoadImage("Assets.stone_ico.pinkinite_ico")), "pinkiniteDefinition");
        }

        public static void PreRegisterPinkinite()
        {
            Translate.CreateResourcePedia(Stonums.PINKINITE, Stonums.PINKINITE_PEDIA, CreateSprite(LoadImage("Assets.stone_ico.pinkinite_ico")),
                "Pinkinite",
                "One of various Mega Stones, we call the Pinkinite.",
                "Mega Stone",
                "Pink Slime",
                "One of a variety of mysterious Mega Stones. Have Pink eat it, and this stone will enable it to Mega Evolve via its own inner friendship."
            );
        }
    }
}
