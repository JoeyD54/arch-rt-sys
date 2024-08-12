using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class LoadNextSceneCommand : CommandBase
	{
		public LoadNextSceneCommand(SceneContext.Scene _sceneName)
		{
			pSceneName = _sceneName;
		}

		public override void Execute(float deltaTime)
		{

			//All resets ONLY HAPPEN ON GAME OVER.
			//This might be used for switching between player 1 and 2.
			//Wrap all but setState with a conditional


			AlienGrid pAlienGrid = (AlienGrid)GameObjectNodeMan.Find(GameObject.Name.AlienGrid);

			AlienFactory pFactory = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes);

			pFactory.ClearGrid();

			float xStatic = 66.0f;
			float xSpaceBetween = 0.0f;
			float ySpaceBetween = 66.0f;

			for (int i = 0; i < 11; i++)
			{
				xSpaceBetween = xStatic * i;

				AlienColumn pAlienColumn = pFactory.CreateAlienColumn(60.0f, 825.0f, xSpaceBetween, ySpaceBetween);

				pAlienGrid.Add(pAlienColumn);
			}

			ShieldFactory.CreateSingleShield(100, 200, false, GameObject.Name.ShieldGrid);
			ShieldFactory.CreateSingleShield(295, 200, false, GameObject.Name.ShieldGrid1);
			ShieldFactory.CreateSingleShield(485, 200, false, GameObject.Name.ShieldGrid2);
			ShieldFactory.CreateSingleShield(680, 200, false, GameObject.Name.ShieldGrid3);

			FontMan.Remove(FontMan.Find(Font.Name.GameOver));

			//Remove the splats
			SpriteBatch pSpriteBatch = SpriteBatchMan.Find(SpriteBatch.Name.BigBoomBooms);
			while (pSpriteBatch != null)
			{
				SpriteBatchMan.Remove(pSpriteBatch);
				pSpriteBatch = SpriteBatchMan.Find(SpriteBatch.Name.BigBoomBooms);
			}


			SceneContext.SetState(pSceneName);

			
		}

		SceneContext.Scene pSceneName;
	}
}
