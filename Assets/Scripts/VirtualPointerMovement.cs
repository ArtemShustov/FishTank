using Game.Inputs;
using UnityEngine;

namespace Game {
	public class VirtualPointerMovement: MonoBehaviour {
		[SerializeField] private float _delta = 1;
		[SerializeField] private Transform _target;
		private PlayerInput _input;

		private void Awake() {
			_input = new PlayerInput();
			_input.Enable();
		}

		private void Update() {
			var gamepadInput = _input.Tank.Aim.ReadValue<Vector2>();
			if (gamepadInput.sqrMagnitude > 0) {
				var newPosition = _target.position + (Vector3)gamepadInput.normalized * _delta;
				transform.position = newPosition;
			} else {
				var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				mousePosition.z = 0;
				var newPosition = _target.position + (mousePosition - _target.position).normalized * _delta;
				transform.position = newPosition;
			}
		}
	}
}