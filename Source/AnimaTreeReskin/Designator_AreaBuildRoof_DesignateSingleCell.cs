using HarmonyLib;
using RimWorld;
using Verse;

namespace AnimaTreeReskin;

[HarmonyPatch(typeof(Designator_AreaBuildRoof), "DesignateSingleCell")]
internal class Designator_AreaBuildRoof_DesignateSingleCell
{
    public static void Prefix(ref Designator_AreaBuildRoof __instance, IntVec3 c)
    {
        foreach (var item in __instance.Map.thingGrid.ThingsAt(c))
        {
            if (item.def.building == null || item.def.defName != "AnimaTreeSpot")
            {
                continue;
            }

            Messages.Message("MessageRoofIncompatibleWithAnimaTreeSpot".Translate(item),
                MessageTypeDefOf.CautionInput, false);
            item.Destroy();
        }
    }
}