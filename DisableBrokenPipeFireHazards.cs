using HarmonyLib;
using UnityEngine;

namespace DisableBrokenPipeFireHazards
{
        public class ModApi : IModApi
        {
            public void InitMod(Mod _modInstance)
            {
                var harmony = new Harmony("scan_disablebrokenpipefirehazards");
                harmony.PatchAll();

                Debug.Log("[DisableBrokenPipeFireHazards] Loaded.");
            }
        }

        [HarmonyPatch(typeof(BlockHazard), nameof(BlockHazard.IsHazardOn))]
        public class BlockHazard_IsHazardOn_Patch
        {
            static void Postfix(ref bool __result)
            {
                __result = false;
            }
        }

        [HarmonyPatch(typeof(BlockHazard), nameof(BlockHazard.GetLightValue))]
        public class BlockHazard_GetLightValue_Patch
        {
            static void Postfix(ref byte __result)
            {
                __result = 0;
            }
        }

    }