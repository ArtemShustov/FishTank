using UnityEngine;

namespace Game.TankSystem {
	public class Engine: MonoBehaviour {
		[SerializeField] private ForceAtPosition _force;
		[SerializeField] private ParticleSystem _particleSystem;
		[SerializeField] private AudioSource _audioSource;

		private bool _active = false;

		private void Update() {
			if (_active) {
				_force.Force(1);
			}
		}

		public void ToggleOn() {
			_active = true;
			_particleSystem.Play();
			_audioSource.Play();
		}
		public void ToggleOff() {
			_active = false;
			_particleSystem.Stop();
			_audioSource.Stop();
		}
	}
}