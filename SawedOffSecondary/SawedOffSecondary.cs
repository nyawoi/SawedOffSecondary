using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.SawedOffSecondary;

[BepInPlugin(PluginGUID, PluginName, PluginVersion)]
public class SawedOffSecondary : BaseUnityPlugin
{
    public const string PluginGUID = "AetharNet.Mods.ZumbiBlocks2.SawedOffSecondary";
    public const string PluginAuthor = "wowi";
    public const string PluginName = "SawedOffSecondary";
    public const string PluginVersion = "0.1.0";

    internal new static ManualLogSource Logger;

    private void Awake()
    {
        Logger = base.Logger;
        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), PluginGUID);
    }
}
