using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Models.Bloons;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppSystem;
using System;

namespace ClassicTowers.Bloons;
    public abstract class Olive : ModBloon //Pre BTD4 Black
{
    public override string BaseBloon => BloonType.Purple;
    //public override bool Camo => true;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.id = "Olive";
        bloonModel.baseId = "Olive";
        bloonModel.name = "Olive";
        //bloonModel.tags = ["Camo"];
        bloonModel.speed = 35.0f;
        bloonModel.Speed = 35.0f;
        bloonModel.AddToChildren(BloonType.Pink, 2); //Not Camo
        bloonModel.bloonProperties = 0;


    }
}
public class OliveRegrow : ModBloon<Olive>
{
    public override bool Regrow => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.MakeChildrenRegrow();
    }
}

public class OliveCamo : ModBloon<Olive>
{
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.MakeChildrenCamo();
    }
}

public class OliveRegrowCamo : ModBloon<Olive>
{
    public override bool Regrow => true;
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.MakeChildrenRegrow();
        bloonModel.MakeChildrenCamo();
    }
}
public abstract class ClassicBlack : ModBloon //Pre BTD4 Black
{
    public override string BaseBloon => BloonType.Black;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.id = "ClassicBlack";
        bloonModel.baseId = "ClassicBlack";
        bloonModel.name = "ClassicBlack";
        //bloonModel.tags = ["Camo"];
        //bloonModel.bloonProperties = 0;
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
        bloonModel.id = "ClassicWhite";
        bloonModel.baseId = "ClassicWhite";
        bloonModel.name = "ClassicWhite";
        //bloonModel.tags = ["Camo"];
        //bloonModel.bloonProperties = 0;
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
        bloonModel.id = "ClassicLead";
        bloonModel.baseId = "ClassicLead";
        bloonModel.name = "ClassicLead";
        //bloonModel.tags = ["Camo"];
        //bloonModel.bloonProperties = 0;
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren<ClassicBlack>(2);
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicRainbow : ModBloon
{
    public override string BaseBloon => BloonType.Rainbow;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.id = "ClassicRainbow";
        bloonModel.baseId = "ClassicRainbow";
        bloonModel.name = "ClassicRainbow";
        //bloonModel.tags = ["Camo"];
        //bloonModel.bloonProperties = 0;
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren<ClassicBlack>(2);
        bloonModel.AddToChildren<ClassicWhite>(2);
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicSuperRainbow : ModBloon<ClassicRainbow>
{
    public override string BaseBloon => BloonType.Rainbow;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.id = "ClassicSuperRainbow";
        bloonModel.baseId = "ClassicSuperRainbow";
        bloonModel.name = "ClassicSuperRainbow";
        //bloonModel.tags = ["Camo"];
        //bloonModel.bloonProperties = 0;
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren<ClassicSuperZebra>(1);
        bloonModel.layerNumber--;
    }
}

public abstract class ClassicSuperZebra : ModBloon
{
    public override string BaseBloon => BloonType.Zebra;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.id = "ClassicSuperZebra";
        bloonModel.baseId = "ClassicSuperZebra";
        bloonModel.name = "ClassicSuperZebra";

        //bloonModel.tags = ["Camo"];
        //bloonModel.bloonProperties = 0;
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
        bloonModel.id = "ClassicCeramic";
        bloonModel.baseId = "ClassicCeramic";
        bloonModel.name = "ClassicCeramic";
        //bloonModel.tags = ["Camo"];
        //bloonModel.bloonProperties = 0;
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren<ClassicRainbow>(1);
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicSuperCeramic : ModBloon<ClassicCeramic>
{
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.id = "ClassicSuperCeramic";
        bloonModel.baseId = "ClassicSuperCeramic";
        bloonModel.name = "ClassicSuperCeramic";
        //bloonModel.tags = ["Camo"];
        //bloonModel.bloonProperties = 0;
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren<ClassicSuperRainbow>(1);
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicMoab : ModBloon
{
    public override string BaseBloon => BloonType.Moab;
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.id = "ClassicMoab";
        bloonModel.baseId = "ClassicMoab";
        bloonModel.name = "ClassicMoab";
        //bloonModel.tags = ["Camo"];
        //bloonModel.bloonProperties = 0;
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren<ClassicCeramic>(4);
        bloonModel.layerNumber--;
    }
}
public abstract class ClassicSuperMoab : ModBloon<ClassicMoab>
{
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.id = "ClassicSuperMoab";
        bloonModel.baseId = "ClassicSuperMoab";
        bloonModel.name = "ClassicSuperMoab";
        //bloonModel.tags = ["Camo"];
        //bloonModel.bloonProperties = 0;
        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren<ClassicSuperCeramic>(4);
        bloonModel.layerNumber--;
    }
}