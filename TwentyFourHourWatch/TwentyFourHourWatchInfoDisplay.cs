using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace TwentyFourHourWatch;
public class TwentyFourHourWatchInfoDisplay : GlobalInfoDisplay {
	public override void ModifyDisplayParameters(InfoDisplay currentDisplay, ref string displayValue, ref string displayName, ref Color displayColor, ref Color displayShadowColor) {
		if (currentDisplay == InfoDisplay.Watches && ModContent.GetInstance<TwentyFourHourWatchConfig>().ModifyWatches)
			displayValue = TwentyFourHourWatch.GetTimeString();
	}
}
