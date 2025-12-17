using UnityEngine;
using Verse;

namespace AutoRaidSave
{
    public class AutoRaidSaveMod : Mod
    {
        public static AutoRaidSaveSettings Settings;

        public AutoRaidSaveMod(ModContentPack content) : base(content)
        {
            Settings = GetSettings<AutoRaidSaveSettings>();
        }

        public override string SettingsCategory()
        {
            return "Auto Raid Save";
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard list = new Listing_Standard();
            list.Begin(inRect);

            list.CheckboxLabeled(
                "Enable automatic save on raids",
                ref Settings.enabled,
                "If disabled, no automatic save will be triggered."
            );

            list.Gap();

            list.Label($"Cooldown between saves (minutes): {Settings.cooldownMinutes}");
            Settings.cooldownMinutes = (int)list.Slider(Settings.cooldownMinutes, 0, 30);

            list.Gap();

            list.CheckboxLabeled(
                "Always overwrite the same save",
                ref Settings.overwriteSave,
                "If enabled, all raid saves will overwrite the same file."
            );

            list.Gap();

            list.CheckboxLabeled(
                "Enable debug logging",
                ref Settings.debugLogging,
                "Logs extra information to the RimWorld log."
            );

            list.End();
        }
    }
}
