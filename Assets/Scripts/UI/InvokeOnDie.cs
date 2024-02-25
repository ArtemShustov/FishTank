using Game.Health;
using UnityEngine;
using UnityEngine.Events;

namespace Game.UI {
	public class InvokeOnDie: MonoBehaviour {
		[SerializeField] private HealthProperty _health;
		[SerializeField] private UnityEvent _onDie;

		private void OnDie() {
			_onDie.Invoke();
		}

		private void OnEnable() {
			_health.RunOut += OnDie;
		}
		private void OnDisable() {
			_health.RunOut -= OnDie;
		}
	}
}