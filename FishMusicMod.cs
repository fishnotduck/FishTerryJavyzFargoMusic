using Terraria.ModLoader;

namespace FishMusicMod
{
	public class FishMusicMod : Mod
	{
		internal static FishMusicMod Instance;
		public override void Load()
		{
			Instance = this;
		}
		public override void Unload()
		{
			Instance = null;
		}
	}
}
