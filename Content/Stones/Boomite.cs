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
    internal class Boomite
    {
        internal static GameObject boomite;
        internal static Material boomiteMat;

        public static void RegisterBoomite()
        {
            SlimeAppearance.Palette boomPalette = Slime.GetSlimeDef(Identifiable.Id.BOOM_SLIME).AppearancesDefault[0].ColorPalette;
            boomiteMat = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PINK_SLIME).GetSlimeMat(0));
            boomiteMat.shader = Shader.Find("SR/Paintlight/Basic");
            boomiteMat.SetTexture("_PrimaryTex", LoadImage("Assets.stone_tex.boomite_tex"));

            boomite = Other.CreateMeshObject("Boomite", (Mesh)Other.LoadAsset(typeof(Mesh), Bundles.external_models, "stoneBase"), typeof(SphereCollider), boomiteMat);

            boomite.AddComponent<Rigidbody>();
            boomite.AddComponent<RegionMember>();
            boomite.AddComponent<Identifiable>().id = Stonums.BOOMITE;
            boomite.AddComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Registry.RegisterIdentPrefab(boomite);
            Registry.RegisterPedia(Stonums.BOOMITE_PEDIA, Stonums.BOOMITE);

            Translate.TranslatePedia("t." + Stonums.BOOMITE.ToString().ToLower(), "Boomite");
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, boomite);
            Registry.RegisterVac(boomPalette.Ammo, Stonums.BOOMITE, CreateSprite(LoadImage("Assets.stone_ico.boomite_ico")), "boomiteDefinition");
        }

        public static void PreRegisterBoomite()
        {
            Translate.CreateResourcePedia(Stonums.BOOMITE, Stonums.BOOMITE_PEDIA, CreateSprite(LoadImage("Assets.stone_ico.boomite_ico")),
                "Boomite",
                "One of various Mega Stones, we call the Boomite.",
                "Mega Stone",
                "Boom Slime",
                "One of a variety of mysterious Mega Stones. Have Boom eat it, and this stone will enable it to Mega Evolve via its own inner friendship."
            );
        }
    }
}
