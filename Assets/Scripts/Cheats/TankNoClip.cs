using UnityEngine;

namespace Game.Cheats {
	public class TankNoClip: MonoBehaviour {
#if DEBUG || UNITY_EDITOR || IWANTCHEATS
		[SerializeField] private float _speed = 2f;
		[SerializeField] private Rigidbody2D _rigidbody;

		private Game.Inputs.PlayerInput _inputs;
		private bool _active = false;

		private void Awake() {
			_inputs = new Inputs.PlayerInput();
			_inputs.Cheats.NoClipToggle.performed += ToggleCheat;
		}
		private void Update() {
			if (_active) {
				var delta = Vector2.ClampMagnitude(_inputs.Cheats.NoClipMovement.ReadValue<Vector2>(), 1) * _speed;
				_rigidbody.transform.position += (Vector3)delta * Time.deltaTime;
			}
		}

		private void ToggleCheat(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
			_active = !_active;

			Debug.Log($"NoClip toggled: {_active}");

			_rigidbody.velocity = Vector3.zero;
			_rigidbody.isKinematic = _active;
			_rigidbody.simulated = !_active;
		}

		private void OnEnable() {
			_inputs.Enable();
		}
		private void OnDisable() {
			_inputs.Disable();
		}
#endif
	}
}