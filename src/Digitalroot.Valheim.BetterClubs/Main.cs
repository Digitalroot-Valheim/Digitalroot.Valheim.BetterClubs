using BepInEx;
using JetBrains.Annotations;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using UnityEngine;

namespace Digitalroot.Valheim.BetterClubs
{
  [BepInPlugin(Guid, Name, Version)]
  public class Main : BaseUnityPlugin
  {
    public const string Version = "1.0.3";
    public const string Name = "Digitalroot Better Clubs";
    public const string Guid = "digitalroot.mods.betterclubs";
    public const string Namespace = "Digitalroot.Valheim.BetterClubs";

    [UsedImplicitly]
    public void Awake()
    {
      AddLocalizations();
      PrefabManager.OnVanillaPrefabsAvailable += AddClonedItems;
    }

    private void AddClonedItems()
    {
      ClubBronzeNail();
      ClubIronNail();
      ClubFire();
      ClubStone();
      ClubBee();
      ClubPoison();

      // You want that to run only once, Jotunn has the item cached for the game session
      PrefabManager.OnVanillaPrefabsAvailable -= AddClonedItems;
    }

    private void AddLocalizations()
    {
      LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
      {
        Translations =
        {
          {"item_club_bronze_nail", "Spiked Club"}, {"item_club_bronze_nail_description", "A club with a nail in it."},
          {"item_club_iron_nail", "Spikier Club"}, {"item_club_iron_nail_description", "A club with a sharp nail in it."},
          {"item_club_fire", "Fire Starter"}, {"item_club_fire_description", "A large matchstick."},
          {"item_club_stone", "Heavy Club"}, {"item_club_stone_description", "A club with weight behind it."},
          {"item_club_bee", "Stinging Club"}, {"item_club_bee_description", "A club that stings."},
          {"item_club_poison", "Sickly Sticky"}, {"item_club_poison_description", "A club that's diseased."},
        }
      });
    }

    #region ClubBronzeNail

    private void ClubBronzeNail()
    {
      CustomItem customItem = new("ClubBronzeNail", "Club");
      ItemManager.Instance.AddItem(customItem);

      var itemDrop = customItem.ItemDrop;
      itemDrop.m_itemData.m_shared.m_name = "$item_club_bronze_nail";
      itemDrop.m_itemData.m_shared.m_description = "$item_club_bronze_nail_description";
      itemDrop.m_itemData.m_shared.m_damages.m_pierce = 5f;
      itemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = 2f;
      itemDrop.m_itemData.m_shared.m_maxQuality = 5;

      // Create and add a recipe for the copied item
      RecipeClubBronzeNail(itemDrop);
    }

    private static void RecipeClubBronzeNail(ItemDrop itemDrop)
    {
      // Create and add a recipe for the copied item
      Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
      recipe.name = "Recipe_ClubBronzeNail";
      recipe.m_item = itemDrop;
      recipe.m_craftingStation = PrefabManager.Cache.GetPrefab<CraftingStation>("piece_workbench");
      recipe.m_resources = new[]
      {
        new Piece.Requirement
        {
          m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Club"),
          m_amount = 1,
          m_amountPerLevel = 0
        },
        new Piece.Requirement
        {
          m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("BronzeNails"),
          m_amount = 1,
          m_amountPerLevel = 1
        }
      };

      // Since we got the prefabs from the cache, no referencing is needed
      CustomRecipe customRecipe = new(recipe, fixReference: false, fixRequirementReferences: false);
      ItemManager.Instance.AddRecipe(customRecipe);
    }

    #endregion

    #region ClubIronNail

    private void ClubIronNail()
    {
      CustomItem customItem = new("ClubIronNail", "Club");
      ItemManager.Instance.AddItem(customItem);

      var itemDrop = customItem.ItemDrop;
      itemDrop.m_itemData.m_shared.m_name = "$item_club_iron_nail";
      itemDrop.m_itemData.m_shared.m_description = "$item_club_iron_nail_description";
      itemDrop.m_itemData.m_shared.m_damages.m_pierce = 6f;
      itemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = 3f;
      itemDrop.m_itemData.m_shared.m_maxQuality = 5;

      // Create and add a recipe for the copied item
      RecipeClubIronNail(itemDrop);
    }

    private static void RecipeClubIronNail(ItemDrop itemDrop)
    {
      // Create and add a recipe for the copied item
      Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
      recipe.name = "Recipe_ClubIronNail";
      recipe.m_item = itemDrop;
      recipe.m_craftingStation = PrefabManager.Cache.GetPrefab<CraftingStation>("piece_workbench");
      recipe.m_resources = new[]
      {
        new Piece.Requirement
        {
          m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Club"),
          m_amount = 1,
          m_amountPerLevel = 0
        },
        new Piece.Requirement
        {
          m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("IronNails"),
          m_amount = 1,
          m_amountPerLevel = 1
        }
      };

      // Since we got the prefabs from the cache, no referencing is needed
      CustomRecipe customRecipe = new(recipe, fixReference: false, fixRequirementReferences: false);
      ItemManager.Instance.AddRecipe(customRecipe);
    }

    #endregion

    #region ClubFire

    private void ClubFire()
    {
      CustomItem customItem = new("ClubFire", "Club");
      ItemManager.Instance.AddItem(customItem);

      var itemDrop = customItem.ItemDrop;
      itemDrop.m_itemData.m_shared.m_name = "$item_club_fire";
      itemDrop.m_itemData.m_shared.m_description = "$item_club_fire_description";
      itemDrop.m_itemData.m_shared.m_damages.m_fire = 5f;
      itemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = 4f;
      itemDrop.m_itemData.m_shared.m_maxQuality = 5;

      // Create and add a recipe for the copied item
      RecipeClubFire(itemDrop);
    }

    private static void RecipeClubFire(ItemDrop itemDrop)
    {
      // Create and add a recipe for the copied item
      Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
      recipe.name = "Recipe_ClubFire";
      recipe.m_item = itemDrop;
      recipe.m_craftingStation = PrefabManager.Cache.GetPrefab<CraftingStation>("piece_workbench");
      recipe.m_resources = new[]
      {
        new Piece.Requirement
        {
          m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Club"),
          m_amount = 1,
          m_amountPerLevel = 0
        },
        new Piece.Requirement
        {
          m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Resin"),
          m_amount = 2,
          m_amountPerLevel = 2
        },
        new Piece.Requirement
        {
          m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Flint"),
          m_amount = 1,
          m_amountPerLevel = 1
        }
      };

      // Since we got the prefabs from the cache, no referencing is needed
      CustomRecipe customRecipe = new(recipe, fixReference: false, fixRequirementReferences: false);
      ItemManager.Instance.AddRecipe(customRecipe);
    }

    #endregion

    #region ClubStone

    private void ClubStone()
    {
      CustomItem customItem = new("ClubStone", "Club");
      ItemManager.Instance.AddItem(customItem);

      var itemDrop = customItem.ItemDrop;
      itemDrop.m_itemData.m_shared.m_name = "$item_club_stone";
      itemDrop.m_itemData.m_shared.m_description = "$item_club_stone_description";
      itemDrop.m_itemData.m_shared.m_damages.m_blunt = 15f;
      itemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = 8f;
      itemDrop.m_itemData.m_shared.m_maxQuality = 5;
      itemDrop.m_itemData.m_shared.m_movementModifier = -0.06f;
      itemDrop.m_itemData.m_shared.m_weight = 5f;

      // Create and add a recipe for the copied item
      RecipeClubStone(itemDrop);
    }

    private static void RecipeClubStone(ItemDrop itemDrop)
    {
      // Create and add a recipe for the copied item
      Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
      recipe.name = "Recipe_ClubStone";
      recipe.m_item = itemDrop;
      recipe.m_craftingStation = PrefabManager.Cache.GetPrefab<CraftingStation>("piece_workbench");
      recipe.m_resources = new[]
      {
        new Piece.Requirement
        {
          m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Club"),
          m_amount = 1,
          m_amountPerLevel = 0
        },
        new Piece.Requirement
        {
          m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Stone"),
          m_amount = 4,
          m_amountPerLevel = 4
        },
      };

      // Since we got the prefabs from the cache, no referencing is needed
      CustomRecipe customRecipe = new(recipe, fixReference: false, fixRequirementReferences: false);
      ItemManager.Instance.AddRecipe(customRecipe);
    }

    #endregion

    #region ClubBee

    private void ClubBee()
    {
      CustomItem customItem = new("ClubBee", "Club");
      ItemManager.Instance.AddItem(customItem);

      var itemDrop = customItem.ItemDrop;
      itemDrop.m_itemData.m_shared.m_name = "$item_club_bee";
      itemDrop.m_itemData.m_shared.m_description = "$item_club_bee_description";
      itemDrop.m_itemData.m_shared.m_damages.m_poison = 5f;
      itemDrop.m_itemData.m_shared.m_damages.m_pierce = 1f;
      itemDrop.m_itemData.m_shared.m_maxQuality = 1;

      // Create and add a recipe for the copied item
      RecipeClubBee(itemDrop);
    }

    private static void RecipeClubBee(ItemDrop itemDrop)
    {
      // Create and add a recipe for the copied item
      Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
      recipe.name = "Recipe_ClubBee";
      recipe.m_item = itemDrop;
      recipe.m_craftingStation = PrefabManager.Cache.GetPrefab<CraftingStation>("piece_workbench");
      recipe.m_resources = new[]
      {
        new Piece.Requirement
        {
          m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Club"),
          m_amount = 1,
          m_amountPerLevel = 0
        },
        new Piece.Requirement
        {
          m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("QueenBee"),
          m_amount = 1,
          m_amountPerLevel = 200
        }
      };

      // Since we got the prefabs from the cache, no referencing is needed
      CustomRecipe customRecipe = new(recipe, fixReference: false, fixRequirementReferences: false);
      ItemManager.Instance.AddRecipe(customRecipe);
    }

    #endregion

    #region ClubPoison

    private void ClubPoison()
    {
      CustomItem customItem = new("ClubPoison", "Club");
      ItemManager.Instance.AddItem(customItem);

      var itemDrop = customItem.ItemDrop;
      itemDrop.m_itemData.m_shared.m_name = "$item_club_poison";
      itemDrop.m_itemData.m_shared.m_description = "$item_club_poison_description";
      itemDrop.m_itemData.m_shared.m_damages.m_poison = 8f;
      itemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = 4f;
      itemDrop.m_itemData.m_shared.m_maxQuality = 5;

      // Create and add a recipe for the copied item
      RecipeClubPoison(itemDrop);
    }

    private static void RecipeClubPoison(ItemDrop itemDrop)
    {
      // Create and add a recipe for the copied item
      Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
      recipe.name = "Recipe_ClubPoison";
      recipe.m_item = itemDrop;
      recipe.m_craftingStation = PrefabManager.Cache.GetPrefab<CraftingStation>("piece_workbench");
      recipe.m_resources = new[]
      {
        new Piece.Requirement
        {
          m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Club"),
          m_amount = 1,
          m_amountPerLevel = 0
        },
        new Piece.Requirement
        {
          m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Guck"),
          m_amount = 1,
          m_amountPerLevel = 3
        }
      };

      // Since we got the prefabs from the cache, no referencing is needed
      CustomRecipe customRecipe = new(recipe, fixReference: false, fixRequirementReferences: false);
      ItemManager.Instance.AddRecipe(customRecipe);
    }

    #endregion
  }
}
