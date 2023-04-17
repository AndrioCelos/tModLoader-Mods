using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static StopwatchAndTallyCounter.StopwatchAndTallyCounter;

namespace StopwatchAndTallyCounter.Commands;
internal class CounterCommand : ModCommand {
	public override string Command => "counter";
	public override string Usage => "/counter hide/show/toggle/- [number]/+ [number]/reset/set <number>";
	public override string Description => "Show, hide or control the mod tally counter.";
	public override CommandType Type => CommandType.Chat;

	public override void Action(CommandCaller caller, string input, string[] args) {
		var soundID = SoundID.MenuTick;
		switch (args[0].ToLower()) {
			case "hide": Counter.Showing = false; break;
			case "show": Counter.Showing = true; break;
			case "toggle": Counter.Showing = !Counter.Showing; break;
			case "-":
			case "+":
			case "=":
			case "set":
				int n;
				if (args.Length > 1) {
					if (!int.TryParse(args[1], out n)) {
						caller.Reply("Invalid number.", FailColor);
						return;
					}
				} else if (args[0][0] is '-' or '+') {
					n = 1;
				} else {
					caller.Reply($"Usage: {this.Usage}", FailColor);
					return;
				}
				switch (args[0][0]) {
					case '-': Counter.Count -= n; break;
					case '+': Counter.Count += n; break;
					default: Counter.Count = n; soundID = SoundID.Unlock; break;
				}
				Counter.Showing = true;
				break;
			case "reset":
				Counter.Showing = true;
				Counter.Count = 0;
				soundID = SoundID.Unlock;
				break;
			default:
				caller.Reply($"Usage: {this.Usage}", FailColor);
				return;
		}
		SoundEngine.PlaySound(soundID);
	}
}
