using UnityEngine;

namespace FarmingGame.Farming
{
	[CreateAssetMenu(menuName = "Farming/Crop Definition", fileName = "CropDefinition")]
	public class CropDefinition : ScriptableObject
	{
		public string cropId;
		public Sprite[] growthStageSprites;
		public int[] daysPerStage;
		public int harvestYield = 1;
	}
}

