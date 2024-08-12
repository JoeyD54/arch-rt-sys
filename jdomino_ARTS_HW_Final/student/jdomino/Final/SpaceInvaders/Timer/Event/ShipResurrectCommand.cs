using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class ShipResurrectCommand : CommandBase
	{
		public ShipResurrectCommand()
		{
		}

		public override void Execute(float deltaTime)
		{
			ScenePlay scenePlay = (ScenePlay)SceneContext.GetState();

			//Re-add to spritebatch
			//Re-add to gameobjectnodeMan
			Ship pShip = ShipMan.GetShip();
			ShipMan.ActivateShip();
			pShip.SetState(ShipMan.MissileState.Ready);
			pShip.SetState(ShipMan.MoveState.MoveBoth);

			//TODO update life counter on screen
			//Update ship icons on bottom (1 - # of lives)
			TimerEventMan.RemoveAll();

			pShip.pSpriteProxy.pSprite.SwapImage(ImageMan.Find(Image.Name.Ship));

			if(pShip.shipLives == 2)
			{
				FontMan.Remove(FontMan.Find(Font.Name.LifeCount));
				FontMan.Add(Font.Name.LifeCount, SpriteBatch.Name.Texts, pShip.shipLives.ToString(), Glyph.Name.Consolas36pt, 10, 35);

				SpriteMan.Remove(SpriteMan.Find(Sprite.Name.ShipLife2));
			}
			else if(pShip.shipLives == 1)
			{
				FontMan.Remove(FontMan.Find(Font.Name.LifeCount));
				FontMan.Add(Font.Name.LifeCount, SpriteBatch.Name.Texts, pShip.shipLives.ToString(), Glyph.Name.Consolas36pt, 10, 35);

				SpriteMan.Remove(SpriteMan.Find(Sprite.Name.ShipLife1));
			}

			//Remove the splats
			SpriteBatch pSpriteBatch = SpriteBatchMan.Find(SpriteBatch.Name.BigBoomBooms);
			while(pSpriteBatch != null)
			{
				SpriteBatchMan.Remove(pSpriteBatch);
				pSpriteBatch = SpriteBatchMan.Find(SpriteBatch.Name.BigBoomBooms);
			}
			


			AnimCommand pSquidAnim = new AnimCommand(Sprite.Name.AlienSquid, scenePlay.timesWon);
			pSquidAnim.Attach(Image.Name.AlienSquid);
			pSquidAnim.Attach(Image.Name.AlienSquid2);

			//--- Crabs --- //

			//LTN - TimerEventManager
			AnimCommand pCrabAnim = new AnimCommand(Sprite.Name.AlienCrab, scenePlay.timesWon);
			pCrabAnim.Attach(Image.Name.AlienCrabDown);
			pCrabAnim.Attach(Image.Name.AlienCrabUp);

			// --- Octopus --- //

			//LTN - TimerEventManager
			AnimCommand pOctoAnim = new AnimCommand(Sprite.Name.AlienOctopus, scenePlay.timesWon);
			pOctoAnim.Attach(Image.Name.AlienOctopusClosed);
			pOctoAnim.Attach(Image.Name.AlienOctopusOpen);

			MoveCommand pAlienGridMoveCmd = new MoveCommand(scenePlay.timesWon);

			Random pRandom = new Random();

			BombSpawnEvent pBombSpawnEvent = new BombSpawnEvent(pRandom);


			//Animation doesnt work for first in list without duplicating it for some reason.
			TimerEventMan.Add(TimerEvent.Name.Animation, pSquidAnim, 1.0f);
			TimerEventMan.Add(TimerEvent.Name.Animation, pSquidAnim, 1.0f);
			TimerEventMan.Add(TimerEvent.Name.Animation, pCrabAnim, 1.0f);
			TimerEventMan.Add(TimerEvent.Name.Animation, pOctoAnim, 1.0f);
			TimerEventMan.Add(TimerEvent.Name.MoveGrid, pAlienGridMoveCmd, 1.0f);
			
			//TimerEventMan.Add(TimerEvent.Name.RandomUFOSpawn, pUFOSpawnCmd, 2);

			TimerEventMan.Add(TimerEvent.Name.BombSpawnEvent, pBombSpawnEvent, 1);



			
			//scenePlay.LoadOnEntry();

		}
	}
}
