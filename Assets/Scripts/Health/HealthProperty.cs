using Game.Events;
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Health {
	public class HealthProperty: MonoBehaviour, IHealth, IDamagable {
		[field: Min(1)]
		[field: FormerlySerializedAs("_maxValue")]
		[field: SerializeField] public int MaxValue { get; private set; } = 1;
		public int Value { get; private set; }

		public event ValueChange<int> ValueChanged;
		public event Action<int> Damaged;
		public event Action RunOut;

		private void Awake() {
			Value = MaxValue;
		}

		private void Set(int value) {
			var oldValue = Value;
			Value = value;
			if (Value < 0) {
				Value = 0;
			}
			ValueChanged?.Invoke(oldValue, Value);
			if (Value <= 0) { 
				RunOut?.Invoke();
				Destroy(gameObject);
			}
		}

		public int GetValue() {
			return Value;
		}
		public void Add(int points) {
			Set(Value + points);
		}
		public void GiveDamage(int points) {
			points = Mathf.Abs(points);
			Damaged?.Invoke(points);
			Set(Value - points);
		}
	}
}