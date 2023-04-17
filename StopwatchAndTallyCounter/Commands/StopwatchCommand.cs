using System;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static StopwatchAndTallyCounter.StopwatchAndTallyCounter;

namespace StopwatchAndTallyCounter.Commands;
internal class StopwatchCommand : ModCommand {
	public override string Command => "stopwatch";
	public override string Usage => "/stopwatch hide/show/toggle/start/stop/startstop/reset/restart/split/set <mins>/set <mins>:<secs>/boss";
	public override string Description => "Show, hide or control the mod stopwatch.";
	public override CommandType Type => CommandType.Chat;

	public override void Action(CommandCaller caller, string input, string[] args) {
		switch (args[0].ToLower()) {
			case "hide": Stopwatch.Showing = false; break;
			case "show": Stopwatch.Showing = true; break;
			case "toggle": Stopwatch.Showing = !Stopwatch.Showing; break;
			case "startstop":
				Stopwatch.Showing = true;
				Stopwatch.Running = !Stopwatch.Running;
				break;
			case "stop":
				Stopwatch.Showing = true;
				Stopwatch.Running = false;
				break;
			case "start":
				Stopwatch.Showing = true;
				Stopwatch.Running = true;
				break;
			case "reset":
				Stopwatch.Showing = true;
				Stopwatch.Running = false;
				Stopwatch.CountDown = false;
				Stopwatch.Time = 0;
				Stopwatch.SplitTime = 0;
				break;
			case "restart":
				Stopwatch.Showing = true;
				Stopwatch.Running = true;
				Stopwatch.CountDown = false;
				Stopwatch.Time = 0;
				Stopwatch.SplitTime = 0;
				break;
			case "split":
				Stopwatch.Showing = true;
				Stopwatch.SplitTime = Stopwatch.SplitTime != 0 ? 0 : Stopwatch.Time;
				break;
			case "set":
				if (args.Length <= 1) goto default;

				var tokens = args[1].Split(new[] { ' ', ':', '\'', '"', 'm', 's' }, 2, StringSplitOptions.RemoveEmptyEntries);
				if (tokens.Length > 1) {
					if (double.TryParse(tokens[0], out var mins) && double.TryParse(tokens[1], out var secs)) {
						Stopwatch.Time = (int) Math.Round(mins * 3600 + secs * 60);
					} else {
						caller.Reply("Invalid numbers.", FailColor);
						return;
					}
				} else {
					if (double.TryParse(tokens[0], out var mins)) {
						Stopwatch.Time = (int) Math.Round(mins * 3600);
					} else {
						caller.Reply("Invalid numbers.", FailColor);
						return;
					}
				}

				Stopwatch.Showing = true;
				Stopwatch.Running = false;
				Stopwatch.CountDown = true;
				Stopwatch.SplitTime = 0;
				break;
			case "boss":
				if (Stopwatch.BossMode) {
					Stopwatch.BossMode = false;
					caller.Reply("Boss mode is now off.", SuccessColor);
				} else {
					Stopwatch.BossMode = true;
					caller.Reply("Boss mode is now on.", SuccessColor);
				}
				return;
			default:
				caller.Reply($"Usage: {this.Usage}", FailColor);
				return;
		}
		SoundEngine.PlaySound(SoundID.MenuTick);
	}
}
