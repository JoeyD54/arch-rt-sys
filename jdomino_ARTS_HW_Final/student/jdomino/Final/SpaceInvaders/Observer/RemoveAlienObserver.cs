using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class RemoveAlienObserver : ColObserver
	{
		public RemoveAlienObserver()
		{
			pAlien = null;
		}

		public RemoveAlienObserver(RemoveAlienObserver m)
		{
			Debug.Assert(m.pAlien != null);
			pAlien = m.pAlien;
		}
		public override void Notify()
		{
			Debug.WriteLine("Alien_Observer: {0} {1}", this.pSubject.pGameObjA, this.pSubject.pGameObjB);

			this.pAlien = this.pSubject.pGameObjB;
			Debug.Assert(this.pAlien != null);

			UpdateScoreCommand Score; //update score based on alien
			if (pAlien.name == GameObject.Name.OctopusAlien)
			{
				Score = new UpdateScoreCommand(10);
			}
			else if (pAlien.name == GameObject.Name.CrabAlien)
			{
				Score = new UpdateScoreCommand(20);
			}
			else if (pAlien.name == GameObject.Name.SquidAlien)
			{
				Score = new UpdateScoreCommand(30);
			}
			else //has to be red alien
			{
				Score = new UpdateScoreCommand(40);
			}
			TimerEventMan.Add(TimerEvent.Name.UpdateScoreCommand, Score, 0);


			if (pAlien.bMarkForDeath == false)
			{
				pAlien.bMarkForDeath = true;
				
				if(pAlien.pNext == null && pAlien.pPrev == null)
				{
					GameObject pColumn = (GameObject)IteratorForwardComposite.GetParent(pAlien);
					pColumn.bMarkForDeath = true;
				}
				//   Delay
				RemoveAlienObserver pObserver = new RemoveAlienObserver(this);
				DelayedObjectMan.Attach(pObserver);
			}
		}

		public override void Execute()
		{
			//bool removeColumn = false;
			//bool removeGrid = false;
			AlienColumn pAColumn= (AlienColumn)IteratorForwardComposite.GetParent(pAlien);
			GameObject pGrid = (GameObject)IteratorForwardComposite.GetParent(pAColumn);

			SpriteProxy splat = null;
			if(pAlien.name == GameObject.Name.UFOAlien)
			{
				splat = new SpriteProxy();
				splat.Set(Sprite.Name.AlienUFODead);
				splat.pSprite.SwapColor(1, 0, 0);
				splat.x = pAlien.x;
				splat.y = pAlien.y;
			}
			else
			{
				splat = new SpriteProxy();
				splat.Set(Sprite.Name.AlienDead);
				splat.x = pAlien.x;
				splat.y = pAlien.y;
			}
			

			// Brick
			if (pAlien.GetNumChildren() == 0)
			{
				pAlien.bMarkForDeath = true;
				pAlien.Remove();
			}

			// Column 
			if (pAColumn.GetNumChildren() == 0)
			{
				pAColumn.bMarkForDeath = true;
				pAColumn.Remove();
			}

			//if (pAlien.name == GameObject.Name.UFOAlien)
			//{
			//	if (pGrid.GetNumChildren() == 0)
			//	{
			//		pGrid.Remove();
			//	}
			//}


			SpriteBatch pSpriteBatch = SpriteBatchMan.AddByPriority(SpriteBatch.Name.BigBoomBooms, 6);
			pSpriteBatch.Attach(splat);

			TimerEventMan.Add(TimerEvent.Name.RemoveExplosionCommand, new RemoveExplosionCommand(splat), 0.25f);

			if (pGrid.name == GameObject.Name.AlienGrid)
			{
				if (pGrid.GetNumChildren() == 0)
				{
					//You won the level, pause and reset
					TimerEventMan.RemoveAll();

					//GameObjectNodeMan.Remove(GameObjectNodeMan.Find(GameObject.Name.Bomb));

					TimerEventMan.Add(TimerEvent.Name.LevelCompleted, new LevelCompleteEvent(), 5);
				}
			}

			SoundManager.PlaySound("invaderkilled.wav");
		}

		private GameObject pAlien;
	}
}
