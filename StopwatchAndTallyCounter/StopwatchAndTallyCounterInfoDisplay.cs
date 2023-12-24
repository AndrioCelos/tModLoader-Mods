using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static StopwatchAndTallyCounter.StopwatchAndTallyCounter;

namespace StopwatchAndTallyCounter;
public class StopwatchAndTallyCounterInfoDisplay : GlobalInfoDisplay {
	private static void ModifyDisplayNameInternal(InfoDisplay currentDisplay, ref string displayName) {
		if (currentDisplay == InfoDisplay.Stopwatch) {
			if (Stopwatch.Showing) displayName = Lang.GetItemNameValue(ItemID.Stopwatch);
		} else if (currentDisplay == InfoDisplay.TallyCounter) {
			if (Counter.Showing) displayName = Lang.GetItemNameValue(ItemID.TallyCounter);
		}
	}

	private static void ModifyDisplayValueInternal(InfoDisplay currentDisplay, ref string displayValue) {
		if (currentDisplay == InfoDisplay.Stopwatch) {
			if (Stopwatch.Showing) {
				bool minus = false;
				var time = Stopwatch.SplitTime != 0 ? Stopwatch.SplitTime : Stopwatch.Time;
				if (time < 0) {
					minus = true;
					time = -time;
				}

				var minutes = time / 3600;
				var seconds = time / 60 % 60;
				var cs = time % 60 * 5 / 3;

				displayValue = $"{(minus ? "-" : "")}{minutes:00}' {seconds:00}.{cs:00}\"";
			}
		} else if (currentDisplay == InfoDisplay.TallyCounter) {
			if (Counter.Showing) displayValue = $"Count: {Counter.Count}";
		}
	}

	private void ModifyDisplayColourInternal(InfoDisplay currentDisplay, ref Color displayColor) {
		var colour = ModContent.GetInstance<StopwatchAndTallyCounterConfig>().AltDisplayColour;
		if (colour.A == 0) {
			if (colour == default) colour = Color.White;  // No colour is set in the config.
			else colour.A = byte.MaxValue;
		}
		if ((currentDisplay == InfoDisplay.Stopwatch && Stopwatch.Showing) || (currentDisplay == InfoDisplay.TallyCounter && Counter.Showing))
			displayColor = new(colour.ToVector4() * Main.mouseTextColor / 255);
	}

#if TML_2022_09
	public override void ModifyDisplayName(InfoDisplay currentDisplay, ref string displayName) => ModifyDisplayNameInternal(currentDisplay, ref displayName);
	public override void ModifyDisplayValue(InfoDisplay currentDisplay, ref string displayValue) => ModifyDisplayNameInternal(currentDisplay, ref  displayValue);
#else
	public override void ModifyDisplayParameters(InfoDisplay currentDisplay, ref string displayValue, ref string displayName, ref Color displayColor, ref Color displayShadowColor) {
		ModifyDisplayNameInternal(currentDisplay, ref displayName);
		ModifyDisplayValueInternal(currentDisplay, ref displayValue);
		ModifyDisplayColourInternal(currentDisplay, ref displayColor);
	}
#endif
}
