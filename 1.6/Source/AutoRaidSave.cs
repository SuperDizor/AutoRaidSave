using HarmonyLib;
using RimWorld;
using Verse;
using System;
using System.Linq;
using System.Reflection;

namespace AutoRaidSave
{
    [StaticConstructorOnStartup]
    public static class AutoRaidSave_Init
    {
        static AutoRaidSave_Init()
        {
            Log.Message("[AutoRaidSave] Mod loaded — initialization.");

            var harmony = new Harmony("com.montmod.autoraidsave");

            // Dynamically find the correct ReceiveLetter overload
            MethodInfo target = typeof(LetterStack)
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .FirstOrDefault(m =>
                {
                    if (m.Name != "ReceiveLetter") return false;
                    var parameters = m.GetParameters();
                    return parameters.Length >= 1 && parameters[0].ParameterType == typeof(Letter);
                });

            if (target == null)
            {
                Log.Error("[AutoRaidSave] CRITICAL ERROR: No ReceiveLetter overload found.");
                return;
            }

            Log.Message($"[AutoRaidSave] Targeting ReceiveLetter method: {target}");

            harmony.Patch(
                target,
                postfix: new HarmonyMethod(
                    typeof(Patch_LetterStack_ReceiveLetter),
                    nameof(Patch_LetterStack_ReceiveLetter.Postfix)
                )
            );

            Log.Message("[AutoRaidSave] ReceiveLetter patch applied successfully.");
        }
    }

    public static class Patch_LetterStack_ReceiveLetter
    {
        // Harmony automatically injects matching parameters
        public static void Postfix(Letter let)
        {
            if (let?.def == null)
                return;

            // Threat letters (red events)
            if (let.def == LetterDefOf.ThreatBig ||
                let.def == LetterDefOf.ThreatSmall)
            {
                Log.Message($"[AutoRaidSave] Threat letter detected: {let.def.defName}");

                try
                {
                    if (!AutoRaidSaveMod.Settings.enabled)
                        return;

                    // Cooldown check
                    if (AutoRaidSaveUtility.InCooldown())
                    {
                        if (AutoRaidSaveMod.Settings.debugLogging)
                            Log.Message("[AutoRaidSave] Cooldown active, save skipped.");

                        return;
                    }

                    string saveName = AutoRaidSaveMod.Settings.overwriteSave
                        ? "AutoSaveRaid"
                        : $"AutoSaveRaid_{let.def.defName}_{DateTime.Now:yyyyMMdd_HHmmss}";

                    // Delay save until raid generation is fully completed
                    LongEventHandler.ExecuteWhenFinished(() =>
                    {
                        try
                        {
                            GameDataSaveLoader.SaveGame(saveName);
                            AutoRaidSaveUtility.MarkSaved();

                            if (AutoRaidSaveMod.Settings.debugLogging)
                                Log.Message("[AutoRaidSave] Save completed after raid generation.");
                        }
                        catch (Exception ex)
                        {
                            Log.Error("[AutoRaidSave] Delayed save error: " + ex);
                        }
                    });
                }
                catch (Exception ex)
                {
                    Log.Error("[AutoRaidSave] Save error: " + ex);
                }
            }
        }
    }
}
