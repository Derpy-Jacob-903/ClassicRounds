using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Models.Bloons;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppSystem;
using System;
using UnityEngine.UIElements;
using Il2CppNinjaKiwi.Common.ResourceUtils;

namespace ClassicRounds.bloons;

#pragma warning disable 1591
public abstract class Olive : ModBloon //BTD4 Camo bloon without the Camo
{
    public override string BaseBloon => BloonType.Purple;
    public override string Icon => "Oliv33";
    protected override int Order => 3;
    //public override bool Camo => true;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.speed = 35.0f;
        bloonModel.Speed = 35.0f;
        bloonModel.AddToChildren(BloonType.Pink); //Not Camo
        bloonModel.AddToChildren(BloonType.Pink);
        bloonModel.bloonProperties = 0;
    }
}
public abstract class ClassicBlack : ModBloon //Pre BTD4 Black, has Yellow children
{
    public override string BaseBloon => BloonType.Black;
    protected override int Order => 3;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.bloonProperties = (Il2Cpp.BloonProperties)10;
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonType.Yellow,2);
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicWhite : ModBloon //Pre BTD4 White, has Yellow children
{
    public override string BaseBloon => BloonType.White;
    protected override int Order => 2;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonType.Yellow, 2);
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicLead : ModBloon
{
    public override string BaseBloon => BloonType.Lead;
    protected override int Order => 2;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonID<ClassicBlack>(), 2);
        bloonModel.layerNumber--;
    }
}

public abstract class ClassicRainbow : ModBloon //Pre BTD4 Black, has Black and White children
{
    public override string BaseBloon => BloonType.Rainbow;
    protected override int Order => 2;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonID<ClassicBlack>());
        bloonModel.AddToChildren(BloonID<ClassicWhite>());
        bloonModel.AddToChildren(BloonID<ClassicBlack>());
        bloonModel.AddToChildren(BloonID<ClassicWhite>());
    }
}

public abstract class ClassicCeramic : ModBloon ////BTD3 Ceramic, has 9 health And white properties
{
    public override string BaseBloon => BloonType.Ceramic;
    protected override int Order => 2;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.bloonProperties = Il2Cpp.BloonProperties.White;
        bloonModel.maxHealth = 9;
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonID<ClassicRainbow>(), 2);
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicCeramicF : ModBloon<ClassicCeramic>
{
    public override bool Fortified => true;
    protected override int Order => 2;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.maxHealth = 32;
    }
}
public abstract class ClassicMoab : ModBloon
{
    public override string BaseBloon => BloonType.Moab;
    protected override int Order => 2;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonID<ClassicCeramic>(), 4);
        bloonModel.AddBehavior<BadImmunityModel>(new BadImmunityModel("BadImmunityModel_ClassicMoab"));
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicMoabf : ModBloon
{
    public override string BaseBloon => BloonType.MoabFortified;
    protected override int Order => 2;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonID<ClassicCeramicF>(), 4);
        bloonModel.AddBehavior<BadImmunityModel>(new BadImmunityModel("BadImmunityModel_ClassicMoab"));
        bloonModel.layerNumber--;
    }
}