using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Paths {
	public class PathBuilder: MonoBehaviour {
		[SerializeField] private Color _color;

		public Vector2[] GetPath() {
			var path = new List<Vector2>();
			foreach (var point in transform) {
				path.Add(((Transform)point).position);
			}
			return path.ToArray();
		}
		private void OnDrawGizmos() {
			Gizmos.color = _color;
			Gizmos.DrawLineStrip(GetPath().Select((x) => (Vector3)x).ToArray(), true);
		}
	}
}