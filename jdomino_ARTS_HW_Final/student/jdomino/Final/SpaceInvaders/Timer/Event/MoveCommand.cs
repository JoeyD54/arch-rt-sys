using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class MoveCommand : CommandBase
	{

		/**********************
		* 
		* Constructor
		* 
		**********************/
		public MoveCommand(float _timesWon)
		{
			nextSound = 4;
			timesWon = _timesWon / 40;
		}

		/**********************
		* 
		* Public Methods
		* 
		**********************/

		/**********************
		* 
		* Overrides
		* 
		**********************/

		public override void Execute(float deltaTime)
		{
			ScenePlay scenePlay = (ScenePlay)SceneContext.GetState();
			timesWon = scenePlay.timesWon;
			timesWon = timesWon / 20;

			AlienGrid pAlienGrid = (AlienGrid) GameObjectNodeMan.Find(GameObject.Name.AlienGrid);

			if(pAlienGrid.moveDown)
			{
				pAlienGrid.MoveGridDown();
				pAlienGrid.moveDown = false;
			}
			else
			{
			 	pAlienGrid.MoveGrid();
			}
			

			if (nextSound == 4)
			{
				SoundManager.sndEngine.Play2D("fastinvader4.wav");
				nextSound = 1;
			}
			else if (nextSound == 1)
			{
				SoundManager.sndEngine.Play2D("fastinvader1.wav");
				nextSound = 2;
			}
			else if (nextSound == 2)
			{
				SoundManager.sndEngine.Play2D("fastinvader2.wav");
				nextSound = 3;
			}
			else if (nextSound == 3)
			{
				SoundManager.sndEngine.Play2D("fastinvader3.wav");
				nextSound = 4;
			}

			//Calculate aliens in count, speed up movement time

			int gridCount = pAlienGrid.GetAlienCount();

			//to be subtracted from deltaTime
			float newDelta = deltaTime;
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
				else if( gridCount > 40 && gridCount <= 55)
				{
					newDelta = 1 - timesWon;
				}

				if(newDelta <= 0)
				{
					newDelta = 0.01f;
				}
				

				TimerEventMan.Add(TimerEvent.Name.MoveGrid, this, newDelta);
			}
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/
		private int nextSound;
		private float timesWon;
	}
}

