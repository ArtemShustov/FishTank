using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Utils {
	public class RestartScene: MonoBehaviour {
		public void Restart() {
			if (Application.isPlaying) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}
}