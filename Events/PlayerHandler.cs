namespace BleedingPlugin.Events
{
     using Exiled.Events.EventArgs.Player;
     using Exiled.API.Enums;
     using PlayerRoles;
     using BleedingPlugin;
     using Exiled.API.Features;
     public sealed class PlayerHandler
     {
          Config config = Bleeding.Instance.Config;
          public void OnHurting(HurtingEventArgs ev)
          {
               if(!config.CanScpsBleed && ev.Attacker != null && ev.Attacker.IsScp) return;
               if(config.DamageTypes.Contains(ev.DamageHandler.Type))
               if(ev.Attacker != null && config.RoleTypes.Contains(ev.Attacker.Role.Type)) { ev.Player.EnableEffect(EffectType.Bleeding); }
          }
          public void OnUsedItem(UsedItemEventArgs ev)
          {
               if(config.CureItems.Contains(ev.Item.Type)) ev.Player.DisableEffect(EffectType.Bleeding);
          }
     }
}