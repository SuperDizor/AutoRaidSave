using System;
using Verse;

namespace AutoRaidSave
{
    public static class AutoRaidSaveUtility
    {
        private static DateTime lastSaveTime = DateTime.MinValue;

        public static bool InCooldown()
        {
            int minutes = AutoRaidSaveMod.Settings.cooldownMinutes;
            if (minutes <= 0)
                return false;

            return (DateTime.Now - lastSaveTime).TotalMinutes < minutes;
        }

        public static void MarkSaved()
        {
            lastSaveTime = DateTime.Now;
        }
    }
}
