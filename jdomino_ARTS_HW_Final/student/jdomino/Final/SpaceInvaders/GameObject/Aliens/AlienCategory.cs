using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	abstract public class AlienCategory : Leaf
	{
		public enum Type
		{
			Squid,
			Crab,
			Octopus,

			Column,
			Grid,

			Unitialized
		}

		//public abstract void Move(float x, float y);

		protected AlienCategory(GameObject.Name gameObjName, Sprite.Name spriteName, float _x, float _y)
			:base(gameObjName, spriteName, _x, _y)
		{

		}
	}
}
