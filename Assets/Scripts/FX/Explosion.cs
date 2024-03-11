using UnityEngine;

namespace Game.FX {
	public class Explosion: MonoBehaviour {
		[Min(10)]
		[SerializeField] private float _lifeTime = 10;
		[Tooltip("Min/max pitch area")]
		[SerializeField] private Vector2 _pitch = new Vector2(1, 1);
		[SerializeField] private ParticleSystem _particleSystem;
		[SerializeField] private AudioSource _audioSource;

		private bool _isPlaying = false;

		public void Play() {
			if (_isPlaying) {
				return;
			}
			_isPlaying = true;
			_particleSystem.Play();
			_audioSource.pitch = Random.Range(_pitch.x, _pitch.y);
			_audioSource.Play();
			Invoke(nameof(Stop), _lifeTime);
		}
		private void Stop() {
			_isPlaying = false;
			_particleSystem.Stop();
			_audioSource.Stop();

			OnStop();
		}
		public virtual void OnStop() {
			Destroy(this.gameObject);
		}
	}
}