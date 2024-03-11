using UnityEngine;

namespace Game.Paths {
	public class MoveByPath: MonoBehaviour {
		[SerializeField] private float _speed = 1f;
		[SerializeField] private Vector2[] _points = new Vector2[0];
		[SerializeField] private Rigidbody2D _rigidbody;
		private int _currentPoint = 0;
		private Vector2 TargetPoint => _points[_currentPoint];

		public void SetPath(Vector2[] points) {
			_points = (Vector2[])points.Clone();
			_currentPoint = Mathf.Clamp(_currentPoint, 0, _points.Length - 1);
		}
		private void Update() {
			if (_points.Length <= 0) {
				return;
			}

			var direction = TargetPoint - (Vector2)transform.position;
			var delta = Vector2.ClampMagnitude(direction.normalized * _speed * Time.deltaTime, direction.magnitude);

			transform.right = direction * -1;
			//_rigidbody.velocity += delta;
			_rigidbody.velocity = Vector2.MoveTowards(_rigidbody.velocity, direction.normalized * _speed, _speed * Time.deltaTime);

			if (Vector2.Distance((Vector2)transform.position, TargetPoint) < 0.4f) {
				_currentPoint += 1;
				if (_currentPoint >= _points.Length) {
					_currentPoint = 0;
				}
			}
		}
		private void OnDrawGizmos() {
			if (Application.isPlaying == false) {
				return;
			}

			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(TargetPoint, 0.4f);
			Gizmos.DrawLine(transform.position, TargetPoint);
			
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(transform.position, transform.position + (Vector3)_rigidbody.velocity.normalized);
		}
	}
}