using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	abstract class BirdBase : Leaf
	{ 
		public enum Type
		{
			Red,
			Yellow,
			Green,
			White
		}

		protected BirdBase(GameObject.Name _gameObjName, Sprite.Name _spriteName, float _x, float _y)
			:base(_gameObjName, _spriteName, _x, _y)
		{

		}
	}
}
