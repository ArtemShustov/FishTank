using Game.FX;
using Game.Health;
using UnityEngine;

namespace Game {
	public class Mine: MonoBehaviour {
		[SerializeField] private int _damage;
		[SerializeField] private Animator _animator;
		[SerializeField] private string _animationProperty = "IsOpened";
		[SerializeField] private Explosion _fxPrefab;

		private void Start() {
			_animator.SetBool(_animationProperty, true);
		}
		private void OnCollisionEnter2D(Collision2D collision) {
			if (collision.gameObject.TryGetComponent<IDamagable>(out var damagable)) {
				damagable.GiveDamage(_damage);
			}
			var fx = Instantiate(_fxPrefab, transform);
			fx.transform.SetParent(null);
			fx.Play();
			Destroy(gameObject);
		}
	}
}