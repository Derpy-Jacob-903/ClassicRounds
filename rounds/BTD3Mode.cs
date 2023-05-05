using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper.Api;
//using ClassicTowers.Bloons;

namespace ClassicTowers.B3;

public class BTD3Mode : ModGameMode
{
    public override string Difficulty => DifficultyType.Medium;

    public override string BaseGameMode => GameModeType.None;

    public override string DisplayName => "BTD3";

    public override string Icon => VanillaSprites.RegrowBloonIcon;

    public override void ModifyBaseGameModeModel(ModModel gameModeModel)
    {
        gameModeModel.UseRoundSet(ModContent.GetInstance<BTD3>().Id);
    }
}
