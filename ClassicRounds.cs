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
    public static readonly ModSettingBool ReducedCashinClassicModes = new(false) { description = "Reduce income in BTD3 GameModes by 20%, approximately negating the extra income of Pink and Zebra children from Cermamics." };
    public static readonly ModSettingBool UseClassicBloonsinClassicModes = new(true) { description = "Use Bloons that lack Pink and Zebra children in BTD3 RoundSets." };
    public static readonly ModSettingBool DisableSuperCermaicsinClassicModes = new(true) { description = "Disables Super Cermaics the BTD3 and BTD4 GameModes\nLikely increases lag." };
    public static readonly ModSettingBool LogOnChangeCeramicsAndChildren = new(true) { description = "Logs every time ProgressiveDifficultyManager.ChangeCeramicsAndChildren is ran, specifying if it was skipped or not." };

    public static readonly ModSettingInt GeneratedBTD3FreeplayRounds = new(100) { description = "How many rounds to generate for the BTD3 Standard RoundSet past round 50.\nValues above 100 (150 total) are untested." };
    public static readonly ModSettingInt GeneratedBTD4FreeplayRounds = new(180) { description = "How many rounds to generate for the BTD4 Standard RoundSet past round 75.\nValues above 180 (255 total) are untested." };
    public static readonly ModSettingInt GeneratedBTD5FreeplayRounds = new(314) { description = "(Unused as of v0.3.0)\nHow many rounds to generate for the BTD5 Standard RoundSet past round 85." };

    public static readonly ModSettingBool DisableBTD4ApopalypseRounds = new(true) { description= "Disables the BTD4 Apopalypse GameMode" };
    public static readonly ModSettingInt GeneratedBTD4ApopalypseRounds = new(255) { description = "How many rounds to generate for the BTD4 Apopalypse RoundSet?" };
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

        if (gameMode.Contains("ClassicRounds-")
            && !gameMode.Contains('5') && !gameMode.Contains("BTDB") && !gameMode.Contains("BATTD")
            && ClassicRoundsMod.DisableSuperCermaicsinClassicModes)
        {
            ModHelper.Log<ClassicRoundsMod>("ProgressiveDifficultyManager.ChangeCeramicsAndChildren skipped successfully.");
            return false; // Skip the original method
        }
        ModHelper.Log<ClassicRoundsMod>("ProgressiveDifficultyManager.ChangeCeramicsAndChildren not skipped successfully.");
        return true; // Continue with the original method
    }
}



[HarmonyPatch(typeof(TowerSelectionMenu), nameof(TowerSelectionMenu.IsUpgradePathClosed))]
static class IsUpgradePathClosedPatch //
{
    [HarmonyPostfix]
    /// <summary>
    /// Notes: 
    /// - No Camos for Counter-Espionage or Radar Scanner
    /// - No Regrows for Grow Blocker
    /// - No Regrows OR life regen for Heart of Oak.
    /// </summary>
    private static void Postfix(TowerSelectionMenu __instance, int path, ref bool __result)
    {
        if (__instance.selectedTower == null) { return; }
        if (InGame.instance.bridge.IsSandboxMode()) { return; }

        if (InGame.instance.GetGameModel().gameMode.Contains("ClassicRounds-") && (!InGame.instance.GetGameModel().gameMode.Contains("6") || !InGame.instance.GetGameModel().gameMode.Contains("BATTD") || !InGame.instance.GetGameModel().gameMode.Contains("BTDB2")))
        {
            Il2CppAssets.Scripts.Simulation.Towers.Tower tower = __instance.selectedTower.tower;
            if (tower.towerModel.IsHero()) { return; }

            if (tower.GetUpgrade(path) == null) { return; }

            //foreach(var i in InGame.instance.GetAllTowerToSim().ToArray()) 
            //{ 
            //if( i.tower.model)
            //}

            string bid = tower.towerModel.baseId;
            string gamemode = InGame.instance.GetGameModel().gameMode;
            if (!gamemode.Contains("ClassicRounds-")) { return; }
            else
            {
                __result = false;
                if ((bid == "SuperMonkey" || bid == "SpikeFactory") && path == 2) { __result = true; return; } //No bottom path Super or Spike Factory
                if (gamemode.Contains("BTD3") && (bid == "MonkeyVillage" || bid == "NinjaMonkey") && path == 1) { __result = true; } //See summary
                if (gamemode.Contains("BTD3") && (bid == "MonkeyAce"  || bid == "HeliPilot" || bid == "Druid") && path == 1 && tower.GetUpgrade(path).tier >= 1) { __result = true; } //ditto
                if (gamemode.Contains("BTD3") && tower.GetUpgrade(path).tier >= 2) { __result = true; } //No tier 3s and up
                if (gamemode.Contains("BTD4") && tower.GetUpgrade(path).tier >= 3) { __result = true; } //No tier 4s and up
                //if (gamemode.Contains("BTD4") && bid == "SuperMonkey" && path == 0 && tower.GetUpgrade(path).tier == 4) { __result = false; } //(not always no) BTD4 Sun Temple
                if ((gamemode.Contains("BTD5") || gamemode.Contains("BTDB") ) && tower.GetUpgrade(path).tier >= 4) { __result = true; } //No tier 5s and up
            }
            return;
        }
    }
}

[HarmonyPatch(typeof(InGame), nameof(InGame.StartMatch))]
internal static class InGame_StartMatch
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
                if (b.Def.baseId.Contains("ClassicRounds-Classic") || (b.Def.bloonProperties & BloonProperties.Black) != 0)
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
                            if (!(t.HasUpgrade(0, 2) || t.HasUpgrade(2, 2)))
                            {
                                w.projectile.GetDescendant<DamageModel>().damage--;
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
                            if (t.HasUpgrade(1, 2)) { w.projectile.pierce--; }
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
                    }
                }
                if (t.baseId == "WizardMonkey")
                {
                    t.cost = Dart * 2;
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
                            if (name.Contains('5')) //Energy/Shatter => Plasma/Normal
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
                        }
                    }
                }
                if (t.baseId == "NinjaMonkey" && IsClassic(name))
                {
                    t.cost = Dart * 2.5f;
                    foreach (var a in t.GetAttackModels())
                    {
                        foreach (var w in a.weapons)
                        {
                            if (t.HasUpgrade(1, 2) && IsClassic(name) 
                                && w.projectile is not null 
                                && w.projectile.GetBehaviors<WindModel>() is not null)
                            {
                                a.weapons[0].projectile.RemoveBehaviors<WindModel>();
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
                                    w.projectile.GetDamageModel().immuneBloonProperties &= BloonProperties.Purple;
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