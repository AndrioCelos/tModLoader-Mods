using System;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TwentyFourHourWatch;
public class TwentyFourHourWatch : Mod {
	public static bool ShouldModifyGrandfatherClocks() => ModContent.GetInstance<TwentyFourHourWatchConfig>().ModifyGrandfatherClocks;

	internal static string GetTimeString() {
		var clockTime = ((int) Main.time + (Main.dayTime ? 16200 : 70200)) % 86400;
		var hour = clockTime / 3600;
		var minute = clockTime / 60 % 60;
		switch (Main.player[Main.myPlayer].accWatch) {
			case 1: minute = 0; break;
			case 2: minute = minute >= 30 ? 30 : 0; break;
		}
		return $"{hour:00}:{minute:00}";
	}

	public override void Load() {
#if TML_2022_09
		IL.Terraria.Player.TileInteractionsUse += this.Player_TileInteractionsUse;
#else
		IL_Player.TileInteractionsUse += this.Player_TileInteractionsUse;
#endif
	}

	private void Player_TileInteractionsUse(ILContext il) {
		var c = new ILCursor(il);
		c.GotoNext(i => i.MatchLdstr("GameUI.TimeAtMorning"));
		var originalCodeHead = il.DefineLabel(c.Next);

		for (var i = c.Next; i != null; i = i.Next) {
			if (i.MatchBr(out var label)) {
				c.EmitDelegate(ShouldModifyGrandfatherClocks);
				c.Emit(OpCodes.Brfalse, originalCodeHead);
				c.EmitDelegate(() => Main.NewText(Language.GetTextValue("Game.Time", GetTimeString()), 255, 240, 20));
				c.Emit(OpCodes.Br, label);
				return;
			}
		}
		throw new InvalidOperationException("Error modifying IL");
	}
}