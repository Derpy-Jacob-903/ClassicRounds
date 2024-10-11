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

#pragma warning disable 1591
namespace ClassicRounds.bloons
{
    public class Olive : ModBloon //BTD4 Camo bloon without the Camo
    {
        public override string BaseBloon => BloonType.White;
        public override string Icon => "Olive";
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
    public class ClassicBlack : ModBloon //Pre BTD4 Black, has Yellow children
    {
        public override string BaseBloon => BloonType.Black;
        public override string Icon => VanillaSprites.Black;
        protected override int Order => 3;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = (Il2Cpp.BloonProperties)10;
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BloonType.Yellow, 2);
            bloonModel.layerNumber--;
        }
    }
    public class ClassicWhite : ModBloon //Pre BTD4 White, has Yellow children
    {
        public override string BaseBloon => BloonType.White;
        public override string Icon => VanillaSprites.White;
        protected override int Order => 2;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.bloonProperties = Il2Cpp.BloonProperties.White;
            bloonModel.AddTag("White");
            bloonModel.AddTag("Ice");
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BloonType.Yellow, 2);
            bloonModel.layerNumber--;
        }
    }
    public class ClassicLead : ModBloon
    {
        public override string BaseBloon => BloonType.Lead;
        public override string Icon => VanillaSprites.Lead;
        protected override int Order => 2;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.RemoveAllChildren();
            bloonModel.AddToChildren(BloonID<ClassicBlack>(), 2);
            bloonModel.layerNumber--;
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

    public class ClassicRainbow : ModBloon //Pre BTD4 Black, has Black and White children
    {
        public override string BaseBloon => BloonType.Rainbow;
        public override string Icon => VanillaSprites.Rainbow;
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

    public class ClassicCeramic : ModBloon ////BTD3 Ceramic, has 9 health And white properties
    {
        public override string BaseBloon => BloonType.Ceramic;
        public override string Icon => VanillaSprites.Ceramic;
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
    public class ClassicCeramicF : ModBloon<ClassicCeramic>
    {
        public override bool Fortified => true;
        public override string Icon => VanillaSprites.CeramicFortified;
        protected override int Order => 2;
        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            bloonModel.maxHealth = 20;
        }
    }
    public class ClassicMoab : ModBloon
    {
        public override string BaseBloon => BloonType.Moab;
        public override string Icon => VanillaSprites.MoabIcon;
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

namespace ClassicRounds.bloons.display
{
    public class ClassicBlackDisplay : ModBloonDisplay<ClassicBlack>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Black);

        public override string Name => base.Name + Damage;

        /// <summary>
        /// Still need an empty constructor for the type to be loaded
        /// </summary>
        public ClassicBlackDisplay()
        {
        }
    }
    public class ClassicWhiteDisplay : ModBloonDisplay<ClassicWhite>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.White);

        public override string Name => base.Name + Damage;

        /// <summary>
        /// Still need an empty constructor for the type to be loaded
        /// </summary>
        public ClassicWhiteDisplay()
        {
        }
    }
    public class ClassicLeadDisplay : ModBloonDisplay<ClassicLead>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Lead);

        public override string Name => base.Name + Damage;

        /// <summary>
        /// Still need an empty constructor for the type to be loaded
        /// </summary>
        public ClassicLeadDisplay()
        {
        }
    }
    public class ClassicLeadDisplayF : ModBloonDisplay<ClassicLeadF>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.LeadFortified);

        public override string Name => base.Name + Damage;

        /// <summary>
        /// Still need an empty constructor for the type to be loaded
        /// </summary>
        public ClassicLeadDisplayF()
        {
        }
    }
    public class ClassicRainbowDisplay : ModBloonDisplay<ClassicRainbow>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Rainbow);

        public override string Name => base.Name + Damage;

        /// <summary>
        /// Still need an empty constructor for the type to be loaded
        /// </summary>
        public ClassicRainbowDisplay()
        {
        }
    }

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
    public class ClassicCeramicDisplay : ModBloonDisplay<ClassicCeramic>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Ceramic, Damage);

        public override string Name => base.Name + Damage;

        /// <summary>
        /// Still need an empty constructor for the type to be loaded
        /// </summary>
        public ClassicCeramicDisplay()
        {
        }
        public override int Damage { get; }

        public ClassicCeramicDisplay(int damage)
        {
            Damage = damage;
        }

        public override IEnumerable<ModContent> Load()
        {
            for (var damage = 0; damage < 5; damage++)
            {
                yield return new ClassicCeramicDisplay(damage);
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