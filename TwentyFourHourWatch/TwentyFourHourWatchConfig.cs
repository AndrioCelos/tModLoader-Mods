using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace TwentyFourHourWatch;
[Label("Config")]
public class TwentyFourHourWatchConfig : ModConfig {
	public override ConfigScope Mode => ConfigScope.ClientSide;

	[Label("Modify watches")]
	[DefaultValue(true)]
	public bool ModifyWatches { get; set; }

	[Label("Modify grandfather clocks")]
	[DefaultValue(true)]
	public bool ModifyGrandfatherClocks { get; set; }
}
