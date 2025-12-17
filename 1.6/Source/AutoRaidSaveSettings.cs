using Verse;

namespace AutoRaidSave
{
    public class AutoRaidSaveSettings : ModSettings
    {
        public bool enabled = true;
        public int cooldownMinutes = 0;
        public bool overwriteSave = false;
        public bool debugLogging = false;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref enabled, "enabled", true);
            Scribe_Values.Look(ref cooldownMinutes, "cooldownMinutes", 0);
            Scribe_Values.Look(ref overwriteSave, "overwriteSave", false);
            Scribe_Values.Look(ref debugLogging, "debugLogging", false);

            base.ExposeData();
        }
    }
}
