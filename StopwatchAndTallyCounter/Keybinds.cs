using Terraria.ModLoader;

namespace StopwatchAndTallyCounter;
internal record Keybinds(
	ModKeybind StopwatchToggleKeybind,
	ModKeybind StopwatchStartStopKeybind,
	ModKeybind StopwatchResetKeybind,
	ModKeybind StopwatchSplitKeybind,
	ModKeybind CounterToggleKeybind,
	ModKeybind CounterPlusKeybind,
	ModKeybind CounterMinusKeybind,
	ModKeybind CounterResetKeybind
);
