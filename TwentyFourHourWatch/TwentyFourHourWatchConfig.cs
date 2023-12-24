using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace TwentyFourHourWatch;
public class TwentyFourHourWatchConfig : ModConfig {
	public override ConfigScope Mode => ConfigScope.ClientSide;

	[DefaultValue(true)]
	public bool ModifyWatches { get; set; }

	[DefaultValue(true)]
	public bool ModifyGrandfatherClocks { get; set; }
}
