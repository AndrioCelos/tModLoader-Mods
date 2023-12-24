using Microsoft.Xna.Framework;
using Terraria.ModLoader.Config;

namespace StopwatchAndTallyCounter;
public class StopwatchAndTallyCounterConfig : ModConfig {
	public override ConfigScope Mode => ConfigScope.ClientSide;

	public Color AltDisplayColour { get; set; }
}
