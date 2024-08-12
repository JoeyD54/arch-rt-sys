using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class BirdGrid : Composite
	{
		public BirdGrid()
			:base(GameObject.Name.BirdGrid, psSpriteProxyNull)
		{

		}

		//LTN - BirdGrid
		private static SpriteProxyNull psSpriteProxyNull = new SpriteProxyNull();
	}
}
