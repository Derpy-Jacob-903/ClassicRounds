using MelonLoader;
using BTD_Mod_Helper;
using ClassicTowers;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Unity.UI_New.Main.DifficultySelect;
using Il2Cpp;
using Il2CppAssets.Scripts.Unity.UI_New.Main.ModeSelect;
using Il2CppAssets.Scripts.Unity.Menu;
using BTD_Mod_Helper.Extensions;

[assembly: MelonInfo(typeof(ClassicTowers.ClassicTowers), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace ClassicTowers;

public class ClassicTowers : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<ClassicTowers>("ClassicTowers loaded!");
    }
}