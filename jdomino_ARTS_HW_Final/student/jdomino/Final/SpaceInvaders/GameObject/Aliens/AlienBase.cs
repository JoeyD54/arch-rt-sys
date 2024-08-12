using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
	abstract class AlienBase : Leaf
	{
		public enum Type
		{
			Grid,
			Column,
			Squid,
			Crab,
			Octopus,
			UFO,
			UFOGrid,
			Unknown
		}

		protected AlienBase(GameObject.Name _gameObjName, Sprite.Name _spriteName, float _x, float _y)
			: base(_gameObjName, _spriteName, _x, _y)
		{

		}
	}
}
