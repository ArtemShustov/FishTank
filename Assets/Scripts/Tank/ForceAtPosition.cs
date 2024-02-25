using UnityEngine;

namespace Game.TankSystem {
	public class ForceAtPosition: MonoBehaviour {
		[SerializeField] private float _force = 100;
		[SerializeField] private Rigidbody2D _rigidbody;

		public void Force(float magnitude = 1) {
			magnitude = Mathf.Clamp01(magnitude);
			_rigidbody.AddForceAtPosition(transform.right * magnitude * _force * Time.deltaTime, transform.position, ForceMode2D.Force);
		}
		public void Impulse(float magnitude = 1) {
			magnitude = Mathf.Clamp01(magnitude);
			_rigidbody.AddForceAtPosition(transform.right * magnitude * _force, transform.position, ForceMode2D.Impulse);
		}
		private void OnDrawGizmos() {
			Gizmos.color = Color.black;
			Gizmos.DrawLine(transform.position, transform.position + transform.right);
		}
	}
}