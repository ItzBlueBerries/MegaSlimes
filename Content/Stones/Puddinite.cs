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
    internal class Puddinite
    {
        internal static GameObject puddinite;
        internal static Material puddiniteMat;

        public static void RegisterPuddinite()
        {
            SlimeAppearance.Palette puddlePalette = Slime.GetSlimeDef(Identifiable.Id.PUDDLE_SLIME).AppearancesDefault[0].ColorPalette;
            puddiniteMat = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PINK_SLIME).GetSlimeMat(0));
            puddiniteMat.shader = Shader.Find("SR/Paintlight/Basic");
            puddiniteMat.SetTexture("_PrimaryTex", LoadImage("Assets.stone_tex.puddinite_tex"));

            puddinite = Other.CreateMeshObject("Puddinite", (Mesh)Other.LoadAsset(typeof(Mesh), Bundles.external_models, "stoneBase"), typeof(SphereCollider), puddiniteMat);

            puddinite.AddComponent<Rigidbody>();
            puddinite.AddComponent<RegionMember>();
            puddinite.AddComponent<Identifiable>().id = Stonums.PUDDINITE;
            puddinite.AddComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Registry.RegisterIdentPrefab(puddinite);
            Registry.RegisterPedia(Stonums.PUDDINITE_PEDIA, Stonums.PUDDINITE);

            Translate.TranslatePedia("t." + Stonums.PUDDINITE.ToString().ToLower(), "Puddinite");
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, puddinite);
            Registry.RegisterVac(puddlePalette.Ammo, Stonums.PUDDINITE, CreateSprite(LoadImage("Assets.stone_ico.puddinite_ico")), "puddiniteDefinition");
        }

        public static void PreRegisterPuddinite()
        {
            Translate.CreateResourcePedia(Stonums.PUDDINITE, Stonums.PUDDINITE_PEDIA, CreateSprite(LoadImage("Assets.stone_ico.puddinite_ico")),
                "Puddinite",
                "One of various Mega Stones, we call the Puddinite.",
                "Mega Stone",
                "Puddle Slime",
                "One of a variety of mysterious Mega Stones. Have Puddle eat it, and this stone will enable it to Mega Evolve via its own inner friendship."
            );
        }
    }
}
