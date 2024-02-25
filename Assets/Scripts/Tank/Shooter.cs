using UnityEngine;

namespace Game.TankSystem {
	public class Shooter: MonoBehaviour {
		[SerializeField] private float _bulletForce = 6;
		[SerializeField] private Transform _root;
		[SerializeField] private ParticleSystem _particle;
		[SerializeField] private Bullet _bulletPrefab;
		[SerializeField] private ForceAtPosition _kickback;
		[SerializeField] private AudioSource _audioSource;

		public void Shoot() {
			_particle.Play();
			_audioSource.Play();
			var bullet = Instantiate(_bulletPrefab, _root);
			bullet.transform.right = _root.right;
			bullet.transform.SetParent(null);
			bullet.gameObject.layer = gameObject.layer;
			bullet.AddImpulseForce(_bulletForce);
			_kickback.Impulse(1);
		}
	}
}