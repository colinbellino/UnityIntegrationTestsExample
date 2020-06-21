using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class GameManager : MonoBehaviour
{
	private Keyboard _keyboard;

	private Commander _commander;
	private LevelData _levelData;

	[Inject]
	public void Construct(Commander commander, LevelData levelData)
	{
		_commander = commander;
		_levelData = levelData;
	}

	private void Start()
	{
		_keyboard = Keyboard.current;

		var loadLevelCommand = new LoadLevel(_levelData.Board, _levelData.PlayerPosition);
		_commander.Execute(loadLevelCommand);
	}

	private void Update()
	{
		// In a real project, we would check for walls and other entities before doing this.

		// Move player with direction keys.
		if (_keyboard.leftArrowKey.wasReleasedThisFrame)
		{
			var moveCommand = new MovePlayer(new Vector2Int(-1, 0));
			_commander.Execute(moveCommand);
		}
		else if (_keyboard.rightArrowKey.wasReleasedThisFrame)
		{
			var moveCommand = new MovePlayer(new Vector2Int(1, 0));
			_commander.Execute(moveCommand);
		}
		else if (_keyboard.upArrowKey.wasReleasedThisFrame)
		{
			var moveCommand = new MovePlayer(new Vector2Int(0, 1));
			_commander.Execute(moveCommand);
		}
		else if (_keyboard.downArrowKey.wasReleasedThisFrame)
		{
			var moveCommand = new MovePlayer(new Vector2Int(0, -1));
			_commander.Execute(moveCommand);
		}
		// Press ESCAPE to undo the last action.
		else if (_keyboard.escapeKey.wasPressedThisFrame)
		{
			_commander.Undo();
		}
	}
}
