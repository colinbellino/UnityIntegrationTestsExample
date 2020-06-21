using UnityEngine;
using UnityEngine.Tilemaps;

public class Renderer : MonoBehaviour
{
	[SerializeField] private Transform _player;
	[SerializeField] private Tilemap _boardTilemap;
	[SerializeField] private TileBase _tileEmpty;
	[SerializeField] private TileBase _tileWall;

	private void OnEnable()
	{
		Commander.StateChanged += OnStateChanged;
	}

	private void OnDisable()
	{
		Commander.StateChanged -= OnStateChanged;
	}

	private void OnStateChanged(GameState state)
	{
		// In a real project, we would probably do some diffing to see if the state actually changed.

		RenderBoard(state.Board);
		RenderPlayer(state.PlayerPosition);
	}

	private void RenderBoard(int[,] board)
	{
		_boardTilemap.ClearAllTiles();

		if (board == null)
		{
			return;
		}

		for (int x = 0; x < board.GetLength(0); x++)
		{
			for (int y = 0; y < board.GetLength(1); y++)
			{
				_boardTilemap.SetTile(new Vector3Int(y, x, 0), GetTile(board[x, y]));
			}
		}
	}

	private void RenderPlayer(Vector2Int position)
	{
		_player.position = new Vector3(position.x, position.y, 0f);
	}

	private TileBase GetTile(int value)
	{
		switch (value)
		{
			case 1:
				return _tileWall;
			default:
				return _tileEmpty;
		}
	}
}
