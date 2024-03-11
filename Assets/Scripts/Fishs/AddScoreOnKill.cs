using Game.Stats;
using UnityEngine;

namespace Game.Fishs {
	public class AddScoreOnKill: MonoBehaviour {
		[SerializeField] private ScoreCounter _counter;
		[SerializeField] private FishSpawner[] _spawners;

		private void OnFishKilled() {
			_counter.AddPoint();
		}

		private void OnEnable() {
			foreach (var spawner in _spawners) {
				spawner.FishKilled += OnFishKilled;
			}
		}
		private void OnDisable() {
			foreach (var spawner in _spawners) {
				spawner.FishKilled -= OnFishKilled;
			}
		}
	}
}