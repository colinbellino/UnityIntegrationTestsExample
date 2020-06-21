using UnityEngine;

public class MovePlayer : ICommand
{
	private readonly Vector2Int _direction;

	public MovePlayer(Vector2Int direction)
	{
		_direction = direction;
	}

	public void Execute(GameState state)
	{
		state.PlayerPosition += _direction;
	}

	public void Undo(GameState state)
	{
		state.PlayerPosition -= _direction;
	}
}

public class LoadLevel : ICommand
{
	private readonly int[,] _board;
	private readonly Vector2Int _playerPosition;

	private int[,] _previousBoard;
	private Vector2Int _previousPlayerPosition;

	public LoadLevel(int[,] board, Vector2Int playerPosition)
	{
		_board = board;
		_playerPosition = playerPosition;
	}

	public void Execute(GameState state)
	{
		_previousBoard = state.Board;
		_previousPlayerPosition = state.PlayerPosition;

		state.Board = _board;
		state.PlayerPosition = _playerPosition;
	}

	public void Undo(GameState state)
	{
		state.Board = _previousBoard;
		state.PlayerPosition = _previousPlayerPosition;
	}
}

public interface ICommand
{
	void Execute(GameState state);
	void Undo(GameState state);
}
