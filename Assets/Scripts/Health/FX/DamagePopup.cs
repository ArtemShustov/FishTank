using TMPro;
using UnityEngine;

namespace Game.Health.FX {
	public class DamagePopup: MonoBehaviour {
		[SerializeField] private AnimationCurve _verticalPosition;
		[SerializeField] private float _duration = 1;
		[SerializeField] private TMP_Text _label;

		private float _timer = 0;
		private Vector3 _basePosition;

		private void Update() {
			_timer += Time.deltaTime;

			transform.position = _basePosition + Vector3.up * _verticalPosition.Evaluate(_timer / _duration);
			
			if (_timer > _duration) {
				gameObject.SetActive(false);
				Destroy(gameObject);
			}
		}

		public void Set(int value) {
			_label.text = value.ToString();
		}

		private void OnEnable() {
			_timer = 0;
			_basePosition = transform.position;
		}
	}
}