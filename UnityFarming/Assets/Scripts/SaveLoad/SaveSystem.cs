using System.IO;
using UnityEngine;

namespace FarmingGame.SaveLoad
{
	public class SaveSystem : MonoBehaviour
	{
		[SerializeField] private string fileName = "save.json";

		[System.Serializable]
		private class SaveData
		{
			public int dayNumber;
		}

		public void Save()
		{
			var data = new SaveData { dayNumber = 1 };
			var json = JsonUtility.ToJson(data, true);
			var path = Path.Combine(Application.persistentDataPath, fileName);
			File.WriteAllText(path, json);
			Debug.Log($"Saved to {path}");
		}

		public void Load()
		{
			var path = Path.Combine(Application.persistentDataPath, fileName);
			if (!File.Exists(path)) { Debug.Log("No save file"); return; }
			var json = File.ReadAllText(path);
			var data = JsonUtility.FromJson<SaveData>(json);
			Debug.Log($"Loaded day {data.dayNumber}");
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.K)) Save();
			if (Input.GetKeyDown(KeyCode.L)) Load();
		}
	}
}

