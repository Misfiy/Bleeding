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
            string attacker = ev.Attacker != null ? ev.Attacker.Role.Type.ToString() : "No attacker";
            Log.Debug($"{ev.Player.Nickname} was hurt: {ev.DamageHandler.Type.ToString()}. Attacker: {attacker}");
            if (!config.CanScpsBleed && ev.Player.IsScp) return;
            if (config.DamageTypes.Contains(ev.DamageHandler.Type) || ev.Attacker != null && config.RoleTypes.Contains(ev.Attacker.Role.Type)) DoBleed(ev.Player);
        }
        public void OnUsedItem(UsedItemEventArgs ev)
        {
            if (config.CureItems.Contains(ev.Item.Type))
            {
                ev.Player.DisableEffect(EffectType.Bleeding);
            }
        }
        private void DoBleed(Player player)
        {
          player.EnableEffect(EffectType.Bleeding);
          if(config.BroadcastMessage.Length == 0) return;
          if(config.UseHintsInstead) player.ShowHint(config.BroadcastMessage, config.BroadcastTime);
          else player.Broadcast(config.BroadcastTime, config.BroadcastMessage);
        }
    }
}