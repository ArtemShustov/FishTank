using UnityEngine;
using UnityEngine.UI;

namespace Game.Health.UI {
	public class HealthView: MonoBehaviour {
		[SerializeField] private HealthProperty _health;
		[SerializeField] private Image _bar;

		private void Start() {
			UpdateView(_health.Value, _health.Value);
		}

		private void UpdateView(int oldValue, int newValue) {
			_bar.fillAmount = (float)newValue / _health.MaxValue;
		} 

		private void OnEnable() {
			_health.ValueChanged += UpdateView;
			UpdateView(_health.Value, _health.Value);
		}
		private void OnDisable() {
			_health.ValueChanged -= UpdateView;
		}
	}
}