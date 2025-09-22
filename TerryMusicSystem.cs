using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using FishMusicMod.UI;

namespace FishMusicMod
{
	public class TerryMusicSystem : ModSystem
	{
		public static string nowPlayingString = null;
        public static int lastFullVolumeSong = -1;
        public static Color TextColor => new Color(255, 160, 230);

        public override void PostUpdateEverything()
        {
            if (!Main.dedServ && !Main.gameMenu)
            {
                if (Main.musicFade[Main.curMusic] == 1f && lastFullVolumeSong != Main.curMusic)
                {
                    lastFullVolumeSong = Main.curMusic;
                    //Main.NewText($"{Main.curMusic} {lastFullVolumeSong} {Main.musicFade[Main.curMusic]} {nowPlayingString}");
                    string displayString = $"Now Playing: {nowPlayingString}";
                    if (MusicConfig.Instance.NowPlayingEnum == NowPlayingID.Notification)
                    {
                        InGameNotificationsTracker.Clear();
                        InGameNotificationsTracker.AddNotification(new NowPlayingNotif(displayString));
                    }
                    else if (MusicConfig.Instance.NowPlayingEnum == NowPlayingID.Chat)
                    {
                        Main.NewText(displayString, TextColor);
                    }
                }
            }

            nowPlayingString = null;
        }
	}
}
