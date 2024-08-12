using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class UFOMoveCommand : CommandBase
	{
		public UFOMoveCommand()
		{
			soundTimer = 0;
		}

		public override void Execute(float deltaTime)
		{
			//Move UFO on x axis
			//Check if moving left or right
			//Check if hitting upper or bound x
			UFOGrid ufoGrid = (UFOGrid)GameObjectNodeMan.Find(GameObject.Name.UFOGrid);

			ufoGrid.MoveGrid();

			soundTimer++;

			if(soundTimer >= 45)
			{
				SoundManager.PlaySound("ufo_highpitch.wav");
				soundTimer = 0;
			}
			

			//Play sound?

			TimerEventMan.Add(TimerEvent.Name.UFOMoveCommand, this, 0.0f);


		}

		float soundTimer;

	}
}
