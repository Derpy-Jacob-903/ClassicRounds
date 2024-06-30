using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Models.Bloons;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppSystem;
using System;
using UnityEngine.UIElements;
using Il2CppNinjaKiwi.Common.ResourceUtils;

namespace ClassicRounds.Bloons;

#pragma warning disable 1591
public abstract class Olive : ModBloon //BTD4 Camo bloon without the Camo
{
    public override string BaseBloon => BloonType.Purple;
    public override string Icon => "Oliv33";
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
public abstract class ClassicBlack : ModBloon //Pre BTD4 Black
{
    public override string BaseBloon => BloonType.Black;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.bloonProperties = (Il2Cpp.BloonProperties)10;
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonType.Yellow,2);
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicWhite : ModBloon
{
    public override string BaseBloon => BloonType.White;
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
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonID<ClassicBlack>(), 2);
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicIce : ModBloon
{
    public override string BaseBloon => BloonType.Lead;

    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.speed = 25;
        bloonModel.bloonProperties = (Il2Cpp.BloonProperties)20;
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonID<ClassicWhite>(),2);
        bloonModel.layerNumber--;
    }
}
public abstract class IceBloon : ModBloon
{
    public override string BaseBloon => BloonType.Lead;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.speed = 25;
        bloonModel.bloonProperties = Il2Cpp.BloonProperties.Frozen;
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonType.White,2);
        bloonModel.layerNumber--;
    }
}

public abstract class ClassicRainbow : ModBloon
{
    public override string BaseBloon => BloonType.Rainbow;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonID<ClassicBlack>());
        bloonModel.AddToChildren(BloonID<ClassicWhite>());
        bloonModel.AddToChildren(BloonID<ClassicBlack>());
        bloonModel.AddToChildren(BloonID<ClassicWhite>());
        bloonModel.layerNumber--;
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicSuperRainbow : ModBloon<ClassicRainbow>
{ 
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonID<ClassicSuperZebra>(), 1);
        bloonModel.layerNumber--;
        bloonModel.layerNumber--;
    }
}

public abstract class ClassicSuperZebra : ModBloon
{
    public override string BaseBloon => BloonType.Zebra;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonType.Yellow, 1);
        bloonModel.layerNumber--;
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicCeramic : ModBloon
{
    public override string BaseBloon => BloonType.Ceramic;
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
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.maxHealth = 32;
    }
}
public abstract class ClassicSuperCeramic : ModBloon<ClassicCeramic>
{
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.bloonProperties = Il2Cpp.BloonProperties.White;
        bloonModel.maxHealth = 9; // 54 
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonID<ClassicSuperRainbow>(), 1);
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicSuperCeramicF : ModBloon<ClassicSuperCeramic>
{
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.bloonProperties = Il2Cpp.BloonProperties.White;
        bloonModel.maxHealth = 32; // 192 
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonID<ClassicRainbow>(), 2);
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicDreadrock : ModBloon
{
    public override string BaseBloon => "DreadRockBloonStandard1";
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.RemoveAllChildren();
        bloonModel.maxHealth = 300;
        bloonModel.AddToChildren(BloonID<ClassicRainbow>(), 2);
    }
}
public abstract class ClassicMoab : ModBloon
{
    public override string BaseBloon => BloonType.Moab;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonID<ClassicCeramic>(), 4);
        bloonModel.AddBehavior<BadImmunityModel>(new BadImmunityModel("BadImmunityModel_ClassicMoab"));
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicSuperMoab : ModBloon<ClassicMoab>
{
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonID<ClassicSuperCeramic>(), 4);
        bloonModel.AddBehavior<BadImmunityModel>(new BadImmunityModel("BadImmunityModel_ClassicMoab"));
        bloonModel.layerNumber--;
    }
}