using System.Linq;
using RimWorld;
using Verse;

namespace AnimaTreeReskin;

internal class AnimaTreeReskin_IncidentWorker_AnimaTreeSpawn : IncidentWorker_AnimaTreeSpawn
{
    protected override bool TryExecuteWorker(IncidentParms parms)
    {
        var map = (Map)parms.target;
        if (!tryFindRootCell(map, out var cell))
        {
            return false;
        }

        if (!GenStep.TrySpawnAt(cell, map, 0.05f, out var thing))
        {
            return false;
        }

        if (PawnsFinder.HomeMaps_FreeColonistsSpawned.Any(c =>
                c.HasPsylink && MeditationFocusDefOf.Natural.CanPawnUse(c)))
        {
            SendStandardLetter(parms, thing);
        }

        return true;
    }

    private bool tryFindRootCell(Map map, out IntVec3 cell)
    {
        foreach (var item in map.listerBuildings.allBuildingsColonist)
        {
            if (item.def.defName != "AnimaTreeSpot")
            {
                continue;
            }

            var position = item.Position;
            item.Destroy();
            if (CanSpawnAtSpot(position, map))
            {
                cell = position;
                return true;
            }

            Messages.Message("MessageAnimaTreeSpotCanNotSpawnOnThisSpot".Translate(item),
                MessageTypeDefOf.CautionInput, false);
            break;
        }

        if (CellFinderLoose.TryFindRandomNotEdgeCellWith(10, x => GenStep.CanSpawnAt(x, map), map, out cell))
        {
            return true;
        }

        return CellFinderLoose.TryFindRandomNotEdgeCellWith(10, x => GenStep.CanSpawnAt(x, map, 10, 0, 18, 20), map,
            out cell);
    }

    public static bool CanSpawnAtSpot(IntVec3 c, Map map)
    {
        if (!c.Standable(map) || c.Fogged(map))
        {
            return false;
        }

        c.GetPlant(map)?.Destroy();
        var thingList = c.GetThingList(map);
        if (Enumerable.Any(thingList, thing => thing.def == ThingDefOf.Plant_TreeAnima))
        {
            return false;
        }

        return !c.Roofed(map);
    }
}