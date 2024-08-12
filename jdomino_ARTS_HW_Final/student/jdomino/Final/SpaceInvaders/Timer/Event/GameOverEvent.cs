using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class GameOverEvent : CommandBase
	{
		public GameOverEvent()
		{
			alreadyCalled = false;
		}
		public override void Execute(float deltaTime)
		{
			if(!alreadyCalled)
			{
				ScenePlay.GameOver();
				alreadyCalled = true;
			}
			
		}
		bool alreadyCalled;
	}
}
