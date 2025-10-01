using System.Collections.Generic;
using UnityEngine;
using FarmingGame.Farming;

namespace FarmingGame.Inventory
{
	public enum ItemType { Seed, Crop }

	[System.Serializable]
	public class InventoryItem
	{
		public ItemType itemType;
		public string itemId;
		public int quantity;
	}

	public class InventorySystem : MonoBehaviour
	{
		[SerializeField] private List<InventoryItem> items = new List<InventoryItem>();
		[SerializeField] private CropDefinition defaultSeed;

		private void Awake()
		{
			if (defaultSeed != null)
			{
				AddItem(ItemType.Seed, defaultSeed.cropId, 5);
			}
		}

		public void AddItem(ItemType type, string id, int amount)
		{
			var existing = items.Find(i => i.itemType == type && i.itemId == id);
			if (existing == null)
			{
				items.Add(new InventoryItem { itemType = type, itemId = id, quantity = amount });
			}
			else
			{
				existing.quantity += amount;
			}
		}

		public bool ConsumeSeed(CropDefinition crop)
		{
			var seed = items.Find(i => i.itemType == ItemType.Seed && i.itemId == crop.cropId);
			if (seed == null || seed.quantity <= 0) return false;
			seed.quantity--;
			return true;
		}
	}
}

