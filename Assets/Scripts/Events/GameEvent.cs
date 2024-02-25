using UnityEngine;

namespace Game.Events {
	public delegate void GameEvent(object sender);
	public delegate void GameEvent<T>(T sender);
}