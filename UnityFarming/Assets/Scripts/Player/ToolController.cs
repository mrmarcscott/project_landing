using UnityEngine;
using FarmingGame.Farming;

namespace FarmingGame.Player
{
	public enum ToolType { None, Hoe, WateringCan, Scythe }

	public class ToolController : MonoBehaviour
	{
		[SerializeField] private ToolType currentTool = ToolType.Hoe;
		[SerializeField] private float interactRange = 1.1f;

		public void SelectTool(ToolType tool)
		{
			currentTool = tool;
		}

		public void UseTool(Vector3 origin, Vector2 facing)
		{
			Vector3 target = origin + (Vector3)(facing.normalized * interactRange);
			var hit = Physics2D.OverlapCircle(target, 0.25f, LayerMask.GetMask("Interactable"));
			if (hit == null) return;

			var farmTile = hit.GetComponent<FarmTile>();
			if (farmTile == null) return;

			switch (currentTool)
			{
				case ToolType.Hoe:
					farmTile.Till();
					break;
				case ToolType.WateringCan:
					farmTile.Water();
					break;
				case ToolType.Scythe:
					farmTile.TryHarvest();
					break;
			}
		}
	}
}

