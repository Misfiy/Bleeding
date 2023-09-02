namespace BleedingPlugin
{
     using Exiled.API.Features;
     using Exiled.API.Enums;
     using BleedingPlugin.Events;
     using Player = Exiled.Events.Handlers.Player;

     public class Bleeding : Plugin<Config>
     {
          public override string Name => "BleedingPlugin";
          public override string Prefix => "Bleeding";
          public override string Author => "@misfiy";
          public override PluginPriority Priority => PluginPriority.Default;
          private PlayerHandler playerHandler;
          public static Bleeding Instance;
          private Config config;
          public override void OnEnabled()
          {
               Instance = this;
               config = Instance.Config;

               RegisterEvents();
               base.OnEnabled();
          }

          public override void OnDisabled()
          {
               UnregisterEvents();
               Instance = null!;
               base.OnDisabled();
          }
          public void RegisterEvents()
          {
               playerHandler = new PlayerHandler();
               Player.Hurting += playerHandler.OnHurting;
               Player.UsedItem += playerHandler.OnUsedItem;

               Log.Debug("Events have been registered!");
          }
          public void UnregisterEvents()
          {
               Player.Hurting -= playerHandler.OnHurting;
               Player.UsedItem -= playerHandler.OnUsedItem;

               playerHandler = null!;
          }
     }
}