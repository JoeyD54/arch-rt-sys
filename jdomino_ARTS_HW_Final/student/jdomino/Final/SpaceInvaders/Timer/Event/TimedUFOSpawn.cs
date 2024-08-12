using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class TimedUFOSpawn : CommandBase
	{
		public TimedUFOSpawn()
		{

		}

		public override void Execute(float deltaTime)
		{

			Sprite nullSprite = SpriteMan.Find(Sprite.Name.Null_Object);

			if(nullSprite == null)
			{
				
				SpriteMan.Add(Sprite.Name.Null_Object, Image.Name.HotPink, 0, 0, 0, 0);
			}

			AlienFactory alienFactory = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes);
			UFOGrid pGrid = (UFOGrid)alienFactory.Create(AlienBase.Type.UFOGrid);
			AlienColumn pColumn = (AlienColumn)alienFactory.Create(AlienBase.Type.Column);
			AlienUFO pUFO = (AlienUFO)alienFactory.Create(AlienBase.Type.UFO, 75, 900);
			
			pUFO.ActivateCollisionSprite(SpriteBatchMan.Find(SpriteBatch.Name.Boxes));
			pUFO.ActivateSprite(SpriteBatchMan.Find(SpriteBatch.Name.Aliens));
			pUFO.pSpriteProxy.pSprite.SwapColor(1, 0, 0);
			pUFO.Update();

			pColumn.Add(pUFO);

			//AlienColumn UFOColumn = (AlienColumn)alienFactory.Create(AlienBase.Type.Column);
			//UFOColumn.Add(pUFO);

			pGrid.Add(pColumn);

			GameObjectNodeMan.Attach(pGrid);

			ColPair pColPair;

			//Missile V UFOGrid
			pColPair = ColPairMan.Add(ColPair.Name.Missile_UFO,
				GameObjectNodeMan.Find(GameObject.Name.MissileGroup),
				pGrid);
			pColPair.Attach(new RemoveMissileObserver());
			pColPair.Attach(new ShipReadyObserver());
			pColPair.Attach(new RemoveAlienObserver());

			//Missile V UFOGrid
			pColPair = ColPairMan.Add(ColPair.Name.Wall_UFO,
				GameObjectNodeMan.Find(GameObject.Name.WallGroup),
				pGrid);
			pColPair.Attach(new RemoveUFOObserver());



			TimerEventMan.Add(TimerEvent.Name.UFOMoveCommand, new UFOMoveCommand(), 0.0f);

			SoundManager.PlaySound("ufo_lowpitch.wav");

			Random r = new Random();
			float ranUFOSpawn = r.Next(10, 30);
			TimerEventMan.Add(TimerEvent.Name.RandomUFOSpawn, this, ranUFOSpawn);

			//For spawning the ufo.
			//Pick a side to spawn from
			//May need collision checks for new "ufo bumpers"
		}
	}
}
