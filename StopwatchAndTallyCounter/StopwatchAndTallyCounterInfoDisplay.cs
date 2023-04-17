using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static StopwatchAndTallyCounter.StopwatchAndTallyCounter;

namespace StopwatchAndTallyCounter;
public class StopwatchAndTallyCounterInfoDisplay : GlobalInfoDisplay {
	public override void ModifyDisplayName(InfoDisplay currentDisplay, ref string displayName) {
		if (currentDisplay == InfoDisplay.Stopwatch) {
			if (Stopwatch.Showing) displayName = Lang.GetItemNameValue(ItemID.Stopwatch);
		} else if (currentDisplay == InfoDisplay.TallyCounter) {
			if (Counter.Showing) displayName = Lang.GetItemNameValue(ItemID.TallyCounter);
		}
	}

	public override void ModifyDisplayValue(InfoDisplay currentDisplay, ref string displayValue) {
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
}
