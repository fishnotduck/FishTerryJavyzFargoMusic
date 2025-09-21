using System.ComponentModel;
using Terraria.ModLoader.Config;
using Terraria.ModLoader;

namespace TerryMusicMod
{
    public class MusicConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static MusicConfig Instance => ModContent.GetInstance<MusicConfig>();

        [DefaultValue(NowPlayingID.Notification)]
        [DrawTicks]
        public NowPlayingID NowPlayingEnum;

        [DefaultValue(true)]
        public bool ImmersiveBossSongs;

        [DefaultValue(true)]
        public bool DreamMusic;

        [DefaultValue(true)]
        public bool ItsBrin;

        [Header("$Mods.TerryMusicMod.Configs.MusicConfig.Headers.VanillaMusicOverrides")]

        [DefaultValue(true)]
        public bool OverrideKingSlimeTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideEyeOfCthulhuTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideEaterOfWorldsTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideBrainOfCthulhuTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideQueenBeeTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideSkeletronTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideDeerclopsTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideWallOfFleshTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideDreadnautilusTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideQueenSlimeTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideBanishedBaronTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideSkeletronPrimeTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideTwinsTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideDestroyerTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverridePlanteraTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideGolemTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideBetsyTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideDukeFishronTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideEmpressOfLightTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideLunaticCultistTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideLunarPillarsTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideMoonLordTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool ToggleAllVanillaMusicOverrides
        {
            get
            {
                return OverrideKingSlimeTheme &&
                OverrideEyeOfCthulhuTheme &&
                OverrideEaterOfWorldsTheme &&
                OverrideBrainOfCthulhuTheme &&
                OverrideQueenBeeTheme &&
                OverrideSkeletronTheme &&
                OverrideDeerclopsTheme &&
                OverrideWallOfFleshTheme &&
                OverrideDreadnautilusTheme &&
                OverrideQueenSlimeTheme &&
                OverrideSkeletronPrimeTheme &&
                OverrideTwinsTheme &&
                OverrideDestroyerTheme &&
                OverridePlanteraTheme &&
                OverrideGolemTheme &&
                OverrideBetsyTheme &&
                OverrideDukeFishronTheme &&
                OverrideEmpressOfLightTheme &&
                OverrideLunaticCultistTheme &&
                OverrideLunarPillarsTheme &&
                OverrideMoonLordTheme;
            }
            set
            {
                OverrideKingSlimeTheme = value;
                OverrideEyeOfCthulhuTheme = value;
                OverrideEaterOfWorldsTheme = value;
                OverrideBrainOfCthulhuTheme = value;
                OverrideQueenBeeTheme = value;
                OverrideSkeletronTheme = value;
                OverrideDeerclopsTheme = value;
                OverrideWallOfFleshTheme = value;
                OverrideDreadnautilusTheme = value;
                OverrideQueenSlimeTheme = value;
                OverrideSkeletronPrimeTheme = value;
                OverrideTwinsTheme = value;
                OverrideDestroyerTheme = value;
                OverridePlanteraTheme = value;
                OverrideGolemTheme = value;
                OverrideBetsyTheme = value;
                OverrideDukeFishronTheme = value;
                OverrideEmpressOfLightTheme = value;
                OverrideLunaticCultistTheme = value;
                OverrideLunarPillarsTheme = value;
                OverrideMoonLordTheme = value;
            }
        }

        [Header("$Mods.TerryMusicMod.Configs.MusicConfig.Headers.SoulsMusicOverrides")]

        [DefaultValue(true)]
        public bool OverrideTrojanSquirrelTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideCursedCoffinTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideDevianttTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideLifelightTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideTimberChampionTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideTerraChampionTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideNatureChampionTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideLifeChampionTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideShadowChampionTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideEarthChampionTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideSpiritChampionTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideWillChampionTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideEridanusTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideAbominationnTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool OverrideMutantTheme
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool MutantFtwZzz
        {
            get; set;
        }

        [DefaultValue(true)]
        public bool ToggleAllSoulsMusicOverrides
        {
            get
            {
                return OverrideTrojanSquirrelTheme &&
                OverrideCursedCoffinTheme &&
                OverrideDevianttTheme &&
                OverrideBanishedBaronTheme &&
                OverrideLifelightTheme &&
                OverrideTimberChampionTheme &&
                OverrideTerraChampionTheme &&
                OverrideNatureChampionTheme &&
                OverrideLifeChampionTheme &&
                OverrideShadowChampionTheme &&
                OverrideEarthChampionTheme &&
                OverrideSpiritChampionTheme &&
                OverrideWillChampionTheme &&
                OverrideEridanusTheme &&
                OverrideAbominationnTheme &&
                OverrideMutantTheme &&
                MutantFtwZzz;
            }
            set
            {
                OverrideTrojanSquirrelTheme = value;
                OverrideCursedCoffinTheme = value;
                OverrideDevianttTheme = value;
                OverrideBanishedBaronTheme = value;
                OverrideLifelightTheme = value;
                OverrideTimberChampionTheme = value;
                OverrideTerraChampionTheme = value;
                OverrideNatureChampionTheme = value;
                OverrideLifeChampionTheme = value;
                OverrideShadowChampionTheme = value;
                OverrideEarthChampionTheme = value;
                OverrideSpiritChampionTheme = value;
                OverrideWillChampionTheme = value;
                OverrideEridanusTheme = value;
                OverrideAbominationnTheme = value;
                OverrideMutantTheme = value;
                MutantFtwZzz = value;
            }
        }

    }
}
