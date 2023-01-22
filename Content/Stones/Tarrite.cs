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
    internal class Tarrite
    {
        internal static GameObject tarrite;
        internal static Material tarriteMat;

        public static void RegisterTarrite()
        {
            SlimeAppearance.Palette tarrPalette = Slime.GetSlimeDef(Identifiable.Id.TARR_SLIME).AppearancesDefault[0].ColorPalette;
            tarriteMat = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PINK_SLIME).GetSlimeMat(0));
            tarriteMat.shader = Shader.Find("SR/Paintlight/Basic");
            tarriteMat.SetTexture("_PrimaryTex", LoadImage("Assets.stone_tex.tarrite_tex"));

            tarrite = Other.CreateMeshObject("Tarrite", (Mesh)Other.LoadAsset(typeof(Mesh), Bundles.external_models, "stoneBase"), typeof(SphereCollider), tarriteMat);

            tarrite.AddComponent<Rigidbody>();
            tarrite.AddComponent<RegionMember>();
            tarrite.AddComponent<Identifiable>().id = Stonums.TARRITE;
            tarrite.AddComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Registry.RegisterIdentPrefab(tarrite);
            Registry.RegisterPedia(Stonums.TARRITE_PEDIA, Stonums.TARRITE);

            Translate.TranslatePedia("t." + Stonums.TARRITE.ToString().ToLower(), "Tarrite");
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, tarrite);
            Registry.RegisterVac(tarrPalette.Ammo, Stonums.TARRITE, CreateSprite(LoadImage("Assets.stone_ico.tarrite_ico")), "tarriteDefinition");
        }

        public static void PreRegisterTarrite()
        {
            Translate.CreateResourcePedia(Stonums.TARRITE, Stonums.TARRITE_PEDIA, CreateSprite(LoadImage("Assets.stone_ico.tarrite_ico")),
                "Tarrite",
                "One of various Mega Stones, we call the Tarrite.",
                "Mega Stone",
                "Tarr Slime",
                "One of a variety of mysterious Mega Stones. Have Tarr eat it, and this stone will enable it to Mega Evolve via its own inner bitterness."
            );
        }
    }
}
