using System.Linq;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Events;
using static Terraria.Main;
using Microsoft.CodeAnalysis;
using System;

namespace FishMusicMod
{
    static class MusicUtils
    {
        private static Mod souls = null;
        private static bool checkedSouls = false;
        public static Mod Souls
        {
            get
            {
                if (!checkedSouls)
                {
                    checkedSouls = true;
                    if (ModLoader.HasMod("FargowiltasSouls"))
                        souls = ModLoader.GetMod("FargowiltasSouls");
                }
                return souls;
            }
        }
        public static NPC FindClosestBoss(int type)
        {
            float num = 99999;
            NPC closestNPC = null;
            foreach (NPC npc in npc.Where(n => n != null && n.active && n.type == type))
            {
                if (npc.BossMusicRange() && npc.Distance(LocalPlayer.Center) < num)
                {
                    num = npc.Distance(LocalPlayer.Center);
                    closestNPC = npc;
                }
            }
            return closestNPC;
        }

        public static NPC FindClosestSoulsBoss(string name)
        {
            if (MusicUtils.Souls == null)
                return null;
            return FindClosestBoss(Souls.Find<ModNPC>(name).Type);
        }

        public static bool ZoneShallow(this Player player) => player.ZoneDirtLayerHeight || player.ZoneOverworldHeight;

        public static bool ZoneUnderground(this Player player) => player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight;

        public static bool BossMusicRange(this NPC npc)
        {
            int range = 5500;
            Rectangle value = new Rectangle((int)(npc.position.X + (float)(npc.width / 2)) - range, (int)(npc.position.Y + (float)(npc.height / 2)) - range, range * 2, range * 2);
            Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
            return (rectangle.Intersects(value));
        }

        public static bool AnyPillarsInRange()
        {
            int[] pillarTypes = [
                NPCID.LunarTowerSolar,
                NPCID.LunarTowerVortex,
                NPCID.LunarTowerNebula,
                NPCID.LunarTowerStardust,
            ];
            return Main.npc.Any(npc => npc.active && pillarTypes.Contains(npc.type) && BossMusicRange(npc));
        }

    }

    public class VanillaMusic : ModSystem
    {
        public static int Current = 0;
        // This is the entire vanilla music choice method. Edited to update CurrentVanillaMusic rather than Main.curMusic.
        #region Vanilla Music Update
        public override void PostUpdateEverything()
        {
            return;
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            bool flag5 = false;
            bool flag6 = false;
            bool flag7 = false;
            bool flag8 = false;
            bool flag9 = false;
            bool flag10 = false;
            bool flag11 = false;
            bool flag12 = false;
            bool flag13 = false;
            bool flag14 = false;
            bool flag15 = false;
            bool flag16 = false;
            bool flag17 = false;
            bool flag18 = LocalPlayer.townNPCs > 2f;
            bool flag19 = slimeRain;
            if (Main.SceneMetrics.ShadowCandleCount > 0 || LocalPlayer.inventory[LocalPlayer.selectedItem].type == 5322)
            {
                flag18 = false;
            }
            float num = 0f;
            /*
            for (int i = 0; i < maxMusic; i++)
            {
                if (musicFade[i] > num)
                {
                    num = musicFade[i];
                    if (num == 1f)
                    {
                        lastMusicPlayed = i;
                    }
                }
            }
            */
            /*
            if (lastMusicPlayed == 50)
            {
                musicNoCrossFade[51] = true;
            }
            */
            if (!showSplash)
            {
                Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle((int)screenPosition.X, (int)screenPosition.Y, screenWidth, screenHeight);
                int num2 = 5000;
                for (int j = 0; j < 200; j++)
                {
                    if (!npc[j].active)
                    {
                        continue;
                    }
                    num2 = 5000;
                    int num3 = 0;
                    switch (npc[j].type)
                    {
                        case 13:
                        case 14:
                        case 15:
                        case 127:
                        case 128:
                        case 129:
                        case 130:
                        case 131:
                            num3 = 1;
                            break;
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 111:
                        case 471:
                            num3 = 11;
                            break;
                        case 113:
                        case 114:
                        case 125:
                        case 126:
                            num3 = 2;
                            break;
                        case 134:
                        case 135:
                        case 136:
                        case 143:
                        case 144:
                        case 145:
                        case 266:
                            num3 = 3;
                            break;
                        case 212:
                        case 213:
                        case 214:
                        case 215:
                        case 216:
                        case 491:
                            num3 = 8;
                            break;
                        case 245:
                            num3 = 4;
                            break;
                        case 222:
                            num3 = 5;
                            break;
                        case 262:
                        case 263:
                        case 264:
                            num3 = 6;
                            break;
                        case 381:
                        case 382:
                        case 383:
                        case 385:
                        case 386:
                        case 388:
                        case 389:
                        case 390:
                        case 391:
                        case 395:
                        case 520:
                            num3 = 9;
                            break;
                        case 398:
                            num3 = 7;
                            break;
                        case 422:
                        case 493:
                        case 507:
                        case 517:
                            num3 = 10;
                            break;
                        case 439:
                            num3 = 4;
                            break;
                        case 438:
                            if (npc[j].ai[1] == 1f)
                            {
                                num2 = 1600;
                                num3 = 4;
                            }
                            break;
                        case 657:
                            num3 = 13;
                            break;
                        case 636:
                            num3 = 14;
                            break;
                        case 370:
                            num3 = 15;
                            break;
                        case 668:
                            num3 = 16;
                            break;
                    }
                    if (NPCID.Sets.BelongsToInvasionOldOnesArmy[npc[j].type])
                    {
                        num3 = 12;
                    }
                    if (num3 == 0 && npc[j].boss)
                    {
                        num3 = 1;
                    }
                    if (remixWorld && getGoodWorld && (npc[j].type == 127 || npc[j].type == 134 || npc[j].type == 125 || npc[j].type == 126))
                    {
                        num3 = 17;
                    }
                    if (num3 == 0)
                    {
                        continue;
                    }
                    Rectangle value = new Rectangle((int)(npc[j].position.X + (float)(npc[j].width / 2)) - num2, (int)(npc[j].position.Y + (float)(npc[j].height / 2)) - num2, num2 * 2, num2 * 2);
                    if (rectangle.Intersects(value))
                    {
                        switch (num3)
                        {
                            case 1:
                                flag = true;
                                break;
                            case 2:
                                flag3 = true;
                                break;
                            case 3:
                                flag4 = true;
                                break;
                            case 4:
                                flag5 = true;
                                break;
                            case 5:
                                flag6 = true;
                                break;
                            case 6:
                                flag7 = true;
                                break;
                            case 7:
                                flag8 = true;
                                break;
                            case 8:
                                flag9 = true;
                                break;
                            case 9:
                                flag10 = true;
                                break;
                            case 10:
                                flag11 = true;
                                break;
                            case 11:
                                flag12 = true;
                                break;
                            case 12:
                                flag13 = true;
                                break;
                            case 13:
                                flag14 = true;
                                break;
                            case 14:
                                flag15 = true;
                                break;
                            case 15:
                                flag16 = true;
                                break;
                            case 16:
                                flag2 = true;
                                break;
                            case 17:
                                flag17 = true;
                                break;
                        }
                        break;
                    }
                }
            }
            _ = (screenPosition.X + (float)(screenWidth / 2)) / 16f;

            if (musicVolume == 0f)
            {
                Current = 0;
                return;
            }
            if (gameMenu)
            {
                if (netMode != 2)
                {
                    if (WorldGen.drunkWorldGen)
                    {
                        if (WorldGen.remixWorldGen)
                        {
                            Current = 70;
                        }
                        else
                        {
                            Current = 60;
                        }
                    }
                    else if (WorldGen.remixWorldGen)
                    {
                        Current = 8;
                    }
                    else if (menuMode == 3000)
                    {
                        Current = 89;
                    }
                    else if (WorldGen.tenthAnniversaryWorldGen)
                    {
                        Current = 11;
                    }
                    /* these are just menu musics anyway so wont ever be relevant
                    else if (playOldTile)
                    {
                        Current = 6;
                    }
                    else if (!_isAsyncLoadComplete)
                    {
                        Current = 50;
                    }
                    */
                    else if (!audioSystem.IsTrackPlaying(50))
                    {
                        Current = 51;
                        /*
                        if (musicNoCrossFade[51])
                        {
                            musicFade[51] = 1f;
                        }
                        */
                    }
                }
                else
                {
                    Current = 0;
                }
                return;
            }
            float num4 = (float)maxTilesX / 4200f;
            num4 *= num4;
            float num5 = (float)((double)((screenPosition.Y + (float)(screenHeight / 2)) / 16f - (65f + 10f * num4)) / (worldSurface / 5.0));
            if (CreditsRollEvent.IsEventOngoing)
            {
                Current = 89;
            }
            else if (player[myPlayer].happyFunTorchTime)
            {
                Current = 13;
            }
            else if (flag8)
            {
                Current = 38;
            }
            else if (flag17)
            {
                Current = 81;
            }
            else if (flag10)
            {
                Current = 37;
            }
            else if (flag11)
            {
                Current = 34;
            }
            else if (flag7)
            {
                Current = 24;
            }
            else if (flag15)
            {
                Current = 57;
            }
            else if (flag16)
            {
                Current = 58;
            }
            else if (flag3)
            {
                Current = 12;
            }
            else if (flag)
            {
                Current = 5;
            }
            else if (flag4)
            {
                Current = 13;
            }
            else if (flag5)
            {
                Current = 17;
            }
            else if (flag6)
            {
                Current = 25;
            }
            else if (flag14)
            {
                Current = 56;
            }
            else if (flag2)
            {
                Current = 90;
            }
            else if (flag9)
            {
                Current = 35;
            }
            else if (flag12)
            {
                Current = 39;
            }
            else if (flag13)
            {
                Current = 41;
            }
            else if (eclipse && !remixWorld && (double)player[myPlayer].position.Y < worldSurface * 16.0 + (double)(screenHeight / 2))
            {
                Current = 27;
            }
            else if (eclipse && remixWorld && (double)player[myPlayer].position.Y > rockLayer * 16.0)
            {
                Current = 27;
            }
            else if (flag19 && !player[myPlayer].ZoneGraveyard && (!bloodMoon || dayTime) && (double)player[myPlayer].position.Y < worldSurface * 16.0 + (double)(screenHeight / 2))
            {
                Current = 48;
            }
            else if (remixWorld && bloodMoon && !player[myPlayer].ZoneCrimson && !player[myPlayer].ZoneCorrupt && (double)player[myPlayer].position.Y > rockLayer * 16.0 && player[myPlayer].position.Y <= (float)(UnderworldLayer * 16))
            {
                Current = 2;
            }
            else if (remixWorld && bloodMoon && player[myPlayer].position.Y > (float)(UnderworldLayer * 16) && (double)(player[myPlayer].Center.X / 16f) > (double)maxTilesX * 0.37 + 50.0 && (double)(player[myPlayer].Center.X / 16f) < (double)maxTilesX * 0.63)
            {
                Current = 2;
            }
            else if (player[myPlayer].ZoneShimmer)
            {
                Current = 91;
            }
            else if (flag18 && dayTime && ((cloudAlpha == 0f && !_shouldUseWindyDayMusic) || (double)player[myPlayer].position.Y >= worldSurface * 16.0 + (double)(screenHeight / 2)) && !player[myPlayer].ZoneGraveyard)
            {
                Current = 46;
            }
            else if (flag18 && !dayTime && ((!bloodMoon && cloudAlpha == 0f) || (double)player[myPlayer].position.Y >= worldSurface * 16.0 + (double)(screenHeight / 2)) && !player[myPlayer].ZoneGraveyard)
            {
                Current = 47;
            }
            else if (player[myPlayer].ZoneSandstorm)
            {
                Current = 40;
            }
            else if (player[myPlayer].position.Y > (float)(UnderworldLayer * 16))
            {
                Current = 36;
            }
            else if (num5 < 1f)
            {
                Current = (dayTime ? 42 : 15);
            }
            else if (tile[(int)(player[myPlayer].Center.X / 16f), (int)(player[myPlayer].Center.Y / 16f)].WallType == 87)
            {
                Current = 26;
            }
            else if (player[myPlayer].ZoneDungeon)
            {
                Current = 23;
            }
            else if ((bgStyle == 9 && (double)player[myPlayer].position.Y < worldSurface * 16.0 + (double)(screenHeight / 2)) || undergroundBackground == 2)
            {
                Current = 29;
            }
            else if (player[myPlayer].ZoneCorrupt)
            {
                if (player[myPlayer].ZoneCrimson && Main.SceneMetrics.BloodTileCount > Main.SceneMetrics.EvilTileCount)
                {
                    if ((double)player[myPlayer].position.Y > worldSurface * 16.0 + (double)(screenHeight / 2))
                    {
                        Current = 33;
                    }
                    else
                    {
                        Current = 16;
                    }
                }
                else if ((double)player[myPlayer].position.Y > worldSurface * 16.0 + (double)(screenHeight / 2))
                {
                    Current = 10;
                }
                else
                {
                    Current = 8;
                }
            }
            else if (player[myPlayer].ZoneCrimson)
            {
                if ((double)player[myPlayer].position.Y > worldSurface * 16.0 + (double)(screenHeight / 2))
                {
                    Current = 33;
                }
                else
                {
                    Current = 16;
                }
            }
            else if (player[myPlayer].ZoneMeteor)
            {
                Current = 2;
            }
            else if (player[myPlayer].ZoneGraveyard)
            {
                Current = 53;
            }
            else if (player[myPlayer].ZoneJungle)
            {
                if (remixWorld)
                {
                    if ((double)player[myPlayer].position.Y > rockLayer * 16.0 + (double)(screenHeight / 2))
                    {
                        Current = 7;
                    }
                    else if (newMusic == 7 && (double)player[myPlayer].position.Y > (rockLayer - 50.0) * 16.0 + (double)(screenHeight / 2))
                    {
                        Current = 7;
                    }
                    else if ((double)player[myPlayer].position.Y < worldSurface * 16.0 + (double)(screenHeight / 2))
                    {
                        Current = (dayTime ? 42 : 15);
                    }
                    else
                    {
                        Current = 54;
                    }
                }
                else if ((double)player[myPlayer].position.Y > rockLayer * 16.0 + (double)(screenHeight / 2))
                {
                    Current = 54;
                }
                else if (newMusic == 54 && (double)player[myPlayer].position.Y > (rockLayer - 50.0) * 16.0 + (double)(screenHeight / 2))
                {
                    Current = 54;
                }
                else if (_shouldUseStormMusic && (double)player[myPlayer].position.Y < worldSurface * 16.0 + (double)(screenHeight / 2))
                {
                    Current = 52;
                }
                else if (dayTime)
                {
                    Current = 7;
                }
                else
                {
                    Current = 55;
                }
            }
            else if (player[myPlayer].ZoneSnow)
            {
                if ((double)player[myPlayer].position.Y > worldSurface * 16.0 + (double)(screenHeight / 2))
                {
                    if (remixWorld && (double)player[myPlayer].position.Y > rockLayer * 16.0 + (double)(screenHeight / 2))
                    {
                        Current = 14;
                    }
                    else
                    {
                        Current = 20;
                    }
                }
                else if (remixWorld)
                {
                    Current = (dayTime ? 42 : 15);
                }
                else
                {
                    Current = 14;
                }
            }
            else if ((double)player[myPlayer].position.Y >= worldSurface * 16.0 + (double)(screenHeight / 2) && (remixWorld || !WorldGen.oceanDepths((int)(screenPosition.X + (float)(screenWidth / 2)) / 16, (int)(screenPosition.Y + (float)(screenHeight / 2)) / 16)))
            {
                if (player[myPlayer].ZoneHallow)
                {
                    if (remixWorld && (double)player[myPlayer].position.Y >= rockLayer * 16.0 + (double)(screenHeight / 2))
                    {
                        Current = 9;
                    }
                    else
                    {
                        Current = 11;
                    }
                }
                else if (player[myPlayer].ZoneUndergroundDesert)
                {
                    if ((double)player[myPlayer].position.Y >= worldSurface * 16.0 + (double)(screenHeight / 2))
                    {
                        Current = 61;
                    }
                    else
                    {
                        Current = 21;
                    }
                }
                else
                {
                    int ugMusicHolder = ugMusic;
                    if (ugMusicHolder == 0)
                    {
                        ugMusicHolder = 4;
                    }
                    if (!audioSystem.IsTrackPlaying(4) && !audioSystem.IsTrackPlaying(31))
                    {
                        /*
                        if (musicFade[4] == 1f)
                        {
                            musicFade[31] = 1f;
                        }
                        if (musicFade[31] == 1f)
                        {
                            musicFade[4] = 1f;
                        }
                        */
                        switch (rand.Next(2))
                        {
                            case 0:
                                ugMusicHolder = 4;
                                //musicFade[31] = 0f;
                                break;
                            case 1:
                                ugMusicHolder = 31;
                                // musicFade[4] = 0f;
                                break;
                        }
                    }
                    Current = ugMusicHolder;
                    if (remixWorld && (double)(player[myPlayer].position.Y / 16f) > rockLayer && player[myPlayer].position.Y / 16f < (float)(maxTilesY - 350))
                    {
                        if (cloudAlpha > 0f)
                        {
                            Current = 19;
                        }
                        else if (player[myPlayer].ZoneDesert)
                        {
                            Current = 21;
                        }
                        else if (_shouldUseWindyDayMusic)
                        {
                            Current = 44;
                        }
                    }
                }
            }
            else if (dayTime && player[myPlayer].ZoneHallow)
            {
                if (_shouldUseStormMusic)
                {
                    Current = 52;
                }
                else if (cloudAlpha > 0f && !gameMenu)
                {
                    Current = 19;
                }
                else if (_shouldUseWindyDayMusic && !remixWorld)
                {
                    Current = 44;
                }
                else
                {
                    Current = 9;
                }
            }
            else if (_shouldUseStormMusic)
            {
                if (bloodMoon)
                {
                    Current = 2;
                }
                else
                {
                    Current = 52;
                }
            }
            else if (WorldGen.oceanDepths((int)(screenPosition.X + (float)(screenWidth / 2)) / 16, (int)(screenPosition.Y + (float)(screenHeight / 2)) / 16))
            {
                if (bloodMoon)
                {
                    Current = 2;
                }
                else if (flag18)
                {
                    if (dayTime)
                    {
                        Current = 46;
                    }
                    else
                    {
                        Current = 47;
                    }
                }
                else
                {
                    Current = (dayTime ? 22 : 43);
                }
            }
            else if (player[myPlayer].ZoneDesert)
            {
                if ((double)player[myPlayer].position.Y >= worldSurface * 16.0)
                {
                    int num6 = (int)(player[myPlayer].Center.X / 16f);
                    int num7 = (int)(player[myPlayer].Center.Y / 16f);
                    if (WorldGen.InWorld(num6, num7) && (WallID.Sets.Conversion.Sandstone[tile[num6, num7].WallType] || WallID.Sets.Conversion.HardenedSand[tile[num6, num7].WallType]))
                    {
                        Current = 61;
                    }
                    else
                    {
                        Current = 21;
                    }
                }
                else
                {
                    Current = 21;
                }
            }
            else if (remixWorld)
            {
                Current = (dayTime ? 42 : 15);
            }
            else if (dayTime)
            {
                if (cloudAlpha > 0f && !gameMenu)
                {
                    if (time < 10800.0)
                    {
                        Current = 59;
                    }
                    else
                    {
                        Current = 19;
                    }
                }
                else
                {
                    int dayMusicHolder = dayMusic;
                    if (dayMusic == 0)
                    {
                        dayMusicHolder = 1;
                    }
                    if (!audioSystem.IsTrackPlaying(1) && !audioSystem.IsTrackPlaying(18))
                    {
                        if (rand.Next(2) == 0)
                        {
                            dayMusicHolder = 1;
                        }
                        else
                        {
                            dayMusicHolder = 18;
                        }
                    }
                    Current = dayMusic;
                    if (_shouldUseWindyDayMusic && !remixWorld)
                    {
                        Current = 44;
                    }
                }
            }
            else if (!dayTime)
            {
                if (bloodMoon)
                {
                    Current = 2;
                }
                else if (cloudAlpha > 0f && !gameMenu)
                {
                    Current = 19;
                }
                else
                {
                    Current = 3;
                }
            }
            if (((double)(screenPosition.Y / 16f) < worldSurface + 10.0 || remixWorld) && pumpkinMoon)
            {
                Current = 30;
            }
            if (((double)(screenPosition.Y / 16f) < worldSurface + 10.0 || remixWorld) && snowMoon)
            {
                Current = 32;
            }
        }
        #endregion
    }
    abstract class MusicEffect : ModSceneEffect
    {
        public abstract string MusicName { get; }
        public int timer;
        public const int IMMERSIVE_SONG_TIME = 120;
        public override int Music => MusicLoader.GetMusicSlot(Mod, $"Music/{MusicName}");
        public override bool IsSceneEffectActive(Player player)
        {
            return Active(player);
        }
        public abstract bool Active(Player player);
    }
    #region Bosses

    class TrojanSquirrel : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "vampiresinvadingheaven";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideTrojanSquirrelTheme)
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss("TrojanSquirrel");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "Everhood - Vampires Invading Heaven";
                return true;
            }
            return false;
        }
    }
    class KingSlime : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "dancionbasement";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideKingSlimeTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.KingSlime);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "Void Stranger - Dancion Basement";
                return true;
            }
            return false;
        }
    }
    class EyeOfCthulhu : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "timestoppertactics";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideEyeOfCthulhuTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.EyeofCthulhu);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "corru.observer - Timestopper Tactics";
                return true;
            }
            return false;
        }
    }
    class CursedCoffin : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "guaranteevoid";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideCursedCoffinTheme)
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss("CursedCoffin");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "Void Stranger - Guarantee Void";
                return true;
            }
            return false;
        }
    }
    class EaterOfWorlds : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "endureeliminate";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideEaterOfWorldsTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.EaterofWorldsHead);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "corru.observer - Endure, Eliminate";
                return true;
            }
            return false;
        }
    }
    class Brain : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "hostilerewrite";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideBrainOfCthulhuTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.BrainofCthulhu);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "corru.observer - Hostile Rewrite";
                return true;
            }
            return false;
        }
    }
    class QueenBee : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "homedepot";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideQueenBeeTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.QueenBee);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "the home depot song :)";
                return true;
            }
            return false;
        }
    }
    class Skeletron : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "thefinalbattle";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideSkeletronTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.SkeletronHead);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "Everhood - The Final Battle";
                return true;
            }
            return false;
        }
    }
    class Deerclops : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "lostgirl";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideDeerclopsTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.Deerclops);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "deerclops is the knight";
                return true;
            }
            return false;
        }
    }
    class Devi : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;
        public override string MusicName => "connect";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideDevianttTheme)
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss("DeviBoss");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "Puella Magi Madoka Magica - Connect";
                return true;
            }
            return false;
        }
    }
    class WallOfFlesh : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "ruinousintnt";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideWallOfFleshTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.WallofFlesh);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "corru.observer - RUINOUS INTNT";
                return true;
            }
            return false;
        }
    }
    class Dreadnautilus : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "fnaf2ambience";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideDreadnautilusTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.BloodNautilus);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "FNAF 2 Ambience";
                return true;
            }
            return false;
        }
    }
    class QueenSlime : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "worldsendvalentine";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideQueenSlimeTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.QueenSlimeBoss);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "OMORI - World's End Valentine";
                return true;
            }
            return false;
        }
    }
    class Baron : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "skyxxxxdays";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideBanishedBaronTheme)
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss("BanishedBaron");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "ZeroRanger - Sky XXXX Days";
                return true;
            }
            return false;
        }
    }
    class SkeletronPrime : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "daemons";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideSkeletronPrimeTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.SkeletronPrime);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "corru.observer - Daemons";
                return true;
            }
            return false;
        }
    }
    class Twins : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "bstrd";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideTwinsTheme)
                return false;
            NPC reti = MusicUtils.FindClosestBoss(NPCID.Retinazer);
            NPC spaz = MusicUtils.FindClosestBoss(NPCID.Spazmatism);
            if (reti != null || spaz != null)
            {
                TerryMusicSystem.nowPlayingString = "corru.observer - BSTRD";
                return true;
            }
            return false;
        }
    }
    class Destroyer : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "impact";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideDestroyerTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.TheDestroyer);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "corru.observer - Impact";
                return true;
            }
            return false;
        }
    }
    class Lifelight : MusicEffect
    {
        public override string MusicName => "teeheetime";
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;
        public override bool Active(Player player)
        {
            if (MusicUtils.Souls == null || !MusicConfig.Instance.OverrideLifelightTheme)
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss(MusicUtils.Souls.Version >= Version.Parse("1.8") ? "Lifelight" : "LifeChallenger");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "OMORI - Tee-hee Time";
                return true;
            }
            return false;
        }
    }
    class Plantera : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "feistyflowers";

        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverridePlanteraTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.Plantera);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "Everhood - Feisty Flowers";
                return true;
            }
            return false;
        }
    }
    class Golem : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "affronttogod";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideGolemTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.Golem);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "Void Stranger - Affront to God";
                return true;
            }
            return false;

        }
    }
    class Betsy : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "rushtheme";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideBetsyTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.DD2Betsy);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "The Battle Cats - Rush Theme";
                return true;
            }
            return false;
        }
    }
    class Fishron : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "skybluedays";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideDukeFishronTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.DukeFishron);
            if (npc != null && npc.active)
            {
                TerryMusicSystem.nowPlayingString = "Void Stranger - S** **** ****";
                return true;
            }
            return false;
        }
    }
    class EmpressofLight : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "magia";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideEmpressOfLightTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.HallowBoss);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "Puella Magi Madoka Magica - Magia";
                return true;
            }
            return false;
        }
    }
    class Cultist : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "thewallsaretryingtokillme";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideLunaticCultistTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.CultistBoss);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "corru.observer - The Walls Are Trying To Kill Me";
                return true;
            }
            return false;
        }
    }
    class Pillars : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "spatialstrategics";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideLunarPillarsTheme)
                return false;
            if (MusicUtils.AnyPillarsInRange())
            {
                TerryMusicSystem.nowPlayingString = "corru.observer - Spatial Strategics";
                return true;
            }
            return false;
        }
    }
    class MoonLord : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;
        public override string MusicName => "castyourselfaside";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideMoonLordTheme)
                return false;
            NPC npc = MusicUtils.FindClosestBoss(NPCID.MoonLordCore);
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "corru.observer - Cast Yourself Aside";
                return true;
            }
            return false;
        }
    }
    class TimberChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "timber";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideTimberChampionTheme)
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss("TimberChampion");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "Pitbull feat. Ke$ha - Timber";
                return true;
            }
            return false;
        }
    }
    class TerraChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "chinesemanbangingrockstogether";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideTerraChampionTheme)
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss("TerraChampion");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "Chinese man banging rocks together";
                return true;
            }
            return false;
        }
    }
    class NatureChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "dad3";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideNatureChampionTheme)
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss("NatureChampion");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "SimpleFlips - Dad 3";
                return true;
            }
            return false;
        }
    }
    class LifeChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "rectangular";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideLifeChampionTheme)
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss("LifeChampion");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "Sean Stephens - Rectangular";
                return true;
            }
            return false;
        }
    }
    class ShadowChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "thecircle";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideShadowChampionTheme)
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss("ShadowChampion");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "XTRATUNA - THE CIRCLE";
                return true;
            }
            return false;
        }
    }
    class EarthChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "anunderstale";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideEarthChampionTheme)
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss("EarthChampion");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "XTRATUNA - AN UNDER'S TALE (Chorus Only)";
                return true;
            }
            return false;
        }
    }
    class SpiritChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "curseofarmoredparhoah";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideSpiritChampionTheme)
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss("SpiritChampion");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "Keuperz - Curse of armored parhoah";
                return true;
            }
            return false;
        }
    }
    class WillChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "itsbeensolong";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideWillChampionTheme)
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss("WillChampion");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "The Living Tombstone - It's Been So Long";
                return true;
            }
            return false;
        }
    }
    class Eridanus : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;
        public override string MusicName => "thefalserulerofallheavens";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideEridanusTheme)
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss("CosmosChampion");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "Void Stranger - The False Ruler of All Heavens";
                return true;
            }
            return false;

        }
    }
    class Abom : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;
        public override string MusicName => "yourcontracthasexpired";
        public override bool Active(Player player)
        {
            if (!MusicConfig.Instance.OverrideAbominationnTheme)
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss("AbomBoss");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = "A Hat In Time - Your Contract Has Expired";
                return true;
            }
            return false;
        }
    }
    class Mutant : MusicEffect
    {
        public override SceneEffectPriority Priority => (SceneEffectPriority)9;
        private bool useAltMusic => MusicConfig.Instance.MutantFtwZzz && 
            (MusicUtils.Souls.Version >= Version.Parse("1.8") ? (bool)MusicUtils.Souls.Call("MasochistMode") : Main.getGoodWorld);
        public override string MusicName => useAltMusic ? "revenge" : "voidthesky";
        public override bool Active(Player player)
        {
            if ((MusicUtils.Souls == null) || (!MusicConfig.Instance.OverrideMutantTheme && !useAltMusic))
                return false;
            NPC npc = MusicUtils.FindClosestSoulsBoss("MutantBoss");
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = useAltMusic ? "Everhood - Revenge" : "Void Stranger - Void the Sky";
                return true;
            }
            return false;
        }
    }
    #endregion
}
