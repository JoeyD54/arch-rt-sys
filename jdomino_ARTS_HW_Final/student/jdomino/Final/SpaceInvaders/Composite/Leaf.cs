using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	abstract public class Leaf : GameObject
	{
		/**********************
		* 
		* Constructor
		* 
		**********************/

		public Leaf(GameObject.Name gameObjName, Sprite.Name spriteName, float x, float y)
			:base (Component.Container.Leaf, gameObjName, spriteName, x, y)
		{

		}

		//protected Leaf(GameObject.Name gameObjName, SpriteProxy pProxy)
		//	:base(Component.Container.Leaf, gameObjName, pProxy)
		//{

		//}

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

		public override void Remove(Component c)
		{
			Debug.Assert(false);
		}


		public override void Resurrect()
		{
			base.Resurrect();
		}

		public override void Print()
		{
			Dump();
		}

		public override void Wash()
		{
			Debug.Assert(false);
		}

		override public void Add(Component c)
		{
			Debug.Assert(false);
		}

		//override public void Remove(Component c)
		//{
		//	Debug.Assert(false);
		//}

		override public void DumpNode()
		{
			Debug.WriteLine(" GameObject Name: {0} ({1}) parent:{2}", this.GetName(), this.GetHashCode(), IteratorForwardComposite.GetParent(this).GetHashCode());
		}


		/**********************
		* 
		* Local Variables
		* 
		**********************/
	}
}
