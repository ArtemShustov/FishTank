using UnityEngine;

namespace Game {
	public class BoundForce: MonoBehaviour {
		[SerializeField] private float _force = 10;

		private void OnCollisionStay2D(Collision2D collision) {
			if (collision.rigidbody != null) {
				collision.rigidbody.AddForce(-collision.contacts[0].normal * _force * collision.rigidbody.mass);;
			}
		}
	}
}