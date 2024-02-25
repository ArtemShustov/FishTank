using Game.FX;
using Game.Health;
using UnityEngine;

namespace Game.TankSystem {
	public class Bullet: MonoBehaviour {
		[SerializeField] private float _explosionRadius = 1;
		[SerializeField] private float _explosionForce = 10;
		[SerializeField] private int _baseDamage = 10;
		[SerializeField] private Rigidbody2D _rigidbody;
		[SerializeField] private LifeTimer _trailParticles;
		[SerializeField] private Explosion _explosionPrefab;

		public void AddImpulseForce(float force) {
			_rigidbody.AddForce(transform.right * force, ForceMode2D.Impulse);
		}
		private void Explode(Collision2D hited) { // virtual
			var contacts = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);
			foreach (var contact in contacts) {
				var targetVector = contact.transform.position - transform.position;
				var factor = Mathf.Clamp01((_explosionForce - targetVector.magnitude) / _explosionForce);
				if (factor > 0 && contact.attachedRigidbody != null) {
					contact.attachedRigidbody.AddForce(targetVector * factor * _explosionForce, ForceMode2D.Impulse);
				}
				
				if (contact.TryGetComponent<IDamagable>(out var damagable)) {
					damagable.GiveDamage(Mathf.RoundToInt(_baseDamage * factor));
				}
			}

			var instance = Instantiate(_explosionPrefab, transform);
			instance.transform.SetParent(null);
			instance.Play();

			_trailParticles.transform.SetParent(null);
			_trailParticles.StartTimer();
			Destroy(gameObject);
		}

		private void OnCollisionEnter2D(Collision2D collision) {
			Explode(collision);
		}
	}
}