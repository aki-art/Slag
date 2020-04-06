using Harmony;

namespace Slag.Buildings
{
    class BuildingPatches
    {
        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
        {
            public static void Prefix()
            {
                string InsulatedtileID = DenseInsulationTileConfig.ID.ToUpperInvariant();
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{InsulatedtileID}.NAME", "Dense Insulation Tile");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{InsulatedtileID}.EFFECT", "Dense insulation effect");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{InsulatedtileID}.DESC", "Dense insulation desc.");

                ModUtil.AddBuildingToPlanScreen("Base", DenseInsulationTileConfig.ID);
            }
        }
    }
}
