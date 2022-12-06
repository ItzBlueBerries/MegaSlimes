using MegaSlimes.Content;
using SRML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ShortcutLib.Shortcut;

namespace MegaSlimes
{
    public class Main : ModEntryPoint
    {
        // Called before GameContext.Awake
        // You want to register new things and enum values here, as well as do all your harmony patching
        public override void PreLoad()
        {
            HarmonyInstance.PatchAll();

            Pinkinite.PreRegisterPinkinite();
            Tabbinite.PreRegisterTabbinite();
            Rockite.PreRegisterRockite();
            Phosphorite.PreRegisterPhosphorite();
        }


        // Called before GameContext.Start
        // Used for registering things that require a loaded gamecontext
        public override void Load()
        {
            Pinkinite.RegisterPinkinite();
            Tabbinite.RegisterTabbinite();
            Rockite.RegisterRockite();
            Phosphorite.RegisterPhosphorite();

            StoneDriller_Tier1.RegisterTier();

            MegaPinkSlime.RegisterMega();
            MegaTabbySlime.RegisterMega();
            MegaRockSlime.RegisterMegaA();
            MegaRockSlime.RegisterMegaB();
            MegaPhosphorSlime.RegisterMega();
        }

        // Called after all mods Load's have been called
        // Used for editing existing assets in the game, not a registry step
        public override void PostLoad()
        {

        }

    }
}