using Game.Paths;
using System;
using System.Collections;
using UnityEngine;

namespace Game.Fishs {
	public class FishSpawner: MonoBehaviour {
		[SerializeField] private float _spawnCooldown = 10;
		[SerializeField] private int _maxCanSpawned = 10;
		[SerializeField] private Fish[] _fishPrefab;
		[SerializeField] private PathBuilder _path;
		private int _spawnedCount = 0;

		public event Action FishKilled;

		public void SpawnFish() {
			var prefab = GetRandomPrefab();
			var instance = Instantiate(prefab, transform);
			//instance.transform.SetParent(null);
			instance.SetPath(_path.GetPath());
			instance.GetHealth().RunOut += OnFishDie;
			_spawnedCount += 1;
		}
		private Fish GetRandomPrefab() {
			return _fishPrefab[UnityEngine.Random.Range(0, _fishPrefab.Length)];
		}

		private IEnumerator SpawnLoop() {
			while (true) {
				if (_spawnedCount < _maxCanSpawned) {
					SpawnFish();
					yield return new WaitForSeconds(_spawnCooldown);
				} else {
					yield return new WaitForEndOfFrame();
				}
			}
		}

		private void OnFishDie() {
			_spawnedCount -= 1;
			FishKilled?.Invoke();
		}

		private void OnEnable() {
			StartCoroutine(SpawnLoop());
		}
		private void OnDisable() {
			StopCoroutine(SpawnLoop());
		}
	}
}