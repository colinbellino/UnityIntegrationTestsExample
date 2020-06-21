using System;
using System.Collections.Generic;
using UnityEngine;

public class Commander
{
	private readonly GameState _state;
	private readonly Stack<ICommand> _commands = new Stack<ICommand>();

	public static Action<GameState> StateChanged;

	public Commander()
	{
		_state = new GameState();
	}

	public void Execute(ICommand command)
	{
		command.Execute(_state);
		_commands.Push(command);
		StateChanged?.Invoke(_state);
		Debug.Log($"Execute -> {command.GetType().Name}.");
	}

	public void Undo()
	{
		if (_commands.Count == 0)
		{
			Debug.Log("Nothing to undo.");
			return;
		}

		var command = _commands.Pop();
		command.Undo(_state);
		StateChanged?.Invoke(_state);
		Debug.Log($"Undo -> {command.GetType().Name}");
	}
}
