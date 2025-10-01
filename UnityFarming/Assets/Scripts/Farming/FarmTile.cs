using UnityEngine;
using FarmingGame.Core;

namespace FarmingGame.Farming
{
	[RequireComponent(typeof(Collider2D))]
	public class FarmTile : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private Sprite untiledSprite;
		[SerializeField] private Sprite tilledSprite;
		[SerializeField] private CropDefinition plantedCrop;
		[SerializeField] private int currentStage = -1; // -1 none, 0+ growth stage
		[SerializeField] private bool isTilled = false;
		[SerializeField] private bool isWateredToday = false;

		private void Awake()
		{
			if (spriteRenderer == null) spriteRenderer = GetComponentInChildren<SpriteRenderer>();
			gameObject.layer = LayerMask.NameToLayer("Interactable");
		}

		private void OnEnable()
		{
			GameTime.OnNewDay += HandleNewDay;
		}

		private void OnDisable()
		{
			GameTime.OnNewDay -= HandleNewDay;
		}

		public void Till()
		{
			if (isTilled) return;
			isTilled = true;
			UpdateVisual();
		}

		public void Water()
		{
			if (!isTilled) return;
			isWateredToday = true;
		}

		public bool Plant(CropDefinition crop)
		{
			if (!isTilled || plantedCrop != null) return false;
			plantedCrop = crop;
			currentStage = 0;
			UpdateVisual();
			return true;
		}

		public void TryHarvest()
		{
			if (plantedCrop == null) return;
			bool isMature = currentStage >= plantedCrop.growthStageSprites.Length - 1;
			if (!isMature) return;
			// TODO: add to inventory via event. For now, reset tile.
			plantedCrop = null;
			currentStage = -1;
			isTilled = false;
			isWateredToday = false;
			UpdateVisual();
		}

		private void HandleNewDay(int dayNumber)
		{
			if (plantedCrop == null) { isWateredToday = false; return; }
			if (!isWateredToday) { isWateredToday = false; return; }
			isWateredToday = false;

			if (currentStage < plantedCrop.daysPerStage.Length)
			{
				// Advance if we've completed required days for this stage (simple: 1 day per watered day)
				currentStage = Mathf.Min(currentStage + 1, plantedCrop.growthStageSprites.Length - 1);
				UpdateVisual();
			}
		}

		private void UpdateVisual()
		{
			if (plantedCrop != null && currentStage >= 0)
			{
				spriteRenderer.sprite = plantedCrop.growthStageSprites[Mathf.Clamp(currentStage, 0, plantedCrop.growthStageSprites.Length - 1)];
				return;
			}
			spriteRenderer.sprite = isTilled ? tilledSprite : untiledSprite;
		}
	}
}

