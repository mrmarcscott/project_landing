using UnityEngine;

namespace FarmingGame.Player
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private float moveSpeed = 4f;
		[SerializeField] private ToolController toolController;

		private Rigidbody2D body;
		private Vector2 input;
		private Vector2 lastFacing = Vector2.down;

		private void Awake()
		{
			body = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			ReadMovementInput();
			ReadToolInput();
		}

		private void FixedUpdate()
		{
			Move();
		}

		private void ReadMovementInput()
		{
			input.x = Input.GetAxisRaw("Horizontal");
			input.y = Input.GetAxisRaw("Vertical");
			input = input.normalized;

			if (input.sqrMagnitude > 0.001f)
			{
				lastFacing = input;
			}
		}

		private void Move()
		{
			var velocity = input * moveSpeed;
			body.velocity = velocity;
		}

		private void ReadToolInput()
		{
			if (toolController == null) return;

			if (Input.GetKeyDown(KeyCode.Alpha1)) toolController.SelectTool(ToolType.Hoe);
			if (Input.GetKeyDown(KeyCode.Alpha2)) toolController.SelectTool(ToolType.WateringCan);
			if (Input.GetKeyDown(KeyCode.Alpha3)) toolController.SelectTool(ToolType.Scythe);

			if (Input.GetKeyDown(KeyCode.Space))
			{
				toolController.UseTool(transform.position, lastFacing);
			}
		}
	}
}

