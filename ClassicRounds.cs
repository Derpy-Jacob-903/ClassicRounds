using MelonLoader;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using ClassicRounds;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Freeplay;
using BTD_Mod_Helper.Api.ModOptions;
using Il2Cpp;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Powers;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine.InputSystem.Utilities;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using BTD_Mod_Helper.Api.Display;
using Il2CppSystem.Runtime.InteropServices;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Unity;
using System;
using static MelonLoader.MelonLogger;

[assembly: MelonInfo(typeof(ClassicRounds.ClassicRoundsMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace ClassicRounds;
#pragma warning disable 1591
public class ClassicRoundsMod : BloonsTD6Mod
{
    public int[] cock = [1, 2, 3];
    public override void OnApplicationStart()
    {
        ModHelper.Msg<ClassicRoundsMod>("ClassicRounds loaded!");
    }
    public static readonly ModSettingBool ReducedCashinClassicModes = new(false) { displayName = "Reduced Cash in Classic Modes", description = "Reduce income in BTD3 GameModes by 20%, approximately negating the extra income of Pink and Zebra children from Cermamics." };
    public static readonly ModSettingBool UseClassicBloonsinClassicModes = new(true) { displayName = "Use Classic Bloons in Classic Modes", description = "Use Bloons that lack Pink and Zebra children in BTD3 RoundSets." };
    public static readonly ModSettingBool DisableSuperCermaicsinClassicModes = new(true) { displayName = "Disable Super Cermaics in Classic Modes", description = "Disables Super Cermaics the BTD3 and BTD4 GameModes\nLikely increases lag in freeplay." };
    public static readonly ModSettingBool DisableSuperCermaicsBTD5 = new(true) { displayName = "Disable Super Cermaics in BTD5 Modes from Round 81-85", description = "Disables Super Cermaics in BTD5 GameModes from Round 81-85." };
    public static readonly ModSettingBool DisableSuperCermaicsBATTD = new(true) { displayName = "Disable Super Cermaics in BATTD Modes", description = "(Unused as of v1.0.0)\nDisables Super Cermaics in BATTD GameModes" };
    public static readonly ModSettingBool LogOnChangeCeramicsAndChildren = new(false) { displayName = "Log on ChangeCeramicsAndChildren", description = "Logs every time ProgressiveDifficultyManager.ChangeCeramicsAndChildren is ran, specifying if it was skipped or not." };
    public static readonly ModSettingInt LogOnNthGeneratedBTD5Round = new(-1) { displayName = "Log on Nth Generated BTD5 Round", description = "Logs every Nth round generated for BTD5 Apopalypse and Freeplay.\nIf not postive, no logs will be made." };
    public static readonly ModSettingBool VerboseLogsForGeneratedBTD5Rounds = new(false) { displayName = "Verbose Logs for Generated BTD5 Rounds", description = "Logs on every wave generated for BTD5 Apopalypse and Freeplay. Very Spammy." };
    public static readonly ModSettingBool NPPMKFRILLS = new(false) { displayName = "NPPMKFRILLS on Impoppable", description = "Use Impoppable modifiers on NPPMKFRILLS" };

    public static readonly ModSettingInt GeneratedBTD3FreeplayRounds = new(100) { displayName = "Generated BTD3 Freeplay Rounds", description = "How many rounds to generate for the BTD3 Standard RoundSet past round 50.\nHigher values increase load times.\nValues above 100 (150 total) are untested." };
    public static readonly ModSettingInt GeneratedBTD4FreeplayRounds = new(75) { displayName = "Generated BTD4 Freeplay Rounds", description = "How many rounds to generate for the BTD4 Standard RoundSet past round 75.\nHigher values increase load times.\nValues above 180 (255 total) are untested." };
    public static readonly ModSettingInt GeneratedBTD5FreeplayRounds = new(65) { displayName = "Generated BTD5 Freeplay Rounds", description = "How many rounds to generate for the BTD5 Standard RoundSet past round 85.\nHigher values increase load times." };
	
    public static readonly ModSettingInt GeneratedBTD4ApopalypseRounds = new(150) { displayName = "Generated BTD4 Apopalypse Rounds", description = "How many rounds to generate for the BTD4 Apopalypse RoundSet?\nHigher values increase load times." };
    public static readonly ModSettingInt GeneratedBTD5ApopalypseRounds = new(150) { displayName = "Generated BTD5 Apopalypse Rounds", description = "How many rounds to generate for the BTD5 Apopalypse RoundSet?\nHigher values increase load times.\nValues above 399 may cause issues (BTD5 crashes at that point) and are untested." };

    /// <summary>
    /// Modify xp scales in relation to base hero
    /// </summary>
    /// <param name="gameModel">The modified game model for a current match</param>
    public override void OnNewGameModel(GameModel gameModel)
    {
        var name = gameModel.gameMode;
        float xpScale = 1;
        if (name.Contains("BTD") && name.Contains("ClassicRounds-"))
        {
            if ((name.Contains('1') || name.Contains('2')))
            {
                xpScale *= 5;
            }
            if (name.Contains('3'))
            {
                xpScale *= 2.5f;
            }
            if (name.Contains('4'))
            {
                xpScale *= 5 / 3;
            }
            if (name.Contains('5'))
            {
                xpScale *= 1.25f;
            }
            foreach (var t in gameModel.towers)
            {
                var upgrades = Game.instance.model.GetTowersWithBaseId(t.baseId).MaxBy(model => model.tier)!.appliedUpgrades;

                var myXpCosts = Game.instance.model.GetTowersWithBaseId(t.baseId).MaxBy(model => model.tier)!
                .appliedUpgrades.Select(Game.instance.model.GetUpgrade).Select(upgrade => upgrade.xpCost).ToArray();

                for (var i = 0; i < upgrades.Length; i++)
                {
                    gameModel.GetUpgrade(upgrades[i]).xpCost = Math.Max((int)Math.Round(myXpCosts[i] * xpScale), 1);
                }
            }
        }
    }
}



public class MonkeyGlue : ModDisplay2D
{
    protected override string TextureName => "MonkeyGlue";
}

[HarmonyPatch(typeof(ProgressiveDifficultyManager), "ChangeCeramicsAndChildren")]
static class ChangeCeramicsAndChildrenPatch
{
    [HarmonyPrefix]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "This is a Harmony patch. It is used to skip ProgressiveDifficultyManager.ChangeCeramicsAndChildren")]
    private static bool Prefix()
    {
        var gameMode = InGame.instance.GetGameModel().gameMode;

        if 
        (
            gameMode.Contains("ClassicRounds-") && gameMode.Contains('5') && InGame.instance.currentRoundId < 86 && ClassicRoundsMod.DisableSuperCermaicsBTD5 ||
            gameMode.Contains("ClassicRounds-") && gameMode.Contains("BATTD") && ClassicRoundsMod.DisableSuperCermaicsBATTD ||
            gameMode.Contains("ClassicRounds-") && (gameMode.Contains('1') || gameMode.Contains('2') || gameMode.Contains('3')) && ClassicRoundsMod.DisableSuperCermaicsinClassicModes
        )
        {
            if (ClassicRoundsMod.LogOnChangeCeramicsAndChildren) ModHelper.Log<ClassicRoundsMod>("ProgressiveDifficultyManager.ChangeCeramicsAndChildren skipped successfully.");
            return false; // Skip the original method
        }
        if (ClassicRoundsMod.LogOnChangeCeramicsAndChildren) ModHelper.Log<ClassicRoundsMod>("ProgressiveDifficultyManager.ChangeCeramicsAndChildren not skipped successfully.");
        return true; // Continue with the original method
    }
}


[HarmonyPatch(typeof(TowerSelectionMenu), nameof(TowerSelectionMenu.IsUpgradePathClosed))]
internal static class IsUpgradePathClosedPatch
{
    [HarmonyPostfix]
    private static void Postfix(TowerSelectionMenu __instance, int path, ref bool __result)
    {
        //ModHelper.Log<ClassicRoundsMod>("IsUpgradePathClosed patch called.");

        if (__instance.selectedTower == null)
        {
            //ModHelper.Log<ClassicRoundsMod>("Selected tower is null.");
            return;
        }
        if (InGame.instance.bridge.IsSandboxMode())
        {
            //ModHelper.Log<ClassicRoundsMod>("Sandbox mode is active.");
            return;
        }

        if (InGame.instance.GetGameModel().gameMode.Contains("ClassicRounds-"))
        {
            var tower = __instance.selectedTower.tower;
            if (tower.towerModel.IsHero())
            {
                //ModHelper.Log<ClassicRoundsMod>("Tower is a hero.");
                return;
            }

            if (tower.GetUpgrade(path) == null)
            {
                //ModHelper.Log<ClassicRoundsMod>("Upgrade path is null.");
                return;
            }

            string bid = tower.towerModel.baseId;
            string gamemode = InGame.instance.GetGameModel().gameMode;
            //ModHelper.Log<ClassicRoundsMod>($"Game mode: {gamemode}");
            if (!gamemode.Contains("ClassicRounds-"))
            {
                return;
            }
            else
            {
                __result = false;
                //ModHelper.Log<ClassicRoundsMod>($"Base ID: {bid}, Path: {path}");
                if ((bid == "SuperMonkey" || bid == "SpikeFactory") && path == 2)
                {
                    __result = true;
                    //ModHelper.Log<ClassicRoundsMod>("Path 3 for SuperMonkey or SpikeFactory is closed.");
                    return;
                }
                if (gamemode.Contains("BTD3") && (bid == "MonkeyVillage") && path == 1)
                {
                    __result = true;
                    //ModHelper.Log<ClassicRoundsMod>("Path 2 for MonkeyVillage is closed in BTD3.");
                }
                if (gamemode.Contains("BTD3") && (bid == "MonkeyAce" || bid == "HeliPilot" || bid == "Druid") && path == 1 && tower.GetUpgrade(path).tier >= 1)
                {
                    __result = true;
                    //ModHelper.Log<ClassicRoundsMod>("Path 2 for MonkeyAce, HeliPilot, or Druid is closed in BTD3 if tier >= 1.");
                }
                if (gamemode.Contains("BTD3") && tower.GetUpgrade(path).tier >= 2)
                {
                    __result = true;
                    //ModHelper.Log<ClassicRoundsMod>("Path with tier >= 2 is closed in BTD3.");
                }
                if (gamemode.Contains("BTD4") && tower.GetUpgrade(path).tier >= 3)
                {
                    __result = true;
                    //ModHelper.Log<ClassicRoundsMod>("Path with tier >= 3 is closed in BTD4.");
                }
                if ((gamemode.Contains("BTD5") || gamemode.Contains("BTDB")) && tower.GetUpgrade(path).tier >= 4)
                {
                    __result = true;
                    //ModHelper.Log<ClassicRoundsMod>("Path with tier >= 4 is closed in BTD5 or BTDB.");
                }
            }
            return;
        }
    }
}



[HarmonyPatch(typeof(InGame), nameof(InGame.StartMatch))]
public static class InGame_StartMatch
{

    private static bool IsClassic(string name)
    {
        return (name.Contains('1') || name.Contains('2') || name.Contains('3'));
    }

    [HarmonyPostfix]
    private static void Postfix(InGame __instance)
    {
        var name = __instance.GetGameModel().gameMode;

        if (name.Contains("BTD6Rogue-"))
        {
            foreach (var b in __instance.GetAllBloonToSim())
            {
                if (b.Def.baseId.Contains("ClassicRounds-Classic") || (b.Def.bloonProperties & BloonProperties.Black) != 0 || b.Def.tags.Contains("Ceramic"))
                {
                    b.Def.bloonProperties |= BloonProperties.Purple;
                }
            } 
        }
        if (name.Contains("BTD") && name.Contains("ClassicRounds-"))
        {
            float Dart = 200; //used for cost nerfs
            if (name.Contains("Apopalypse"))
            {
                __instance.GetGameModel().isApopalypse = true;
            }
            foreach (var t in __instance.GetGameModel().towers)
            {
                if (name.Contains('4')) //Add MOAB-Class glue resistance to Ceramics for BTD4
                {
                    foreach (var p in t.GetDescendants<ProjectileModel>().ToList())
                    {
                        foreach (var s in p.GetDescendants<SlowModifierForTagModel>().ToList())
                        {
                            if (s.tag == "Moabs")
                            {
                                SlowModifierForTagModel x = s.Duplicate();
                                x.tag = "Ceramic";
                                p.AddBehavior(x);
                            }
                        }
                    }
                }

                if (t.baseId == "PowersInShop-GlueTrap" && (IsClassic(name) || name.Contains('4')))
                {
                    if (IsClassic(name)) { t.cost = Dart * 0.20f; }
                    else { if (name.Contains('4')) { t.cost = Dart * 0.05f; } }
                    t.GetDescendant<ProjectileModel>().pierce = 20;
                }

                if (t.baseId == "PowersInShop-RoadSpikes")
                {
                    t.cost = Dart * 0.15f;
                    var a = t.GetBehavior<CreateProjectileOnTowerDestroyModel>().projectileModel;
                    var b = __instance.GetGameModel().GetTowerFromId("SpikeFactory-100").GetAttackModel().weapons[0].projectile;
                    a.pierce = 10; 
                    a.GetDamageModel().immuneBloonProperties = BloonProperties.Lead;
                    a.SetDisplay(b.display);
                    if (name.Contains('5')) { t.GetBehavior<CreateProjectileOnTowerDestroyModel>().projectileModel.pierce++; }
                    //if (name.Contains('5')) { t.GetBehavior<CreateProjectileOnTowerDestroyModel>().projectileModel.pierce++; }
                }

                if (t.baseId == "PowersInShop-MoabMine")
                {
                    t.cost = Dart * 0.10f;
                    foreach (var a in __instance.GetGameModel().GetTowerFromId("MonkeyAce-020").GetDescendants<AttackAirUnitModel>().ToList())
                    {
                        if (a.name.Contains("_PineappleBombs_"))
                        {
                            t.portrait = new Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference(VanillaSprites.ExplodingPineappleUpgradeIcon);
                            t.icon = new Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference(VanillaSprites.ExplodingPineappleUpgradeIcon);
                            t.GetBehavior<CreateProjectileOnTowerDestroyModel>().projectileModel = a.weapons[0].projectile;
                            var v = t.GetBehavior<CreateProjectileOnTowerDestroyModel>().projectileModel.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile;
                            v.GetDamageModel().damage = 3;
                            v.GetBehavior<DamageModifierForTagModel>().tag = "Moabs"; v.GetBehavior<DamageModifierForTagModel>().tags[0] = "Moabs";
                            v.GetBehavior<DamageModifierForTagModel>().damageAddative = 3;
                        }
                    }
                }

                if (t.baseId == "DartMonkey")
                {

                    foreach (var w in t.GetWeapons())
                    {
                        w.projectile.pierce--; //all darts
                        if (!t.HasUpgrade(0, 1) && !t.HasUpgrade(1, 1) && !t.HasUpgrade(2, 1))
                        {
                            Dart = t.cost;
                        }
                        if (t.HasUpgrade(0, 2)) { w.projectile.pierce--; } //razor sharp darts
                        if (t.HasUpgrade(0, 3)) { w.projectile.GetDamageModel().damage--; } //spike-o-pult
                        if (t.HasUpgrade(0, 4)) { w.projectile.pierce *= 2; } //juggernog
                        if (t.HasUpgrade(2, 3)) { w.projectile.pierce--; } //crossbow
                    }
                }
                if (t.baseId == "BoomerangMonkey")
                {
                    foreach (var a in t.GetAttackModels())
                    {
                        foreach (var w in a.weapons)
                        {
                            if (IsClassic(name))
                            {
                                w.projectile.pierce -= 2;
                            }
                            if (name.Contains('4'))
                            {
                                w.projectile.pierce --;
                            }
                            if (t.HasUpgrade(2, 2))
                            {
                                w.projectile.GetDamageModel().damage--;
                            }
                        }
                    }
                }
                if (t.baseId == "TackShooter")
                {
                    foreach (var a in t.GetAttackModels())
                    {
                        foreach (var w in a.weapons)
                        {
                            if (t.HasUpgrade(1, 2) && !t.HasUpgrade(1, 3)) //Super Range Tacks, not Blade Shooter
                            {
                                w.projectile.pierce -= 3;
                            }
                        }
                    }
                }
                if (t.baseId == "IceMonkey")
                {
                    foreach (var a in t.GetAttackModels())
                    {
                        foreach (var w in a.weapons)
                        {
                            if (!t.HasUpgrade(0, 2))
                            {
                                w.projectile.GetDescendant<DamageModel>().damage--;
                            }

                            if (t.HasUpgrade(2, 2))
                            {
                                w.projectile.AddBehavior<DamageModifierForBloonStateModel>(new DamageModifierForBloonStateModel("DamageModifierForBloonStateModel_", "Ice", 1, 1, false, false, true));
                            }
                        }
                    }
                }
                if (t.baseId == "SuperMonkey")
                {
                    t.cost = Dart * 20;

                    foreach (var a in t.GetAttackModels())
                    {
                        foreach (var w in a.weapons)
                        {
                            if (t.HasUpgrade(0, 2) || t.HasUpgrade(1, 4)) 
                            { 
                                w.projectile.pierce--; 
                                w.projectile.GetDamageModel().immuneBloonProperties &= BloonProperties.Purple; 
                            }
                        }
                    }
                }
                if (t.baseId == "MortarMonkey")
                {
                    foreach (var a in t.GetAttackModels())
                    {
                        foreach (var w in a.weapons)
                        {
                            w.projectile.GetDescendant<DamageModel>().damage--;
                            w.projectile.pierce += 15;
                        }
                    }
                }
                if (t.baseId == "MonkeySub")
                {
                    foreach (var a in t.GetAttackModels())
                    {
                        foreach (var w in a.weapons)
                        {
                            w.projectile.pierce--;
                        }
                    }
                }
                if (t.baseId == "Psychomonkey")
                {
                    if (t.HasUpgrade(1, 2) && IsClassic(name))
                    {
                        var attackModel = t.GetAttackModel();
                        attackModel.weapons[0].projectile.RemoveBehaviors<WindModel>();
                        attackModel.weapons[0].projectile.AddBehavior<FreezeModel>(__instance.GetGameModel().GetTowerModel("IceMonkey").GetDescendant<FreezeModel>());
                    }
                }
                if (t.baseId == "WizardMonkey")
                {
                    t.cost = Dart * 3.75f;
                    foreach (var a in t.GetAttackModels())
                    {
                        foreach (var w in a.weapons)
                        {
                            w.projectile.pierce--;
                            if (a.name.Contains("Fireball") && name.Contains('4')) //Explosive => Normal
                            {
                                foreach(var b in a.GetDescendants<DamageModel>().ToList())
                                {
                                    b.immuneBloonProperties = BloonProperties.None;
                                }
                            }
                            else if (name.Contains('5')) //Energy/Shatter => Plasma/Normal
                            {
                                foreach (var b in a.GetDescendants<DamageModel>().ToList())
                                {
                                    b.immuneBloonProperties &= ~BloonProperties.Lead;
                                }
                            }
                            if ((a.name.Contains("Wall of Fire") || a.name.Contains("Dragon's Breath")) && IsClassic(name)) //Fire => Explosive
                            {
                                foreach (var b in a.GetDescendants<DamageModel>().ToList())
                                {
                                    b.immuneBloonProperties &= ~BloonProperties.Black;
                                }
                            }
                            if (IsClassic(name) && !t.HasUpgrade(0, 2))
                            {
                                foreach (var b in a.GetDescendants<DamageModel>().ToList())
                                {
                                    b.immuneBloonProperties &= ~BloonProperties.Black;
                                }
                            }
                            if (name.Contains('5')) //Energy/Shatter => Plasma/Normal
                            {
                                foreach (var b in a.GetDescendants<DamageModel>().ToList())
                                {
                                    b.immuneBloonProperties &= ~BloonProperties.Lead;
                                }
                            }
                        }
                    }
                }
                if (t.baseId == "NinjaMonkey" && IsClassic(name))
                {
                    t.cost = Dart * 2.5f;
                    foreach (var a in t.GetAttackModels())
                    {
                        if (a.weapons.Count > 0 && a.weapons[0].projectile is not null)
                        {
                            foreach (var w in a.weapons)
                            {
                                if (w.projectile is not null)
                                {
                                    if (a.weapons[0].projectile.GetDamageModel() is not null)
                                    { a.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.White | BloonProperties.Lead; } // Sharp => Glacier

                                    if (t.HasUpgrade(1, 1) && w.projectile.GetBehaviors<WindModel>() is not null)
                                    {
                                        a.weapons[0].projectile.RemoveBehaviors<WindModel>();
                                        a.weapons[0].projectile.AddBehavior<FreezeModel>(__instance.GetGameModel().GetTowerModel("IceMonkey").GetDescendant<FreezeModel>());
                                    }

                                    if (t.HasUpgrade(1, 2) && w.projectile.GetBehaviors<WindModel>() is not null)
                                    {
                                        //a.weapons[0].projectile.GetDamageModel().immuneBloonProperties &= BloonProperties.Lead; // Glacier => 
                                        a.weapons[0].projectile.GetDescendant<FreezeModel>().layers++;
                                        a.weapons[0].projectile.AddBehavior<RemoveDamageTypeModifierModel>(__instance.GetGameModel().GetTowerModel("IceMonkey-402").GetDescendant<RemoveDamageTypeModifierModel>());
                                    }

                                    if (w.name == "AttackModel_Caltrops_")
                                    {
                                        w.AddBehavior(new EmissionsPerRoundFilterModel("EmissionsPerRoundFilterModel_", 10));
                                        if (t.HasUpgrade(0, 1))
                                        {
                                            t.GetBehavior<EmissionsPerRoundFilterModel>().count += 10;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if ((t.baseId == "Alchemist" || t.baseId == "GlueGunner") && IsClassic(name)) //Acid => Explosive
                {
                    foreach (var a in t.GetAttackModels())
                    {
                        foreach (var w in a.weapons)
                        {
                            foreach (var d in w.GetDescendants<DamageModel>().ToList())
                            {
                                if (d.immuneBloonProperties == BloonProperties.None) 
                                {
                                    d.immuneBloonProperties = BloonProperties.Black;
                                }
                            }
                        }
                    }
                }
                if (t.baseId == "Druid")
                {
                    if (IsClassic(name) || name.Contains('4') || name.Contains('5') || name.Contains("BTDB"))
                    {
                        t.cost = Dart * 5;
                    }
                    if (IsClassic(name))
                    {
                        foreach (var a in t.GetAttackModels())
                        {
                            foreach (var w in a.weapons)
                            {
                                if (t.HasUpgrade(1, 1) && w.name.Contains("WeaponModel_Weapon")) //Normal => Shaiter
                                {
                                    w.projectile.GetDamageModel().immuneBloonProperties |= BloonProperties.Lead;
                                    w.projectile.pierce--;
                                }
                                if (t.HasUpgrade(1, 1) && w.name.Contains("WeaponModel_Lightning")) //Plasma => Explosive
                                {
                                    w.projectile.GetDamageModel().immuneBloonProperties |= BloonProperties.Black;
                                    w.projectile.GetDamageModel().immuneBloonProperties |= BloonProperties.Purple;
                                }
                            }
                        }
                    }
                }
                if (t.baseId == "Eevee-Eevee")
                {
                    t.cost = Dart * 20;
                }
                if (t.baseId == "MonkeyMachine-MonkeyMachine" && (IsClassic(name) || name.Contains('4')))
                {
                    foreach (var s in t.GetDescendants<FilterInBaseTowerIdModel>().ToList())
                    {
                        s.baseIds.AddItem(t.baseId);
                    }

                    foreach (var a in t.GetAttackModels())
                    {
                        foreach (var w in a.weapons)
                        {
                            foreach (var d in w.GetDescendants<DamageModel>().ToList())
                            {
                                if (w.name.Contains("rocket_attack") && name.Contains('4'))
                                {
                                    d.immuneBloonProperties = BloonProperties.Black;
                                }
                            }
                        }
                    }
                }
            }
        }
        //if (name.Contains('1') || name.Contains('2') || name.Contains('3'))) 
        //{
            //var towers = __instance.GetGameModel().towers;
            //foreach (var t in __instance.GetGameModel().towers)
            //{
                


            //}
        //}
    }
}