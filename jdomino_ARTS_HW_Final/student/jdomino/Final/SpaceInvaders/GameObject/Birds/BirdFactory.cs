using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class BirdFactory
	{
		public BirdFactory(SpriteBatch.Name spriteBatchName)
		{
			pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
			Debug.Assert(pSpriteBatch != null);
		}

		public GameObject Create(BirdBase.Type type, float posX, float posY)
		{
			GameObject pGameObject = null;

			switch(type)
			{
				case BirdBase.Type.Green:
					//LTN - BirdFactory
					pGameObject = new BirdGreen(Sprite.Name.GreenBird, posX, posY);
					break;
				case BirdBase.Type.Red:
					//LTN - BirdFactory
					pGameObject = new BirdRed(Sprite.Name.RedBird, posX, posY);
					break;
				case BirdBase.Type.White:
					//LTN - BirdFactory
					pGameObject = new BirdWhite(Sprite.Name.WhiteBird, posX, posY);
					break;
				case BirdBase.Type.Yellow:
					//LTN - BirdFactory
					pGameObject = new BirdYellow(Sprite.Name.YellowBird, posX, posY);
					break;

				default:
					//Things screwed up
					Debug.Assert(false);
					break;
			}

			pSpriteBatch.Attach(pGameObject);

			return pGameObject;
		}

		SpriteBatch pSpriteBatch;
	}
}
