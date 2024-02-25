using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Fishs {
	public class FishSpawner: MonoBehaviour {
		[SerializeField] private float _spawnCooldown = 10;
		[SerializeField] private int _maxSpawned = 10;
		[SerializeField] private Fish[] _fishPrefab;
		[SerializeField] private PathBuilder _path;
		private int _spawnedCount = 0;

		public event Action FishKilled;

		private void Start() {
			SpawnFish();
		}

		public void SpawnFish() {
			var prefab = GetRandomPrefab();
			var instance = Instantiate(prefab, transform);
			//instance.transform.SetParent(null);
			instance.SetPath(_path.GetPath());
			instance.GetHealth().RunOut += OnFishDie;
			_spawnedCount += 1;
			Invoke(nameof(SpawnFish), _spawnCooldown);
		}

		private void OnFishDie() {
			_spawnedCount -= 1;
			FishKilled?.Invoke();
		}

		private Fish GetRandomPrefab() {
			return _fishPrefab[UnityEngine.Random.Range(0, _fishPrefab.Length)];
		}
	}
}