using System.Linq;
using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace AetharNet.Mods.ZumbiBlocks2.SawedOffSecondary.Patches;

[HarmonyPatch(typeof(ItemsBase))]
public static class ItemsBasePatch
{
    private const BindingFlags PublicInstanceInherited = BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy;

    [HarmonyPrefix]
    [HarmonyPatch(nameof(ItemsBase.Init))]
    public static void PrimaryToSecondary(ItemsBase __instance)
    {
        var primaryGuns = __instance.GetComponentsInChildren<DatabasePrimaryGun>();
        var shotgunPrimary = primaryGuns.First(gun => gun.itemID == InventoryItem.ID.CoachShotgun);
        var shotgunSecondary = shotgunPrimary.gameObject.AddComponent<DatabaseSecondaryGun>();

        foreach (var field in typeof(DatabaseGun).GetFields(PublicInstanceInherited))
        {
            field.SetValue(shotgunSecondary, field.GetValue(shotgunPrimary));
        }

        Object.DestroyImmediate(shotgunPrimary);
    }
}
