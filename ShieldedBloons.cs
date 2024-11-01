using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Models.Bloons;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppSystem;
using System;
using UnityEngine.UIElements;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.Display;
using System.Collections.Generic;
using ClassicRounds.Bloons;

#pragma warning disable 1591
namespace ClassicRounds.Bloons
{

    public class RedShielded : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Red;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.maxHealth = 1;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BloonType.Red); //Not Camo
            bloonModel.AddBehavior(new BadImmunityModel("BadImmunityModel_ShieldedBloon"));

            bloonModel.AddTag("Moabs");
            bloonModel.AddTag("Boss");
            bloonModel.AddTag("Bad");
            bloonModel.AddTag("Shielded");
            bloonModel.AddTag(BaseBloon);
        }
    }

    public class RedShieldedCamo : ModBloon<RedShielded>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class BlueShielded : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Blue;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.maxHealth = 2;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BloonType.Blue); //Not Camo
            bloonModel.AddBehavior(new BadImmunityModel("BadImmunityModel_ShieldedBloon"));

            bloonModel.AddTag("Moabs");
            bloonModel.AddTag("Boss");
            bloonModel.AddTag("Bad");
            bloonModel.AddTag("Shielded");
            bloonModel.AddTag(BaseBloon);
        }
    }

    public class BlueShieldedCamo : ModBloon<BlueShielded>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class GreenShielded : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Green;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.maxHealth = 3;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BaseBloon); //Not Camo
            bloonModel.AddBehavior(new BadImmunityModel("BadImmunityModel_ShieldedBloon"));

            bloonModel.AddTag("Moabs");
            bloonModel.AddTag("Boss");
            bloonModel.AddTag("Bad");
            bloonModel.AddTag("Shielded");
            bloonModel.AddTag(BaseBloon);
        }
    }
    public class GreenShieldedCamo : ModBloon<GreenShielded>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class YellowShielded : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Yellow;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.maxHealth = 4;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BaseBloon); //Not Camo
            bloonModel.AddBehavior(new BadImmunityModel("BadImmunityModel_ShieldedBloon"));

            bloonModel.AddTag("Moabs");
            bloonModel.AddTag("Boss");
            bloonModel.AddTag("Bad");
            bloonModel.AddTag("Shielded");
            bloonModel.AddTag(BaseBloon);
        }
    }
    public class YellowShieldedCamo : ModBloon<YellowShielded>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class PinkShielded : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Pink;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.maxHealth = 5;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BaseBloon); //Not Camo
            bloonModel.AddBehavior(new BadImmunityModel("BadImmunityModel_ShieldedBloon"));

            bloonModel.AddTag("Moabs");
            bloonModel.AddTag("Boss");
            bloonModel.AddTag("Bad");
            bloonModel.AddTag("Shielded");
            bloonModel.AddTag(BaseBloon);
        }
    }
    public class PinkShieldedCamo : ModBloon<PinkShielded>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class BlackShielded : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Black;
        public override bool KeepBaseId => false;
        protected override int Order => 3;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = Il2Cpp.BloonProperties.White;
            bloonModel.maxHealth = 8;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren("Black", 1);
            bloonModel.AddBehavior(new BadImmunityModel("BadImmunityModel_ShieldedBloon"));

            bloonModel.AddTag("Boss");
            bloonModel.AddTag("Bad");
            bloonModel.AddTag("Shielded");
            bloonModel.AddTag(BaseBloon);
        }
    }

    public class BlackShieldedCamo : ModBloon<BlackShielded>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class WhiteShielded : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.White;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = Il2Cpp.BloonProperties.White;
            bloonModel.maxHealth = 8;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BaseBloon); //Not Camo
            bloonModel.AddBehavior(new BadImmunityModel("BadImmunityModel_ShieldedBloon"));
            bloonModel.AddTag("Boss");
            bloonModel.AddTag("Bad");
            bloonModel.AddTag("Shielded");
            bloonModel.AddTag(BaseBloon);
        }
    }

    public class WhiteShieldedCamo : ModBloon<WhiteShielded>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class PurpleShielded : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Purple;
        public override bool KeepBaseId => false;
        protected override int Order => 3;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = Il2Cpp.BloonProperties.White;
            bloonModel.maxHealth = 8;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BaseBloon); //Not Camo
            bloonModel.AddBehavior(new BadImmunityModel("BadImmunityModel_ShieldedBloon"));
            bloonModel.AddTag("Boss");
            bloonModel.AddTag("Bad");
            bloonModel.AddTag("Shielded");
            bloonModel.AddTag(BaseBloon);
        }
    }

    public class PurpleShieldedCamo : ModBloon<PurpleShielded>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class ZebraShielded : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Zebra;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = Il2Cpp.BloonProperties.White;
            bloonModel.maxHealth = 11;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BaseBloon); //Not Camo
            bloonModel.AddBehavior(new BadImmunityModel("BadImmunityModel_ShieldedBloon"));
            bloonModel.AddTag("Boss");
            bloonModel.AddTag("Bad");
            bloonModel.AddTag("Shielded");
            bloonModel.AddTag(BaseBloon);
        }
    }
    public class ZebraShieldedCamo : ModBloon<ZebraShielded>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class LeadShielded : ModBloon
    {
        public override string BaseBloon => BloonType.Lead;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = Il2Cpp.BloonProperties.White;
            bloonModel.maxHealth = 11;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BaseBloon);
            bloonModel.AddBehavior(new BadImmunityModel("BadImmunityModel_ShieldedBloon"));
            bloonModel.AddTag("Boss");
            bloonModel.AddTag("Bad");
            bloonModel.AddTag("Shielded");
            bloonModel.AddTag(BaseBloon);
        }
    }
    public class LeadShieldedCamo : ModBloon<LeadShielded>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class LeadShieldedFortified : ModBloon<LeadShielded>
    {
        public override bool Fortified => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenFortified();
        }
    }
    public class LeadShieldedFortifiedCamo : ModBloon<LeadShielded>
    {
        public override bool Camo => true;
        public override bool Fortified => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenFortified();
            bloonModel.MakeChildrenCamo();
        }
    }
    public class GlassShielded : ModBloon
    {
        public override string BaseBloon => "ClassicRounds-Glass";
        public override bool KeepBaseId => false;

        protected override int Order => 4;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = Il2Cpp.BloonProperties.White;
            bloonModel.maxHealth = 11;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BaseBloon);
            bloonModel.AddBehavior(new BadImmunityModel("BadImmunityModel_ShieldedBloon"));
            bloonModel.AddTag("Boss");
            bloonModel.AddTag("Bad");
            bloonModel.AddTag("Shielded");
            bloonModel.AddTag(BaseBloon);
        }
    }
    public class GlassShieldedCamo : ModBloon<GlassShielded>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class RainbowShielded : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Rainbow;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = Il2Cpp.BloonProperties.None;
            bloonModel.maxHealth = 15;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BaseBloon); //Not Camo
            bloonModel.AddBehavior(new BadImmunityModel("BadImmunityModel_ShieldedBloon"));
            bloonModel.AddTag("Boss");
            bloonModel.AddTag("Bad");
            bloonModel.AddTag("Shielded");
            bloonModel.AddTag(BaseBloon);
        }
    }
    public class RainbowShieldedCamo : ModBloon<RainbowShielded>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class CeramicShielded : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Ceramic;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = Il2Cpp.BloonProperties.None;
            bloonModel.maxHealth = 15;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BaseBloon); //Not Camo
            bloonModel.AddBehavior(new BadImmunityModel("BadImmunityModel_ShieldedBloon"));
            bloonModel.AddTag("Boss");
            bloonModel.AddTag("Bad");
            bloonModel.AddTag("Shielded");
            bloonModel.AddTag(BaseBloon);
        }
    }
    public class CeramicShieldedCamo : ModBloon<CeramicShielded>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class CeramicShieldedFortified : ModBloon<CeramicShielded>
    {
        public override bool Fortified => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenFortified();
        }
    }
    public class CeramicShieldedFortifiedCamo : ModBloon<CeramicShielded>
    {
        public override bool Camo => true;
        public override bool Fortified => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenFortified();
            bloonModel.MakeChildrenCamo();
        }
    }
}
namespace ClassicRounds.Bloons.Tattered
{
    public class RedTattered : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Red;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed *= 2;
            bloonModel.Speed *= 2;
            bloonModel.AddTag(BaseBloon);
            bloonModel.AddTag("Tattered");
        }
    }
    public class RedTatteredCamo : ModBloon<RedTattered>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class RedTatteredRegrow : ModBloon<RedTattered>
    {
        public override bool Regrow => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
        }
    }
    public class RedTatteredRegrowCamo : ModBloon<RedTattered>
    {
        public override bool Regrow => true;
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
            bloonModel.MakeChildrenCamo();
        }
    }
    public class BlueTattered : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Blue;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed *= 2;
            bloonModel.Speed *= 2;
            bloonModel.AddTag(BaseBloon);
            bloonModel.AddTag("Tattered");
        }
    }
    public class BlueTatteredCamo : ModBloon<BlueTattered>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class BlueTatteredRegrow : ModBloon<BlueTattered>
    {
        public override bool Regrow => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
        }
    }
    public class BlueTatteredRegrowCamo : ModBloon<BlueTattered>
    {
        public override bool Regrow => true;
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
            bloonModel.MakeChildrenCamo();
        }
    }
    public class GreenTattered : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Green;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed *= 2;
            bloonModel.Speed *= 2;
            bloonModel.AddTag(BaseBloon);
            bloonModel.AddTag("Tattered");
        }
    }
    public class GreenTatteredCamo : ModBloon<GreenTattered>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class GreenTatteredRegrow : ModBloon<GreenTattered>
    {
        public override bool Regrow => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
        }
    }
    public class GreenTatteredRegrowCamo : ModBloon<GreenTattered>
    {
        public override bool Regrow => true;
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
            bloonModel.MakeChildrenCamo();
        }
    }
    public class YellowTattered : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Yellow;
        public override bool KeepBaseId => false;
        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed *= 2;
            bloonModel.Speed *= 2;
            bloonModel.AddTag(BaseBloon);
            bloonModel.AddTag("Tattered");
        }
    }
    public class YellowTatteredCamo : ModBloon<YellowTattered>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class YellowTatteredRegrow : ModBloon<YellowTattered>
    {
        public override bool Regrow => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
        }
    }
    public class YellowTatteredRegrowCamo : ModBloon<YellowTattered>
    {
        public override bool Regrow => true;
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
            bloonModel.MakeChildrenCamo();
        }
    }
    public class PinkTattered : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Pink;
        public override bool KeepBaseId => false;
        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed *= 2;
            bloonModel.Speed *= 2;
            bloonModel.AddTag(BaseBloon);
            bloonModel.AddTag("Tattered");
        }
    }
    public class PinkTatteredCamo : ModBloon<PinkTattered>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class PinkTatteredRegrow : ModBloon<PinkTattered>
    {
        public override bool Regrow => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
        }
    }
    public class PinkTatteredRegrowCamo : ModBloon<PinkTattered>
    {
        public override bool Regrow => true;
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
            bloonModel.MakeChildrenCamo();
        }
    }
    public class WhiteTattered : ModBloon 
    {
        public override string BaseBloon => BloonType.White;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed *= 2;
            bloonModel.Speed *= 2;
            bloonModel.AddTag(BaseBloon);
            bloonModel.AddTag("Tattered");
        }
    }
    public class WhiteTatteredCamo : ModBloon<WhiteTattered>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class WhiteTatteredRegrow : ModBloon<WhiteTattered>
    {
        public override bool Regrow => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
        }
    }
    public class WhiteTatteredRegrowCamo : ModBloon<WhiteTattered>
    {
        public override bool Regrow => true;
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
            bloonModel.MakeChildrenCamo();
        }
    }
    public class BlackTattered : ModBloon
    {
        public override string BaseBloon => BloonType.Black;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed *= 2;
            bloonModel.Speed *= 2;
            bloonModel.AddTag(BaseBloon);
            bloonModel.AddTag("Tattered");
        }
    }
    public class BlackTatteredCamo : ModBloon<BlackTattered>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class BlackTatteredRegrow : ModBloon<BlackTattered>
    {
        public override bool Regrow => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
        }
    }
    public class BlackTatteredRegrowCamo : ModBloon<BlackTattered>
    {
        public override bool Regrow => true;
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
            bloonModel.MakeChildrenCamo();
        }
    }
    public class PurpleTattered : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Purple;
        public override bool KeepBaseId => false;

        protected override int Order => 3;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed *= 2;
            bloonModel.Speed *= 2;
            bloonModel.AddTag(BaseBloon);
            bloonModel.AddTag("Tattered");
        }
    }
    public class PurpleTatteredCamo : ModBloon<PurpleTattered>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class PurpleTatteredRegrow : ModBloon<PurpleTattered>
    {
        public override bool Regrow => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
        }
    }
    public class PurpleTatteredRegrowCamo : ModBloon<PurpleTattered>
    {
        public override bool Regrow => true;
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
            bloonModel.MakeChildrenCamo();
        }
    }
    public class LeadTattered : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Lead;
        public override bool KeepBaseId => false;
        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed *= 2;
            bloonModel.Speed *= 2;
            bloonModel.AddTag(BaseBloon);
            bloonModel.AddTag("Tattered");
        }
    }
    public class LeadTatteredCamo : ModBloon<LeadTattered>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class LeadTatteredRegrow : ModBloon<LeadTattered>
    {
        public override bool Regrow => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
        }
    }
    public class LeadTatteredRegrowCamo : ModBloon<LeadTattered>
    {
        public override bool Regrow => true;
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
            bloonModel.MakeChildrenCamo();
        }
    }
    public class GlassTattered : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => "ClassicRounds-Glass";
        public override IEnumerable<string> DamageStates => ["GlassTattered", "GlassTatteredDamaged"];
        public override bool KeepBaseId => false;
        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed *= 2;
            bloonModel.Speed *= 2;
            bloonModel.AddTag(BaseBloon);
            bloonModel.AddTag("Tattered");
        }
    }
    public class GlassTatteredCamo : ModBloon<GlassTattered>
    {
        public override bool Camo => true;
        public override IEnumerable<string> DamageStates => ["GlassTatteredCamo", "GlassTatteredCamoDamaged"];

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class GlassTatteredRegrow : ModBloon<GlassTattered>
    {
        public override bool Regrow => true;
        public override IEnumerable<string> DamageStates => ["GlassTatteredRegrow", "GlassTatteredRegrowDamaged"];

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
        }
    }
    public class GlassTatteredRegrowCamo : ModBloon<GlassTattered>
    {
        public override bool Regrow => true;
        public override bool Camo => true;
        public override IEnumerable<string> DamageStates => ["GlassTatteredRegrowCamo", "GlassTatteredRegrowCamoDamaged"];

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
            bloonModel.MakeChildrenCamo();
        }
    }
    public class ZebraTattered : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Zebra;
        public override bool KeepBaseId => false;
        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed *= 2;
            bloonModel.Speed *= 2;
            bloonModel.AddTag(BaseBloon);
            bloonModel.AddTag("Tattered");
        }
    }
    public class ZebraTatteredCamo : ModBloon<ZebraTattered>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class ZebraTatteredRegrow : ModBloon<ZebraTattered>
    {
        public override bool Regrow => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
        }
    }
    public class ZebraTatteredRegrowCamo : ModBloon<ZebraTattered>
    {
        public override bool Regrow => true;
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
            bloonModel.MakeChildrenCamo();
        }
    }
    public class CeramicTattered : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Ceramic;
        public override bool KeepBaseId => false;
        public override IEnumerable<string> DamageStates => ["CeramicTattered"];
        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed *= 2;
            bloonModel.Speed *= 2;
            bloonModel.AddTag(BaseBloon);
            bloonModel.AddTag("Tattered");
        }
    }
    public class CeramicTatteredCamo : ModBloon<CeramicTattered>
    {
        public override bool Camo => true;
        public override IEnumerable<string> DamageStates => ["CeramicTatteredCamo"];

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class CeramicTatteredRegrow : ModBloon<CeramicTattered>
    {
        public override bool Regrow => true;
        public override IEnumerable<string> DamageStates => ["CeramicTatteredRegrow"];

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
        }
    }
    public class CeramicTatteredRegrowCamo : ModBloon<CeramicTattered>
    {
        public override bool Regrow => true;
        public override bool Camo => true;
        public override IEnumerable<string> DamageStates => ["CeramicTatteredRegrowCamo"];

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
            bloonModel.MakeChildrenCamo();
        }
    }
    public class RainbowTattered : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Rainbow;
        public override bool KeepBaseId => false;
        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed *= 2;
            bloonModel.Speed *= 2;
            bloonModel.AddTag(BaseBloon);
            bloonModel.AddTag("Tattered");
        }
    }
    public class RainbowTatteredCamo : ModBloon<RainbowTattered>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class RainbowTatteredRegrow : ModBloon<RainbowTattered>
    {
        public override bool Regrow => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
        }
    }
    public class RainbowTatteredRegrowCamo : ModBloon<RainbowTattered>
    {
        public override bool Regrow => true;
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
            bloonModel.MakeChildrenCamo();
        }
    }
}
namespace ClassicRounds.Bloons.Unstable
{
    public class BlueUnstable : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Blue;
        protected override int Order => 4;
        public override bool KeepBaseId => false;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BaseBloon);
            bloonModel.AddToChildren(BaseBloon);
            bloonModel.AddToChildren(BaseBloon);

            bloonModel.AddTag("Unstable");
            bloonModel.AddTag(BaseBloon);

            SpawnBloonsActionModel x = new SpawnBloonsActionModel("SpawnBloonsActionModel_" + bloonModel.baseId + "Stuffed", "StuffedSpawn", BloonType.Red, //
                10, 0.06f, 0.0f, 0.2f, 0.8f,
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStringArray(0),
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStringArray(0), 0.0f, false, bloonModel.baseId + "Stuffed");
            HealthPercentTriggerModel y = new HealthPercentTriggerModel("SpawnBloonsActionModel_" + bloonModel.baseId + "Stuffed", false,
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray<float>([0.001f]),
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStringArray(["StuffedSpawn"]), false);
            bloonModel.AddBehavior(x);
            bloonModel.AddBehavior(y);
        }
    }
    public class BlueUnstableCamo : ModBloon<BlueUnstable>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
            bloonModel.GetBehavior<SpawnBloonsActionModel>().bloonType = bloonModel.GetBehavior<SpawnBloonsActionModel>().bloonType + "Camo";
        }
    }
    public class GreenUnstable : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Green;
        protected override int Order => 4;
        public override bool KeepBaseId => false;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BaseBloon);
            bloonModel.AddToChildren(BaseBloon);
            bloonModel.AddToChildren(BaseBloon);

            bloonModel.AddTag("Unstable");
            bloonModel.AddTag(BaseBloon);

            SpawnBloonsActionModel x = new SpawnBloonsActionModel("SpawnBloonsActionModel_" + bloonModel.baseId + "Stuffed", "StuffedSpawn", BloonType.Blue, //
                10, 0.06f, 0.0f, 0.2f, 0.8f,
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStringArray(0),
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStringArray(0), 0.0f, false, bloonModel.baseId + "Stuffed");
            HealthPercentTriggerModel y = new HealthPercentTriggerModel("SpawnBloonsActionModel_" + bloonModel.baseId + "Stuffed", false,
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray<float>([0.001f]),
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStringArray(["StuffedSpawn"]), false);
            bloonModel.AddBehavior(x);
            bloonModel.AddBehavior(y);
        }
    }
    public class GreenUnstableCamo : ModBloon<GreenUnstable>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
            bloonModel.GetBehavior<SpawnBloonsActionModel>().bloonType = bloonModel.GetBehavior<SpawnBloonsActionModel>().bloonType + "Camo";
        }
    }
    public class YellowUnstable : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Yellow;
        protected override int Order => 4;
        public override bool KeepBaseId => false;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BaseBloon);
            bloonModel.AddToChildren(BaseBloon);
            bloonModel.AddToChildren(BaseBloon);

            bloonModel.AddTag("Unstable");
            bloonModel.AddTag(BaseBloon);

            SpawnBloonsActionModel x = new SpawnBloonsActionModel("SpawnBloonsActionModel_" + bloonModel.baseId + "Stuffed", "StuffedSpawn", BloonType.Green, //
                10, 0.06f, 0.0f, 0.2f, 0.8f,
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStringArray(0),
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStringArray(0), 0.0f, false, bloonModel.baseId + "Stuffed");
            HealthPercentTriggerModel y = new HealthPercentTriggerModel("SpawnBloonsActionModel_" + bloonModel.baseId + "Stuffed", false,
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray<float>([0.001f]),
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStringArray(["StuffedSpawn"]), false);
            bloonModel.AddBehavior(x);
            bloonModel.AddBehavior(y);
        }
    }
    public class YellowUnstableCamo : ModBloon<YellowUnstable>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
            bloonModel.GetBehavior<SpawnBloonsActionModel>().bloonType = bloonModel.GetBehavior<SpawnBloonsActionModel>().bloonType + "Camo";
        }
    }
    public class PinkUnstable : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.Pink;
        protected override int Order => 4;
        public override bool KeepBaseId => false;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BaseBloon);
            bloonModel.AddToChildren(BaseBloon);
            bloonModel.AddToChildren(BaseBloon);

            bloonModel.AddTag("Unstable");
            bloonModel.AddTag(BaseBloon);

            SpawnBloonsActionModel x = new SpawnBloonsActionModel("SpawnBloonsActionModel_" + bloonModel.baseId + "Stuffed", "StuffedSpawn", BloonType.Yellow, //
                10, 0.06f, 0.0f, 0.2f, 0.8f,
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStringArray(0),
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStringArray(0), 0.0f, false, bloonModel.baseId + "Stuffed");
            HealthPercentTriggerModel y = new HealthPercentTriggerModel("SpawnBloonsActionModel_" + bloonModel.baseId + "Stuffed", false,
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray<float>([0.001f]),
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStringArray(["StuffedSpawn"]), false);
            bloonModel.AddBehavior(x);
            bloonModel.AddBehavior(y);
        }
    }
    public class PinkUnstableCamo : ModBloon<PinkUnstable>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
            bloonModel.GetBehavior<SpawnBloonsActionModel>().bloonType = bloonModel.GetBehavior<SpawnBloonsActionModel>().bloonType + "Camo";
        }
    }
}