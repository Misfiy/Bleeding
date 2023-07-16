using Exiled.API.Interfaces;
using Exiled.API.Enums;
using PlayerRoles;
using System.ComponentModel;

namespace BleedingPlugin
{
     public sealed class Config : IConfig
     {
          public bool IsEnabled { get; set; } = true;
          public bool Debug { get; set; } = false;
          [Description("Whether or not SCPs can bleed. SCPs CANNOT get rid of bleeding, this should be kept false.")]
          public bool CanScpsBleed { get; set; } = false;
          [Description("Which damage types should cause bleeding")]
          public HashSet<DamageType> DamageTypes { get; set;} = new HashSet<DamageType>
          {
               DamageType.AK,
               DamageType.Com15,
               DamageType.Com18,
               DamageType.Com45,
               DamageType.Crossvec,
               DamageType.E11Sr,
               DamageType.Firearm,
               DamageType.Fsp9,
               DamageType.Logicer,
               DamageType.Revolver,
               DamageType.Shotgun,
               DamageType.Falldown,
               DamageType.Scp939
          };
          [Description("Which roles should always cause bleeding")]
          public HashSet<RoleTypeId> RoleTypes { get; set; } = new HashSet<RoleTypeId>
          {
               RoleTypeId.Scp939
          };
          [Description("What items should get rid of bleeding")]
          public HashSet<ItemType> CureItems { get; set; } = new HashSet<ItemType>
          {
               ItemType.SCP500,
               ItemType.Medkit,
               ItemType.Painkillers
          };
          [Description("The message to show when bleeding, if empty it wont do broadcast")]
          public string BroadcastMessage { get; set; } = "You're bleeding! Use a medical item to get rid of the bleeding!";
          [Description("The time the message should be shown")]
          public ushort BroadcastTime { get; set; } = 5;
          [Description("If it should use hints instead, false = use Broadcast, true = use Hints")]
          public bool UseHintsInstead { get; set; } = false;
     }
}