using Game.FX;
using UnityEngine;

namespace Game.Health.FX {
	public class DieFX: MonoBehaviour {
		[SerializeField] private HealthProperty _health;
		[SerializeField] private Explosion _fxPrefab;

		private void Play() {
			var instance = Instantiate(_fxPrefab, transform);
			instance.transform.SetParent(null);
			instance.Play();
		}

		private void OnEnable() {
			_health.RunOut += Play;
		}
		private void OnDisable() {
			_health.RunOut -= Play;
		}
	}
}