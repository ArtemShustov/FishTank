using Game.Inputs;
using UnityEngine;

namespace Game.TankSystem {
	public class Tank: MonoBehaviour {
		[SerializeField] private Transform _aimTarget;
		[SerializeField] private Shooter _shooter;
		[SerializeField] private Engine _leftEngine;
		[SerializeField] private Engine _rightEngine;
		[SerializeField] private GunMovement _gunMovement;

		private PlayerInput _playerInput;

		private void Awake() {
			_playerInput = new PlayerInput();
			_playerInput.Tank.Shoot.performed += Shoot;
			_playerInput.Tank.LeftEngine.started += ToggleLeftOn;
			_playerInput.Tank.LeftEngine.canceled += ToggleLeftOff;
			_playerInput.Tank.RightEngine.started += ToggleRightOn;
			_playerInput.Tank.RightEngine.canceled += ToggleRightOff;
		}

		private void Update() {
			_gunMovement.SetTarget(_aimTarget.position);
		}

		private void ToggleLeftOn(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
			_leftEngine.ToggleOn();
		}
		private void ToggleLeftOff(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
			_leftEngine.ToggleOff();
		}
		private void ToggleRightOn(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
			_rightEngine.ToggleOn();
		}
		private void ToggleRightOff(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
			_rightEngine.ToggleOff();
		}
		private void Shoot(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
			_shooter.Shoot();
		}

		public void ToggleInput(bool active) {
			if (active) {
				_playerInput.Enable();
			} else {
				_playerInput.Disable();
			}
		}

		private void OnEnable() {
			_playerInput.Enable();
		}
		private void OnDisable() {
			_playerInput.Disable();
		}
	}
}