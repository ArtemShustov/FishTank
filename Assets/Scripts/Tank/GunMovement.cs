using UnityEngine;

namespace Game.TankSystem {
	public class GunMovement: MonoBehaviour {
		[Min(0)]
		[SerializeField] private float _rotationSpeed = 1;
		[SerializeField] private float _minAngle = -10;
		[SerializeField] private float _maxAngle = 10;
		[SerializeField] private Transform _gun;

		private float _targetAngle;
		private Vector2 _targetPoint;

		public void SetAngle(float localAngle) { 
			_targetAngle = Mathf.Clamp(localAngle, _minAngle, _maxAngle);
		}
		private void AimToPoint(Vector2 point) {
			var angle = Vector2.SignedAngle(transform.right, point - (Vector2)_gun.position);
			SetAngle(angle);
		}
		public void SetTarget(Vector2 point) {
			_targetPoint = point;
		}

		private void Update() {
			Debug.DrawLine(transform.position, _targetPoint, Color.green);
			Debug.DrawLine(transform.position, transform.position + transform.right, Color.red);
			Debug.DrawLine(_gun.position, _gun.position + _gun.right, Color.yellow);
			AimToPoint(_targetPoint);

			var rotation = _gun.localEulerAngles;
			rotation.z = rotation.z > 180 ? -(360 - rotation.z) : rotation.z;
			rotation.z += Mathf.Clamp(_targetAngle - rotation.z, -_rotationSpeed * Time.deltaTime, _rotationSpeed * Time.deltaTime);
			rotation.z = Mathf.Clamp(rotation.z, _minAngle, _maxAngle);
			_gun.localEulerAngles = rotation;
		}
	}
}