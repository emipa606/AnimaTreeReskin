using RimWorld;
using Verse;

namespace AnimaTreeReskin;

internal class AnimaTreeSpot : Building
{
    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    {
        if (!AnimaTreeReskin_IncidentWorker_AnimaTreeSpawn.CanSpawnAtSpot(Position, map))
        {
            Messages.Message("MessageSpotNotValidAnimaTreeSpotCanNotSpawnHere".Translate(),
                MessageTypeDefOf.CautionInput, false);
            Destroy();
        }
        else
        {
            base.SpawnSetup(map, respawningAfterLoad);
        }
    }
}