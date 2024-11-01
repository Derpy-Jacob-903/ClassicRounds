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
using Il2Cpp;

#pragma warning disable 1591
namespace ClassicRounds.Bloons
{
    public class Olive : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.White;
        public override string Icon => "Olive";
        protected override int Order => 2;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed = 35.0f;
            bloonModel.Speed = 35.0f;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BloonType.Pink); //Not Camo
            bloonModel.AddToChildren(BloonType.Pink);
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
    public class Glass : ModBloon //BSM2 Glass bloon
    {
        public override string BaseBloon => BloonType.Ceramic;
        public override string Icon => "Glass";
        public override IEnumerable<string> DamageStates => ["Glass" , "GlassDamaged"];
        protected override int Order => 2;
        //public override bool Camo => true;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.speed = 27.75f; //lead * (white/black)
            bloonModel.Speed = 27.75f;
            //bloonModel.speed = 45.0f; //purple = 75 //lead = 25
            //bloonModel.Speed = 45.0f; //zebra = 45 //cermic 62.5
            bloonModel.maxHealth = 5;
            bloonModel.leakDamage = 5;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BloonType.White);
            bloonModel.AddToChildren(BloonType.White);
            bloonModel.danger = 7.5f;
            bloonModel.bloonProperties = BloonProperties.Purple;
        }
    }
    public class GlassRegrow : ModBloon<Glass>
    {
        public override bool Regrow => true;
        public override IEnumerable<string> DamageStates => ["GlassRegrow", "GlassRegrowDamaged"];

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
        }
    }

    public class GlassCamo : ModBloon<Glass>
    {
        public override bool Camo => true;
        public override IEnumerable<string> DamageStates => ["GlassCamo", "GlassCamoDamaged"];

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }

    public class GlassRegrowCamo : ModBloon<Glass>
    {
        public override bool Regrow => true;
        public override bool Camo => true;
        public override IEnumerable<string> DamageStates => ["GlassRegrowCamo", "GlassRegrowCamoDamaged"];

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenRegrow();
            bloonModel.MakeChildrenCamo();
        }
    }
    public class ClassicRed : ModBloon //Pre BTD4 Black, has Yellow children
    {
        public override string BaseBloon => BloonType.Red;
        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {

        }
    }
    public class ClassicRedCamo : ModBloon<ClassicRed>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class ClassicBlue : ModBloon //Pre BTD4 Black, has Yellow children
    {
        public override string BaseBloon => BloonType.Blue;
        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = 0;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren<ClassicRed>(1);
            bloonModel.layerNumber--;
        }
    }
    public class ClassicBlueCamo : ModBloon<ClassicBlue>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class ClassicGreen : ModBloon //Pre BTD4 Black, has Yellow children
    {
        public override string BaseBloon => BloonType.Green;
        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = 0;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren<ClassicBlue>(1);
            bloonModel.layerNumber--;
        }
    }
    public class ClassicGreenCamo : ModBloon<ClassicGreen>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class ClassicYellow : ModBloon //Pre BTD4 Black, has Yellow children
    {
        public override string BaseBloon => BloonType.Yellow;
        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = 0;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren<ClassicGreen>(1);
            bloonModel.layerNumber--;
        }
    }
    public class ClassicYellowCamo : ModBloon<ClassicYellow>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class ClassicBlack : ModBloon //Pre BTD4 Black, has Yellow children
    {
        public override string BaseBloon => BloonType.Black;
        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = Il2Cpp.BloonProperties.Black;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren<ClassicYellow>(2);
            bloonModel.layerNumber--;
        }
    }
    public class ClassicBlackCamo : ModBloon<ClassicBlack>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class ClassicWhite : ModBloon //Pre BTD4 White, has Yellow children
    {
        public override string BaseBloon => BloonType.White;
        protected override int Order => 2;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = Il2Cpp.BloonProperties.White;
            bloonModel.AddTag("White");
            bloonModel.AddTag("Ice");
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren<ClassicYellow>(2);
            bloonModel.layerNumber--;
        }
    }
    public class ClassicWhiteCamo : ModBloon<ClassicWhite>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class ClassicLead : ModBloon
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
    public class ClassicLeadCamo : ModBloon<ClassicLead>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class ClassicLeadF : ModBloon<ClassicLead>
    {
        public override bool Fortified => true;
        public override string Icon => VanillaSprites.LeadFortified;
        protected override int Order => 2;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.maxHealth = 4;
        }
    }
    public class ClassicLeadFCamo : ModBloon<ClassicLead>
    {
        public override bool Camo => true;
        public override bool Fortified => true;
        public override string Icon => VanillaSprites.LeadFortifiedCamo;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
            bloonModel.maxHealth = 4;
        }
    }

    public class ClassicRainbow : ModBloon //Pre BTD4 Black, has Black and White children
    {
        public override string BaseBloon => BloonType.Rainbow;
        protected override int Order => 2;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BloonID<ClassicWhite>());
            bloonModel.AddToChildren(BloonID<ClassicBlack>());
            bloonModel.AddToChildren(BloonID<ClassicWhite>());
            bloonModel.AddToChildren(BloonID<ClassicBlack>());
        }
    }
    public class ClassicRainbowCamo : ModBloon<ClassicRainbow>
    {
        public override bool Camo => true;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }

    public class ClassicCeramic : ModBloon ////BTD3 Ceramic, has 9 health And white properties
    {
        public override string BaseBloon => BloonType.Ceramic;
        public override IEnumerable<string> DamageStates => ["ClassicBrown", "ClassicBrown-1", "ClassicBrown-2", "ClassicBrown-3", "ClassicBrown-4", "ClassicBrown-5", "ClassicBrown-6", "ClassicBrown-7"];
        protected override int Order => 2;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = Il2Cpp.BloonProperties.White;
            //bloonModel.AddTag("Ceramic");
            bloonModel.AddTag("White");
            bloonModel.AddTag("Ice");
            bloonModel.maxHealth = 9;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BloonID<ClassicRainbow>(), 2);
            bloonModel.layerNumber--;
        }
    }
    public class ClassicCeramicCamo : ModBloon<ClassicCeramic>
    {
        public override bool Camo => true;
        public override IEnumerable<string> DamageStates => ["ClassicBrownCamo", "ClassicBrownCamo-1", "ClassicBrownCamo-2", "ClassicBrownCamo-3", "ClassicBrownCamo-4", "ClassicBrownCamo-5", "ClassicBrownCamo-6", "ClassicBrownCamo-7"];

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.MakeChildrenCamo();
        }
    }
    public class ClassicCeramicF : ModBloon<ClassicCeramic>
    {
        public override bool Fortified => true;
        public override string Icon => VanillaSprites.CeramicFortified;
        protected override int Order => 2;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.maxHealth = 18;
        }
    }
    public class ClassicCeramicFCamo : ModBloon<ClassicCeramic>
    {
        public override bool Fortified => true;
        public override bool Camo => true;
        public override string Icon => VanillaSprites.CeramicFortifiedCamo;

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.maxHealth = 18;
            bloonModel.MakeChildrenCamo();
        }
    }
    public class ClassicMoab : ModBloon
    {
        public override string BaseBloon => BloonType.Moab;
        public override string Icon => VanillaSprites.Btd4RetroMoabIcon;
        protected override int Order => 2;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BloonID<ClassicCeramic>(), 4);
            bloonModel.AddBehavior<BadImmunityModel>(new BadImmunityModel("BadImmunityModel_ClassicMoab"));
        }
    }
    public class ClassicMoabF : ModBloon
    {
        public override string BaseBloon => BloonType.MoabFortified;
        public override string Icon => VanillaSprites.MoabFortifiedIcon;
        protected override int Order => 2;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BloonID<ClassicCeramicF>(), 4);
            bloonModel.maxHealth = 400;
            bloonModel.AddBehavior<BadImmunityModel>(new BadImmunityModel("BadImmunityModel_ClassicMoab"));
        }
    }
}

namespace ClassicRounds.Bloons.Display
{
    public class ClassicCeramicDisplayF : ModBloonDisplay<ClassicCeramicF>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.CeramicFortified, Damage);

        public override string Name => base.Name + Damage;

        /// <summary>
        /// Still need an empty constructor for the type to be loaded
        /// </summary>
        public ClassicCeramicDisplayF()
        {
        }
        public override int Damage { get; }

        public ClassicCeramicDisplayF(int damage)
        {
            Damage = damage;
        }

        public override IEnumerable<ModContent> Load()
        {
            for (var damage = 0; damage < 5; damage++)
            {
                yield return new ClassicCeramicDisplayF(damage);
            }
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            //foreach (var meshRenderer in node.GetMeshRenderers())
            //{
            //meshRenderer.SetMainTexture(GetTexture(Name)!);
            //}
        }
    }
    public class ClassicMoabDisplay : ModBloonDisplay<ClassicMoab>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Moab, Damage);

        public override string Name => base.Name + Damage;

        /// <summary>
        /// Still need an empty constructor for the type to be loaded
        /// </summary>
        public ClassicMoabDisplay()
        {
        }
        public override int Damage { get; }

        public ClassicMoabDisplay(int damage)
        {
            Damage = damage;
        }

        public override IEnumerable<ModContent> Load()
        {
            for (var damage = 0; damage < 5; damage++)
            {
                yield return new ClassicMoabDisplay(damage);
            }
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            //foreach (var meshRenderer in node.GetMeshRenderers())
            //{
                //meshRenderer.SetMainTexture(GetTexture(Name)!);
            //}
        }
    }
    public class ClassicMoabDisplayf : ModBloonDisplay<ClassicMoabF>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.MoabFortified, Damage);

        public override string Name => base.Name + Damage;

        /// <summary>
        /// Still need an empty constructor for the type to be loaded
        /// </summary>
        public ClassicMoabDisplayf()
        {
        }
        public override int Damage { get; }

        public ClassicMoabDisplayf(int damage)
        {
            Damage = damage;
        }

        public override IEnumerable<ModContent> Load()
        {
            for (var damage = 0; damage < 5; damage++)
            {
                yield return new ClassicMoabDisplayf(damage);
            }
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            //foreach (var meshRenderer in node.GetMeshRenderers())
            //{
            //meshRenderer.SetMainTexture(GetTexture(Name)!);
            //}
        }
    }
}