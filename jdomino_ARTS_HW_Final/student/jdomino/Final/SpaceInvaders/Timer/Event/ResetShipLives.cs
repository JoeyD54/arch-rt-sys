using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class ResetShipLives : CommandBase
	{
		public override void Execute(float deltaTime)
		{
			Azul.Color Green = new Azul.Color(0.2f, 0.8f, 0.2f);

			SpriteBatch livesBatch = SpriteBatchMan.Add(SpriteBatch.Name.Player1);
			livesBatch.Attach(SpriteMan.Add(Sprite.Name.ShipLife1, Image.Name.Ship, 120, 40, 80, 38, Green));
			livesBatch.Attach(SpriteMan.Add(Sprite.Name.ShipLife2, Image.Name.Ship, 220, 40, 80, 38, Green));

			//Re-add to spritebatch
			//Re-add to gameobjectnodeMan
			Ship pShip = ShipMan.GetShip();
			ShipMan.ActivateShip();
			pShip.SetState(ShipMan.MissileState.Ready);
			pShip.SetState(ShipMan.MoveState.MoveBoth);


			pShip.pSpriteProxy.pSprite.SwapImage(ImageMan.Find(Image.Name.Ship));

			pShip.shipLives = 3;

			FontMan.Remove(FontMan.Find(Font.Name.LifeCount));
			FontMan.Add(Font.Name.LifeCount, SpriteBatch.Name.Texts, pShip.shipLives.ToString(), Glyph.Name.Consolas36pt, 10, 35);
		}
	}
}
