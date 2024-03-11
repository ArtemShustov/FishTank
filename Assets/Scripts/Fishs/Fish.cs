using Game.Health;
using Game.Paths;
using UnityEngine;

namespace Game.Fishs {
	public class Fish: MonoBehaviour {
		[SerializeField] private HealthProperty _health;
		[SerializeField] private MoveByPath _movement;

		public void SetPath(Vector2[] path) {
			if (_movement != null) {
				_movement.SetPath(path);
			}
		}
		public HealthProperty GetHealth() {
			return _health;
		}
	}
}