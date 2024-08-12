using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class RemoveShipObserver : ColObserver
	{
		public RemoveShipObserver()
		{
			this.pShip = null;
		}

		public RemoveShipObserver(RemoveShipObserver so)
		{
			this.pShip = so.pShip;
		}

		public override void Notify()
		{			
			this.pShip = (Ship)this.pSubject.pGameObjB;
			Debug.Assert(this.pShip != null);

			if(pShip.bMarkForDeath == false)
			{
				pShip.bMarkForDeath = true;

				//this.pShip.pSpriteProxy.

				//Delay
				RemoveShipObserver pObserver = new RemoveShipObserver(this);
				DelayedObjectMan.Attach(pObserver);
			}	


		}
		public override void Execute()
		{
			AnimCommand deathAnim = new AnimCommand(Sprite.Name.Ship);
			deathAnim.Attach(Image.Name.ShipDead2);
			deathAnim.Attach(Image.Name.ShipDead1);

			Ship ship = ShipMan.GetShip();
			ship.shipLives--;

			ship.SetState(ShipMan.MoveState.Dead);
			ship.SetState(ShipMan.MissileState.Dead);
			
			TimerEventMan.RemoveAll();

			//Remove splats on screen

			//SpriteBatch alienBatch = SpriteBatchMan.Find(SpriteBatch.Name.BigBoomBooms);
			
			

			//if(alienBatch != null)
			//{

			//	SpriteNodeMan sbm = alienBatch.GetSBNodeMan();

			//	sbm.baseDump();

				//Debug.WriteLine("");
				//Debug.WriteLine("Column");

				//Iterator pIterator = 
				//Debug.Assert(pIterator != null);

				//GameObject pNode = (GameObject)pIterator.First();

				//while (!pIterator.IsDone())
				//{
				//	Debug.Assert(pNode != null);

				//	pNode.Dump();

				//	pNode = (GameObject)pIterator.Next();
				//}

			//}

			TimerEventMan.Add(TimerEvent.Name.Animation, deathAnim, 0.15f);
			TimerEventMan.Add(TimerEvent.Name.DieCommand, new DieCommand(this.pShip), 3.0f);
			SoundManager.PlaySound("explosion.wav");		
		}

		//Data:
		private GameObject pShip;
	}
}
