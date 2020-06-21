using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace Tests
{
	public class MovementTest : SceneTestFixture
	{
		private const float _delay = 0.1f;

		[UnityTest]
		public IEnumerator ReachesTheEndOfTheLevel()
		{
			var levelData = new LevelData
			{
				PlayerPosition = new Vector2Int(8, -1),
				Board = new int[,] {
					{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
					{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
					{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
					{ 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1 },
					{ 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
					{ 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1 },
					{ 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
					{ 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
					{ 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
					{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				},
			};
			StaticContext.Container.BindInstance(levelData);

			yield return LoadScene("SampleScene");

			var commander = SceneContainer.Resolve<Commander>();

			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(0, -1)));

			yield return new WaitForSeconds(_delay);
			commander.Undo();

			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(0, 1)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(0, 1)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(0, 1)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(0, 1)));

			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));

			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(0, -1)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(0, -1)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(0, -1)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(0, -1)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(0, -1)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(0, -1)));

			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));

			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(0, 1)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(0, 1)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(0, 1)));

			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));
			yield return new WaitForSeconds(_delay);
			commander.Execute(new MovePlayer(new Vector2Int(-1, 0)));

			yield return new WaitForSeconds(0.3f);

			var playerPosition = GameObject.Find("Player").transform.position;
			Assert.AreEqual(playerPosition, new Vector3(-9, 0));
		}
	}
}
