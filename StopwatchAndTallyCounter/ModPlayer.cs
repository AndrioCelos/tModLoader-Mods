using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static StopwatchAndTallyCounter.StopwatchAndTallyCounter;

namespace StopwatchAndTallyCounter;
internal class StopwatchAndTallyCounterPlayer : ModPlayer {
	public override void ProcessTriggers(TriggersSet triggersSet) {
		var keybinds = StopwatchAndTallyCounter.keybinds;
		if (keybinds == null) return;

		if (keybinds.StopwatchToggleKeybind.JustPressed) {
			Stopwatch.Showing = !Stopwatch.Showing;
			SoundEngine.PlaySound(SoundID.MenuTick);
		}
		if (keybinds.StopwatchStartStopKeybind.JustPressed) {
			Stopwatch.Showing = true;
			Stopwatch.Running = !Stopwatch.Running;
			SoundEngine.PlaySound(SoundID.MenuTick);
		}
		if (keybinds.StopwatchResetKeybind.JustPressed) {
			Stopwatch.Showing = true;
			Stopwatch.Running = false;
			Stopwatch.CountDown = false;
			Stopwatch.Time = 0;
			Stopwatch.SplitTime = 0;
			SoundEngine.PlaySound(SoundID.MenuTick);
		}
		if (keybinds.StopwatchSplitKeybind.JustPressed) {
			Stopwatch.Showing = true;
			Stopwatch.SplitTime = Stopwatch.SplitTime != 0 ? 0 : Stopwatch.Time;
			SoundEngine.PlaySound(SoundID.MenuTick);
		}

		if (keybinds.CounterToggleKeybind.JustPressed) {
			Counter.Showing = !Counter.Showing;
			SoundEngine.PlaySound(SoundID.MenuTick);
		}
		if (keybinds.CounterPlusKeybind.JustPressed) {
			Counter.Showing = true;
			Counter.Count++;
			SoundEngine.PlaySound(SoundID.MenuTick);
		}
		if (keybinds.CounterMinusKeybind.JustPressed) {
			Counter.Showing = true;
			Counter.Count--;
			SoundEngine.PlaySound(SoundID.MenuTick);
		}
		if (keybinds.CounterResetKeybind.JustPressed) {
			Counter.Showing = true;
			Counter.Count = 0;
			SoundEngine.PlaySound(SoundID.Unlock);
		}
	}

	public override void LoadData(TagCompound tag) {
		Stopwatch = new() {
			Showing = tag.GetBool("StopwatchShowing"),
			Running = tag.GetBool("StopwatchRunning"),
			CountDown = tag.GetBool("StopwatchCountDown"),
			Time = tag.GetLong("StopwatchTime"),
			SplitTime = tag.GetLong("StopwatchSplitTime"),
			BossMode = tag.GetBool("StopwatchBossMode")
		};
		Counter = new() {
			Showing = tag.GetBool("CounterShowing"),
			Count = tag.GetInt("CounterCount")
		};
	}

	public override void SaveData(TagCompound tag) {
		tag["StopwatchShowing"] = Stopwatch.Showing;
		tag["StopwatchRunning"] = Stopwatch.Running;
		tag["StopwatchCountDown"] = Stopwatch.CountDown;
		tag["StopwatchTime"] = Stopwatch.Time;
		tag["StopwatchSplitTime"] = Stopwatch.SplitTime;
		tag["StopwatchBossMode"] = Stopwatch.BossMode;
		tag["CounterShowing"] = Counter.Showing;
		tag["CounterCount"] = Counter.Count;
	}
}

