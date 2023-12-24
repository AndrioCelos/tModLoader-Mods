using System.Reflection;
using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace MenuTitleSplash;
public class MenuTitleSplash : Mod {
	private static void DrawTitleSplash(string title) {
		if (title is not null && Main.menuMode == MenuID.Title) {
			var font = FontAssets.DeathText.Value;
			var size = font.MeasureString(title);
			ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, font, title, new(Main.screenWidth / 2, 200),
				new Color(255, 240, 20) * ((float) Main.mouseTextColor / 255), 0, size / 2, new(0.5f, 0.5f));
		}
	}

	public override void Load() {
#if TML_2022_09
		IL.Terraria.Main.DrawMenu += this.Main_DrawMenu;
#else
		IL_Main.DrawMenu += this.Main_DrawMenu;
#endif
	}

	private void Main_DrawMenu(ILContext il) {
		var c = new ILCursor(il);
		c.GotoNext(MoveType.AfterLabel, i => i.MatchLdsfld(typeof(Main), nameof(Main.dayTime)));
		c.Emit(OpCodes.Ldarg_0);
		c.Emit(OpCodes.Ldfld, typeof(Main).GetField("_cachedTitle", BindingFlags.NonPublic | BindingFlags.Instance));
		c.EmitDelegate(DrawTitleSplash);
	}
}
