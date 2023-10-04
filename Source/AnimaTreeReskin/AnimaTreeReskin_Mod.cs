using System.Reflection;
using HarmonyLib;
using Verse;

namespace AnimaTreeReskin;

internal class AnimaTreeReskin_Mod : Mod
{
    public AnimaTreeReskin_Mod(ModContentPack content)
        : base(content)
    {
        var harmonyInstance = new Harmony("cattleya.AnimaTreeReskin");
        harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
    }
}