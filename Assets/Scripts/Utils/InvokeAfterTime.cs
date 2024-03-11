using UnityEngine;
using UnityEngine.Events;

namespace Game.Utils {
	public class InvokeAfterTime: MonoBehaviour {
		[Min(1)]
		[SerializeField] private float _time = 1;
		[SerializeField] private UnityEvent _timerEnded;

		private void OnTimerEnd() {
			_timerEnded.Invoke();
		}

		private void OnEnable() {
			Invoke(nameof(OnTimerEnd), _time);
		}
		private void OnDisable() {
			CancelInvoke(nameof(OnTimerEnd));
		}
	}
}