using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slag
{
    class Patches
    {
        [HarmonyPatch(typeof(EntityConfigManager), "LoadGeneratedEntities")]
        public class EntityConfigManager_LoadGeneratedEntities_Patch
        {
            public static void Prefix()
            {
                GameTags.MaterialBuildingElements.Add(ModAssets.slagWoolTag);
            }
        }

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
        {


            public static void Prefix()
            {
                string ManualInsulatedDoorID = Buildings.ManualInsulatedDoorConfig.ID.ToUpperInvariant();
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ManualInsulatedDoorID}.NAME", Buildings.ManualInsulatedDoorConfig.NAME);
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ManualInsulatedDoorID}.EFFECT", Buildings.ManualInsulatedDoorConfig.EFFECT);
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ManualInsulatedDoorID}.DESC", Buildings.ManualInsulatedDoorConfig.DESC);

                ModUtil.AddBuildingToPlanScreen("Base", Buildings.ManualInsulatedDoorConfig.ID);


                string MechanizedInsulatedDoorID = Buildings.InsulatedMechanizedAirlockConfig.ID.ToUpperInvariant();
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{MechanizedInsulatedDoorID}.NAME", Buildings.InsulatedMechanizedAirlockConfig.NAME);
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{MechanizedInsulatedDoorID}.EFFECT", Buildings.InsulatedMechanizedAirlockConfig.EFFECT);
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{MechanizedInsulatedDoorID}.DESC", Buildings.InsulatedMechanizedAirlockConfig.DESC);

                ModUtil.AddBuildingToPlanScreen("Base", Buildings.InsulatedMechanizedAirlockConfig.ID);
            }
        }

        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch("Initialize")]
        public static class Db_Initialize_Patch
        {
            public static void Prefix()
            {
                var techList = new List<string>(Database.Techs.TECH_GROUPING["TemperatureModulation"]) {
                        Buildings.ManualInsulatedDoorConfig.ID,
                        Buildings.InsulatedMechanizedAirlockConfig.ID };

                Database.Techs.TECH_GROUPING["TemperatureModulation"] = techList.ToArray();
            }
        }
    }
}
