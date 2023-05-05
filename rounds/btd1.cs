using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Models.Bloons;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Models.Audio;
using Il2CppAssets.Scripts.Utils;

namespace ClassicTowers;
public abstract class BTD4 : ModRoundSet
{
    public override bool AddToOverrideMenu => true;
    public override int DefinedRounds => 5;
    public override SpriteReference IconReference => GetSpriteReferenceOrDefault("3f16ba2fac3822444818744a17789392");
    public override void ModifyRoundModels(RoundModel roundModel, int round)
    {
        if (round == 1)
        {
            roundModel.AddBloonGroup("Red", 14, 0f, 14f);
        }
        else if (round == 2)
        {
            roundModel.AddBloonGroup("Red", 30, 0f, 30f);
        }
        else if (round == 3)
        {
            roundModel.AddBloonGroup("Red", 10, 0f, 10f);
            roundModel.AddBloonGroup("Blue", 5, 10f, 15f);
            roundModel.AddBloonGroup("Red", 10, 15f, 25f);
        }
        else if (round == 4)
        {
            roundModel.AddBloonGroup("Red", 20, 0f, 20f);
            roundModel.AddBloonGroup("Blue", 15, 20f, 35f);
            roundModel.AddBloonGroup("Red", 10, 35f, 45f);
        }
        else if (round == 5)
        {
            roundModel.AddBloonGroup("Blue", 10, 0f, 10f);
            roundModel.AddBloonGroup("Red", 5, 20f, 15f);
            roundModel.AddBloonGroup("Blue", 10, 15f, 25f);
        }

    }
    
}