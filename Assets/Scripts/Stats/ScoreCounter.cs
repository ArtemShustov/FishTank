using Game.Events;
using UnityEngine;

namespace Game.Stats {
	public class ScoreCounter: MonoBehaviour {
		private int _value = 0;

		public int Value => _value;
		public event ValueChange<int> ValueChanged;

		public void AddPoint() {
			var oldValue = _value;
			_value += 1;
			ValueChanged?.Invoke(oldValue, _value);
		}
	}
}