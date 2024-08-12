using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class SpriteProxy : SpriteBase
	{
		/**********************
		* 
		* Constructor and Enum
		* 
		**********************/

		public enum Name
		{
			Proxy,
			Null_Object,
			Unitialized
		}

		public SpriteProxy()
			: base()
		{
			privClear();
		}

		protected SpriteProxy(SpriteProxy.Name _name)
			:base()
		{
			name = _name;
			privClear();
		}

		/**********************
		* 
		* Public Methods
		* 
		**********************/

		public void Set (Sprite.Name _name)
		{
			name = SpriteProxy.Name.Proxy;

			x = 0.0f;
			y = 0.0f;

			sx = 1.0f;
			sy = 1.0f;

			pSprite = SpriteMan.Find(_name);
			Debug.Assert(pSprite != null);
		}

		/**********************
		* 
		* Private Methods
		* 
		**********************/

		private void privPushToReal()
		{
			Debug.Assert(pSprite != null);

			pSprite.x = x;
			pSprite.y = y;

			pSprite.sx = sx;
			pSprite.sy = sy;
		}

		private void privClear()
		{
			name = SpriteProxy.Name.Unitialized;

			x = 0.0f;
			y = 0.0f;

			sx = 0.0f;
			sy = 0.0f;

			pSprite = null;
		}

		/**********************
		* 
		* Overrides
		* 
		**********************/

		public override void Update()
		{
			privPushToReal();
			pSprite.Update();
		}

		public override void Render()
		{
			privPushToReal();

			pSprite.Update();
			pSprite.Render();
		}

		public override object GetName()
		{
			return base.GetName();
		}

		public override bool Compare(NodeBase pTargetNode)
		{
			Debug.Assert(pTargetNode != null);

			SpriteProxy pDataB = (SpriteProxy)pTargetNode;

			bool status = false;

			if(pSprite.name== pDataB.pSprite.name)
			{
				status = true;
			}

			return status;
		}

		public override void Wash()
		{
			privClear();
		}

		override public void Dump()
		{
			// we are using HASH code as its unique identifier 
			Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

			// Data:
			if (pSprite != null)
			{
				Debug.WriteLine("       Sprite:{0} ({1})", this.pSprite.GetName(), this.pSprite.GetHashCode());
			}
			else
			{
				Debug.WriteLine("       Sprite: null");
			}
			Debug.WriteLine("        (x,y): {0},{1}", this.x, this.y);

			base.Dump();
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/

		public Name name;
		public float x;
		public float y;
		public float sx;
		public float sy;
		public Sprite pSprite;
	}
}
