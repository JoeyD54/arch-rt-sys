using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class BombAnimCommand : CommandBase
	{

		/**********************
		* 
		* Constructor
		* 
		**********************/

		public BombAnimCommand(Sprite.Name spriteName)
		{
			pSprite = SpriteMan.Find(spriteName);
			Debug.Assert(pSprite != null);

			//LTN - AnimCommand
			poSLinkMan = new SLinkMan();
			Debug.Assert(poSLinkMan != null);

			pIterator = poSLinkMan.GetIterator();
			Debug.Assert(pIterator != null);
		}

		/**********************
		* 
		* Public Methods
		* 
		**********************/

		public void Attach(Image.Name imageName)
		{
			Image pImage = ImageMan.Find(imageName);
			Debug.Assert(pImage != null);

			//LTN - AnimCommand
			ImageNode pImageNode = new ImageNode(pImage);
			Debug.Assert(pImageNode != null);

			poSLinkMan.AddToFront(pImageNode);

			pIterator = poSLinkMan.GetIterator();
		}

		/**********************
		* 
		* Overrides
		* 
		**********************/

		public override void Execute(float deltaTime)
		{
			ImageNode pImageNode = (ImageNode)pIterator.Curr();

			if (pIterator.Next() == null)
			{
				//Loop back to top if we ended
				pIterator.First();
			}

			pSprite.SwapImage(pImageNode.pImage);


			TimerEventMan.Add(TimerEvent.Name.BombAnimation, this, deltaTime);
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/

		//Used to switch sprites after certain time
		private Sprite pSprite;
		private SLinkMan poSLinkMan;
		private Iterator pIterator;

	}
}
