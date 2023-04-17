using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static StopwatchAndTallyCounter.StopwatchAndTallyCounter;

namespace StopwatchAndTallyCounter;
public class StopwatchAndTallyCounterSystem : ModSystem {
	public override void PostUpdateTime() {
		if (Stopwatch.BossMode) {
			var anyBossesAlive = false;
			for (int i = 0; i < Main.npc.Length; i++) {
				var npc = Main.npc[i];
				if (npc.active && (npc.boss ? npc.netID != NPCID.MartianSaucer : npc.netID == NPCID.EaterofWorldsHead)) {
					anyBossesAlive = true;
					break;
				}
			}
			if (Stopwatch.Running) {
				if (!anyBossesAlive) {
					Stopwatch.Running = false;
					Stopwatch.BossMode = false;
				}
			} else {
				if (anyBossesAlive) Stopwatch.Running = true;
			}
		}
		if (Stopwatch.Running) {
			if (Stopwatch.CountDown) Stopwatch.Time--;
			else Stopwatch.Time++;
		}
	}
}
