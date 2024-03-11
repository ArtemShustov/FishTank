using UnityEngine;

namespace Game.Utils {
	public class DestroyAfterTime: MonoBehaviour {
		[Min(0)]
		[SerializeField] private float _time = 1;

		private bool _running = false;

		public void StartTimer() {
			if (_running) {
				return;
			}
			_running = true;
			Invoke(nameof(TimerEnd), _time);
		}
		private void TimerEnd() {
			_running = false;
			OnTimerEnded();
		}
		public virtual void OnTimerEnded() {
			Destroy(gameObject);
		}
	}
}