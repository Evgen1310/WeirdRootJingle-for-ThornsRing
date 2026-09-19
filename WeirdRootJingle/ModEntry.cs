using StardewModdingAPI;
using StardewValley;
using StardewValley.Objects;
using HarmonyLib;

namespace WeirdRootJingle
{
    internal sealed class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            var harmony = new Harmony(ModManifest.UniqueID);
            harmony.Patch(
              original: AccessTools.Method(typeof(Ring), nameof(Ring.onEquip)),
              postfix: new HarmonyMethod(typeof(ModEntry), nameof(Rings_OnEquip_Postfix))
            );
            harmony.Patch(
              original: AccessTools.Method(typeof(Ring), nameof(Ring.onUnequip)),
              postfix: new HarmonyMethod(typeof(ModEntry), nameof(Rings_OnUnequip_Postfix))
            );
        }

        public static void Rings_OnEquip_Postfix(Ring __instance, Farmer who)
        {
            switch (__instance.ItemId)
            {
                case "839":
                    Game1.playSound("snd_ominous");
                    break;
            }
        }

        public static void Rings_OnUnequip_Postfix(Ring __instance, Farmer who)
        {
            switch (__instance.ItemId)
            {
                case "839":
                    Game1.playSound("snd_ominous_cancel");
                    break;
            }
        }

    }
}
