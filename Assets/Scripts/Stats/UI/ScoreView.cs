using TMPro;
using UnityEngine;

namespace Game.Stats.UI {
	public class ScoreView: MonoBehaviour {
		[SerializeField] private string _pattern = "Score: {0}";
		[SerializeField] private TMP_Text _label;
		[SerializeField] private ScoreCounter _score;

		private void UpdateLabel(int oldValue, int newValue) {
			_label.text = string.Format(_pattern, newValue);
		}

		private void OnEnable() {
			_score.ValueChanged += UpdateLabel;
			UpdateLabel(_score.Value, _score.Value);
		}
		private void OnDisable() {
			_score.ValueChanged -= UpdateLabel;
		}
	}
}