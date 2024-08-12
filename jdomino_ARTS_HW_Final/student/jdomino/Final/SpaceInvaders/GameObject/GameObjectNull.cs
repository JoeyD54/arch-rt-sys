using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class GameObjectNull : Leaf
	{
		/**********************
		* 
		* Constructor
		* 
		**********************/

		public GameObjectNull()
			:base(GameObject.Name.Null_Object, Sprite.Name.Null_Object, 0, 0)
		{

		}

		/**********************
		* 
		* Public Methods
		* 
		**********************/
		/**********************
		* 
		* Private Methods
		* 
		**********************/
		/**********************
		* 
		* Override Methods
		* 
		**********************/

		public override void Accept(ColVisitor other)
		{
			//Null object collision.
			other.VisitNullGameObject(this);
		}

		//public override void Move(float x, float y)
		//{
			
		//}

		public override void Update()
		{
			//We're null. Do nothing
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/

		//LTN - GameObjectNull
		private static SpriteProxyNull pSpriteProxyNull = new SpriteProxyNull();
	}
}
