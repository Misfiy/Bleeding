using Exiled.API.Interfaces;
using Exiled.API.Enums;
using PlayerRoles;

namespace BleedingPlugin
{
     public sealed class Config : IConfig
     {
          public bool IsEnabled { get; set; } = true;
          public bool Debug { get; set; } = false;
          public bool CanScpsBleed { get; set; } = false;
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
          public HashSet<RoleTypeId> RoleTypes { get; set; } = new HashSet<RoleTypeId>
          {
               RoleTypeId.Scp939
          };
          public HashSet<ItemType> CureItems { get; set; } = new HashSet<ItemType>
          {
               ItemType.SCP500,
               ItemType.Medkit,
               ItemType.Painkillers
          };
     }
}