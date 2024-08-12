using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class BirdWhite : BirdBase
	{
		public BirdWhite(Sprite.Name spriteName, float posX, float posY)
			: base(GameObject.Name.WhiteBird, spriteName, posX, posY)
		{

		}

		override public void Move(float _x, float _y)
		{
			this.x += _x;
			this.y += _y;
		}

		override public void Update()
		{
			base.Update();
		}
	}
}
