using System;
using UnityEngine;

namespace FarmingGame.Core
{
	public class GameTime : MonoBehaviour
	{
		[SerializeField] private float secondsPerGameDay = 120f;
		[SerializeField] private bool autoStart = true;
		private float elapsed;
		private int dayNumber = 1;

		public static event Action<int> OnNewDay;

		private void Start()
		{
			elapsed = 0f;
		}

		private void Update()
		{
			if (!autoStart) return;
			elapsed += Time.deltaTime;
			if (elapsed >= secondsPerGameDay)
			{
				elapsed = 0f;
				dayNumber++;
				OnNewDay?.Invoke(dayNumber);
			}
		}

		public void ForceNewDay()
		{
			dayNumber++;
			OnNewDay?.Invoke(dayNumber);
		}
	}
}

