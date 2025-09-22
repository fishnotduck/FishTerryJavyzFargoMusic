using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FishMusicMod
{
    public class MusicSystem : ModSystem
    {
        public static int GetMusic(string name) => MusicLoader.GetMusicSlot(FishMusicMod.Instance, $"Music/{name}");

        private const BindingFlags UniversalBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        public override void Load()
        {
            MonoModHooks.Add(Update, Update_Detour);
        }

        public static int OverrideMusicID(int i)
        {
            if (Main.gameMenu)
                return i;
            int old = i;
            var config = MusicConfig.Instance;
            switch (i)
            {
                case MusicID.TownDay:
                    i = GetMusic("letmeout");
                    TerryMusicSystem.nowPlayingString = "corru.observer - Let Me Out";
                    break;

                case MusicID.TownNight:
                    i = GetMusic("remembrance");
                    TerryMusicSystem.nowPlayingString = "corru.observer - Remembrance";
                    break;

                case MusicID.OverworldDay:
                case MusicID.AltOverworldDay:
                    i = GetMusic("ahomeforflowerstulip");
                    TerryMusicSystem.nowPlayingString = "OMORI - A Home For Flowers (Tulip)";
                    break;

                case MusicID.Night:
                    i = GetMusic("doctor");
                    TerryMusicSystem.nowPlayingString = "Homestuck - Doctor";
                    break;

                case MusicID.WindyDay:
                    i = GetMusic("calmingbeatstoreflectandrelaxto");
                    TerryMusicSystem.nowPlayingString = "TS!Underswap - Calming Beats to Reflect and Relax To";
                    break;

                case MusicID.Underground:
                case MusicID.AltUnderground:
                    i = GetMusic("voidsymphony");
                    TerryMusicSystem.nowPlayingString = "Void Stranger - Void Symphony";
                    break;

                case MusicID.Desert:
                case MusicID.UndergroundDesert:
                    i = GetMusic("ragerave");
                    TerryMusicSystem.nowPlayingString = "Void Stranger - Rage Rave";
                    break;

                case MusicID.Snow:
                case MusicID.Ice:
                    i = GetMusic("moonsetter");
                    TerryMusicSystem.nowPlayingString = "Homestuck - Moonsetter";
                    break;

                case MusicID.Jungle:
                case MusicID.JungleNight:
                case MusicID.JungleUnderground:
                    i = GetMusic("crystalanthemums");
                    TerryMusicSystem.nowPlayingString = "Homestuck - Crystalanthemums";
                    break;

                case MusicID.TheHallow:
                    i = GetMusic("threebarlogos");
                    TerryMusicSystem.nowPlayingString = "OMORI - Three Bar Logos";
                    break;

                case MusicID.UndergroundHallow:
                    i = GetMusic("whitesurfstyle6");
                    TerryMusicSystem.nowPlayingString = "OMORI - White Surf Style 6";
                    break;

                case MusicID.Corruption:
                    i = GetMusic("safesurface");
                    TerryMusicSystem.nowPlayingString = "corru.observer - Safe Surface";
                    break;

                case MusicID.UndergroundCorruption:
                    i = GetMusic("dullvessel");
                    TerryMusicSystem.nowPlayingString = "corru.observer - Dull Vessel";
                    break;

                case MusicID.Crimson:
                    i = GetMusic("outsideinterference");
                    TerryMusicSystem.nowPlayingString = "corru.observer - Outside Interference";
                    break;

                case MusicID.UndergroundCrimson:
                    i = GetMusic("innerworld");
                    TerryMusicSystem.nowPlayingString = "corru.observer - Inner World";
                    break;

                case MusicID.Ocean:
                    i = GetMusic("seasidebeatstotanandrelaxto");
                    TerryMusicSystem.nowPlayingString = "TS!Underswap - Seaside Beats to Tan and Relax To";
                    break;

                case MusicID.OceanNight:
                    i = GetMusic("theirwaters");
                    TerryMusicSystem.nowPlayingString = "corru.observer - Their Waters";
                    break;

                case MusicID.Space:
                case MusicID.SpaceDay:
                    i = GetMusic("breakingfree");
                    TerryMusicSystem.nowPlayingString = "corru.observer - Breaking Free";
                    break;

                case MusicID.Hell:
                    i = GetMusic("avatarbeat");
                    TerryMusicSystem.nowPlayingString = "OFF - Avatar Beat";
                    break;

                case MusicID.Mushrooms:
                    i = GetMusic("arisenanew");
                    TerryMusicSystem.nowPlayingString = "Homestuck - Arisen Anew";
                    break;

                case MusicID.Dungeon:
                    i = GetMusic("unreasonablebehavior");
                    TerryMusicSystem.nowPlayingString = "OFF - Unreasonable Behavior";
                    break;

                case MusicID.Temple:
                    i = GetMusic("gettingtoyourmanager");
                    TerryMusicSystem.nowPlayingString = "Void Stranger - Getting To Your Manager";
                    break;

                case MusicID.Rain:
                case MusicID.MorningRain:
                    i = GetMusic("graynostalgia");
                    TerryMusicSystem.nowPlayingString = "Void Stranger - Gray nostalgia";
                    break;

                case MusicID.Monsoon:
                    i = GetMusic("voidstrangergray");
                    TerryMusicSystem.nowPlayingString = "Void Stranger - Void Stranger Gray";
                    break;

                case MusicID.Graveyard:
                    i = GetMusic("wutheringopus1alternateversion");
                    TerryMusicSystem.nowPlayingString = "Limbus Company - Wuthering Opus 1 (Alternate Version)";
                    break;

                case MusicID.Eerie:
                    i = GetMusic("peppersteak");
                    TerryMusicSystem.nowPlayingString = "OFF - Pepper Steak";
                    break;

                case MusicID.Sandstorm:
                    i = GetMusic("lethallavaland");
                    TerryMusicSystem.nowPlayingString = "Super Mario 64 - Lethal Lava Land";
                    break;

                case MusicID.Shimmer:
                    i = GetMusic("agentsofvoid");
                    TerryMusicSystem.nowPlayingString = "Void Stranger - Agents of Void";
                    break;

                case MusicID.GoblinInvasion:
                    i = GetMusic("skaianskirmish");
                    TerryMusicSystem.nowPlayingString = "Homestuck - Skaian Skirmish";
                    break;

                case MusicID.SlimeRain:
                    i = GetMusic("beelikethat");
                    TerryMusicSystem.nowPlayingString = "Void Stranger - Bee like that";
                    break;

                case MusicID.Boss1:
                    i = GetMusic("vampiresinvadingheaven");
                    TerryMusicSystem.nowPlayingString = "Everhood - Vampires Invading Heaven";
                    break;

                case MusicID.Boss2:
                    i = GetMusic("lostgirl");
                    TerryMusicSystem.nowPlayingString = "deerclops is the knight";
                    break;

                case MusicID.Boss3:
                    if (Main.invasionType == InvasionID.SnowLegion)
                        goto case MusicID.SlimeRain;
                    break;

                case MusicID.Boss4:
                    i = GetMusic("thewallsaretryingtokillme");
                    TerryMusicSystem.nowPlayingString = "corru.observer - The Walls Are Trying To Kill Me";
                    break;

                case MusicID.Boss5:
                    i = GetMusic("castyourselfaside");
                    TerryMusicSystem.nowPlayingString = "corru.observer - Cast Yourself Aside";
                    break;

                case MusicID.PirateInvasion:
                    i = GetMusic("pumpkinpartyinseahitlerswaterapocalypse");
                    TerryMusicSystem.nowPlayingString = "Homestuck - Pumpkin Party in Sea Hitler's Water Apocalypse";
                    break;

                case MusicID.Eclipse:
                    i = GetMusic("themadnessoutside");
                    TerryMusicSystem.nowPlayingString = "corru.observer - The Madness Outside";
                    break;

                case MusicID.PumpkinMoon:
                    i = GetMusic("akubattletheme");
                    TerryMusicSystem.nowPlayingString = "The Battle Cats - Aku Battle Theme";
                    break;

                case MusicID.FrostMoon:
                    i = GetMusic("gingerbreadhouse");
                    TerryMusicSystem.nowPlayingString = "Deltarune - Gingerbread House";
                    break;

                case MusicID.OldOnesArmy:
                    i = GetMusic("battletheme1");
                    TerryMusicSystem.nowPlayingString = "The Battle Cats - Battle Theme #1";
                    break;

                case MusicID.MartianMadness:
                    i = GetMusic("catsofthecosmostheme3");
                    TerryMusicSystem.nowPlayingString = "The Battle Cats - Cats of the Cosmos Theme #3";
                    break;

                case MusicID.Credits:
                    i = GetMusic("grayishasitmaybe");
                    TerryMusicSystem.nowPlayingString = "Void Stranger - Grayish as it may be";
                    break;
            }
            if (i >= Main.musicFade.Length)
                return old;
            return i;
        }

        private static readonly MethodInfo Update = typeof(LegacyAudioSystem).GetMethod("Update", UniversalBindingFlags);
        public delegate void Orig_Update(LegacyAudioSystem self);
        internal static void Update_Detour(Orig_Update orig, LegacyAudioSystem self)
        {
            Main.newMusic = OverrideMusicID(Main.newMusic);
            orig(self);
        }
    }
}
