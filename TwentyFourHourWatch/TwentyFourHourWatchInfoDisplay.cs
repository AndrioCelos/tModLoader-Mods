using Terraria.ModLoader;

namespace TwentyFourHourWatch;
public class TwentyFourHourWatchInfoDisplay : GlobalInfoDisplay {
	public override void ModifyDisplayValue(InfoDisplay currentDisplay, ref string displayValue) {
		if (currentDisplay == InfoDisplay.Watches && ModContent.GetInstance<TwentyFourHourWatchConfig>().ModifyWatches)
			displayValue = TwentyFourHourWatch.GetTimeString();
	}
}
