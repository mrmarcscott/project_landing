using UnityEngine;

namespace FarmingGame.CameraSystem
{
	public class CameraFollow : MonoBehaviour
	{
		[SerializeField] private Transform target;
		[SerializeField] private float smoothTime = 0.15f;
		private Vector3 velocity;

		private void LateUpdate()
		{
			if (target == null) return;
			var desired = new Vector3(target.position.x, target.position.y, transform.position.z);
			transform.position = Vector3.SmoothDamp(transform.position, desired, ref velocity, smoothTime);
		}

		public void SetTarget(Transform t)
		{
			target = t;
		}
	}
}

