using UnityEngine;

namespace Game.Health.FX {
	public class DamageFX: MonoBehaviour {
		[SerializeField] private HealthProperty _health;
		[SerializeField] private DamagePopup _popup;

		private void CreatePopup(int damage) {
			var instance = Instantiate(_popup, transform);
			instance.transform.eulerAngles = Vector3.zero;
			instance.transform.SetParent(null);
			instance.Set(-damage);
			instance.gameObject.SetActive(true);
		}

		private void OnEnable() {
			_health.Damaged += CreatePopup;
		}
		private void OnDisable() {
			_health.Damaged -= CreatePopup;
		}
	}
}