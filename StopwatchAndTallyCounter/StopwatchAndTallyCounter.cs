using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;

namespace StopwatchAndTallyCounter;
public class StopwatchAndTallyCounter : Mod
{
	public static Color SuccessColor { get; } = new(64, 192, 64, 255);
	public static Color FailColor { get; } = new(192, 64, 64, 255);

	public class StopwatchState {
		public bool Showing { get; set; }
		public bool Running { get; set; }
		public bool CountDown { get; set; }
		public long Time { get; set; }
		public long SplitTime { get; set; }
		public bool BossMode { get; set; }

		public bool IsEmpty => !this.Showing && !this.Running && !this.CountDown && this.Time == 0 && this.SplitTime == 0;
	}

	public class CounterState {
		public bool Showing { get; set; }
		public int Count { get; set; }
		public bool IsEmpty => !this.Showing && this.Count == 0;
	}

	public static CounterState Counter { get; set; } = new();
	public static StopwatchState Stopwatch { get; set; } = new();

	internal static Keybinds? keybinds;

	public override void Load() {
		keybinds = new(
#if TML_2022_09
			StopwatchToggleKeybind: KeybindLoader.RegisterKeybind(this, "Stopwatch Toggle", Keys.OemCloseBrackets),
			StopwatchStartStopKeybind: KeybindLoader.RegisterKeybind(this, "Stopwatch Start/Stop", Keys.P),
			StopwatchResetKeybind: KeybindLoader.RegisterKeybind(this, "Stopwatch Reset", Keys.O),
			StopwatchSplitKeybind: KeybindLoader.RegisterKeybind(this, "Stopwatch Split", Keys.I),
			CounterToggleKeybind: KeybindLoader.RegisterKeybind(this, "Counter Toggle", Keys.OemOpenBrackets),
			CounterPlusKeybind: KeybindLoader.RegisterKeybind(this, "Counter +1", Keys.OemPeriod),
			CounterMinusKeybind: KeybindLoader.RegisterKeybind(this, "Counter -1", Keys.OemComma),
			CounterResetKeybind: KeybindLoader.RegisterKeybind(this, "Counter Reset", Keys.L)
#else  // Preview version
			StopwatchToggleKeybind: KeybindLoader.RegisterKeybind(this, "StopwatchToggle", Keys.OemCloseBrackets),
			StopwatchStartStopKeybind: KeybindLoader.RegisterKeybind(this, "StopwatchStartStop", Keys.P),
			StopwatchResetKeybind: KeybindLoader.RegisterKeybind(this, "StopwatchReset", Keys.O),
			StopwatchSplitKeybind: KeybindLoader.RegisterKeybind(this, "StopwatchSplit", Keys.I),
			CounterToggleKeybind: KeybindLoader.RegisterKeybind(this, "CounterToggle", Keys.OemOpenBrackets),
			CounterPlusKeybind: KeybindLoader.RegisterKeybind(this, "CounterPlus", Keys.OemPeriod),
			CounterMinusKeybind: KeybindLoader.RegisterKeybind(this, "CounterMinus", Keys.OemComma),
			CounterResetKeybind: KeybindLoader.RegisterKeybind(this, "CounterReset", Keys.L)
#endif
		);
	}
}