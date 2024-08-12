using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class AnimCommand : CommandBase
	{

		/**********************
		* 
		* Constructor
		* 
		**********************/

		public AnimCommand(Sprite.Name spriteName, float _timesWon = 0)
		{
			pSprite = SpriteMan.Find(spriteName);
			Debug.Assert(pSprite != null);

			//LTN - AnimCommand
			poSLinkMan = new SLinkMan();
			Debug.Assert(poSLinkMan != null);

			pIterator = poSLinkMan.GetIterator();
			Debug.Assert(pIterator != null);

			timesWon = _timesWon / 40;
		}

		/**********************
		* 
		* Public Methods
		* 
		**********************/

		public void Attach(Image.Name imageName)
		{
			Image pImage = ImageMan.Find(imageName);
			Debug.Assert(pImage != null);

			//LTN - AnimCommand
			ImageNode pImageNode = new ImageNode(pImage);
			Debug.Assert(pImageNode != null);

			poSLinkMan.AddToFront(pImageNode);

			pIterator = poSLinkMan.GetIterator();
		}

		/**********************
		* 
		* Overrides
		* 
		**********************/

		public override void Execute(float deltaTime)
		{
			ImageNode pImageNode = (ImageNode)pIterator.Curr();

			ScenePlay scenePlay = (ScenePlay)SceneContext.GetState();
			timesWon = scenePlay.timesWon;
			timesWon = timesWon / 20;

			if (pIterator.Next() == null)
			{
				//Loop back to top if we ended
				pIterator.First();
			}

			pSprite.SwapImage(pImageNode.pImage);

			//Calculate Alien Grid Size. Increase speed as it lowers
			AlienGrid pAlienGrid = (AlienGrid)GameObjectNodeMan.Find(GameObject.Name.AlienGrid);

			float gridCount = pAlienGrid.GetAlienCount();

			//to be subtracted from deltaTime
			float newDelta = deltaTime;

			if (pImageNode.pImage.name == Image.Name.ShipDead1 || pImageNode.pImage.name == Image.Name.ShipDead2)
			{
				Debug.WriteLine("ShipDead anim");
			}
			else
			{
				if (gridCount > 0)
				{
					if (gridCount == 1)
					{
						newDelta = 0.05f - timesWon;
					}
					else if (gridCount == 2)
					{
						newDelta = 0.08f - timesWon;
					}
					else if (gridCount == 3)
					{
						newDelta = 0.1f - timesWon;
					}
					else if (gridCount > 3 && gridCount < 5)
					{
						newDelta = 0.2f - timesWon;
					}
					else if (gridCount > 5 && gridCount < 10)
					{
						newDelta = 0.3f - timesWon;
					}
					else if (gridCount > 10 && gridCount < 20)
					{
						newDelta = 0.5f - timesWon;
					}
					else if (gridCount > 20 && gridCount < 30)
					{
						newDelta = 0.6f - timesWon;
					}
					else if (gridCount > 30 && gridCount < 40)
					{
						newDelta = 0.8f - timesWon;
					}
					else if (gridCount > 40 && gridCount <= 55)
					{
						newDelta = 1 - timesWon;
					}

					if (newDelta <= 0)
					{
						newDelta = 0.01f;
					}
				}
			}
				TimerEventMan.Add(TimerEvent.Name.Animation, this, newDelta);
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/

			//Used to switch sprites after certain time
		private Sprite pSprite;
		private SLinkMan poSLinkMan;
		private Iterator pIterator;
		private float timesWon;

	}
}
