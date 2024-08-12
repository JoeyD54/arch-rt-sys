using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class DieCommand : CommandBase
	{
		//KillShip will:
		/*
		 * 
		 * update lives counter
		 * remove ship after x time
		 */

		public DieCommand(GameObject _GameObject)
		{
			gameObjToKill = _GameObject;
		}

		public override void Execute(float deltaTime)
		{
			gameObjToKill.Remove();

			Ship myShip = ShipMan.GetShip();

			if(myShip.shipLives == 0)
			{
				//Game over.
				ScenePlay.GameOver();
			}
			else
			{

				TimerEventMan.Add(TimerEvent.Name.JesusMode, new ShipResurrectCommand(), 3);
			}

			//TODO switch to player 2 (EXTRA CREDIT)
			
			
		}


		GameObject gameObjToKill;
	}
}
