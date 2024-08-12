using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	abstract public class GameObject : Component
	{
		/**********************
		* 
		* Enum, Constructors, and Destructor
		* 
		**********************/
		public enum Name
		{
			AlienGrid,
			AlienUFOGrid,
			AlienColumn,

			SquidAlien,
			CrabAlien,
			OctopusAlien,
			UFOAlien,
			UFOGrid,

			MissileGroup,
			Missile,

			Ship,
			ShipRoot,

			WallGroup,
			WallRight,
			WallLeft,
			WallTop,
			WallBottom,

			Bomb,
			BombRoot,

			BumperRight,
			BumperLeft,
			BumperRoot,

			ShieldRoot,
			ShieldGrid,
			ShieldGrid1,
			ShieldGrid2,
			ShieldGrid3,
			ShieldColumn_0,
			ShieldColumn_1,
			ShieldColumn_2,
			ShieldColumn_3,
			ShieldColumn_4,
			ShieldColumn_5,
			ShieldColumn_6,
			ShieldColumn_7,
			ShieldColumn_8,
			ShieldColumn_9,
			ShieldColumn_10,
			ShieldBrick,
			ShieldBrickLeftTop0,
			ShieldBrickLeftTop1,
			ShieldBrickLeftBottom,
			ShieldBrickLeftBottomHalfVert,
			ShieldBrickRightTop0,
			ShieldBrickRightTop1,
			ShieldBrickRightBottom,
			ShieldBrickRightBottomHalfVert,

			Null_Object,
			Uninitialized
		}

		protected GameObject(Component.Container gameObjType, GameObject.Name gameObjName, Sprite.Name proxyName)
			:base(gameObjType)
		{
			name = gameObjName;
			x = 0.0f;
			y = 0.0f;
			bMarkForDeath = false;

			pSpriteName = proxyName;

			SpriteProxy pProxy = SpriteProxyMan.Add(proxyName);
			Debug.Assert(pProxy != null);

			pSpriteProxy = pProxy;
			

			//LTN - GameObject
			poColObject = new ColObject(pSpriteProxy);
			Debug.Assert(poColObject != null);
			
		}

		protected GameObject(Component.Container gameObjType, GameObject.Name gameObjName, Sprite.Name spriteName, float _x, float _y)
			:base(gameObjType)
		{
			this.name = gameObjName;
			this.x = _x;
			this.y = _y;

			this.bMarkForDeath = false;
			this.pSpriteName = spriteName;
			this.pSpriteProxy = SpriteProxyMan.Add(this.pSpriteName);

			// TODO recycle this new
			this.poColObject = new ColObject(this.pSpriteProxy);
			Debug.Assert(this.poColObject != null);
		}

		~GameObject()
		{

		}

		override public void Resurrect()
		{
			this.bMarkForDeath = false;
			//this.pSpriteProxy = SpriteProxyMan.Add(this.pSpriteName);
			Debug.Assert(pSpriteProxy != null);
			Debug.Assert(poColObject != null);

			poColObject.Resurrect(pSpriteProxy);

			// TODO recycle this new
			//this.poColObject = new ColObject(this.pSpriteProxy);
			Debug.Assert(this.poColObject != null);

			base.Resurrect();
		}

		/**********************
		* 
		* Public Methods
		* 
		**********************/

		public virtual void Update()
		{
			Debug.Assert(pSpriteProxy != null);

			pSpriteProxy.x = x;
			pSpriteProxy.y = y;

			Debug.Assert(poColObject != null);
			poColObject.UpdatePos(x, y);

			Debug.Assert(poColObject.pColSprite != null);
			poColObject.pColSprite.Update();
		}

		public void ActivateCollisionSprite(SpriteBatch pSpriteBatch)
		{
			Debug.Assert(pSpriteBatch != null);
			Debug.Assert(this.poColObject != null);
			pSpriteBatch.Attach(this.poColObject.pColSprite);
		}

		public void DeactivateCollisionSprite(SpriteBatch pSpriteBatch)
		{
			Debug.Assert(pSpriteBatch != null);
			Debug.Assert(this.poColObject != null);

			poColObject.pColSprite.sx = 0.0f;
			poColObject.pColSprite.sy = 0.0f;
		}

		public void ActivateSprite(SpriteBatch pSpriteBatch)
		{
			Debug.Assert(pSpriteBatch != null);
			pSpriteBatch.Attach(this.pSpriteProxy);
		}

		public void SetCollisionColor(float red, float green, float blue)
		{
			Debug.Assert(this.poColObject != null);
			Debug.Assert(this.poColObject.pColSprite != null);

			this.poColObject.pColSprite.SetColor(red, green, blue);
		}

		public virtual void Remove()
		{
			Debug.WriteLine("REMOVE: {0}", this);

			// Keenan(delete.A)
			// -----------------------------------------------------------------
			// Very difficult at first... if you are messy, you will pay here!
			// Given a game object....
			// -----------------------------------------------------------------

			//if(bMarkForDeath)
			//{
			//	this.pSpriteProxy.pSprite.SwapImage(ImageMan.Find(Image.Name.AlienDead));
			//}

			// Remove from SpriteBatch

			// Find the SpriteNode
			Debug.Assert(this.pSpriteProxy != null);
			SpriteNode pSpriteNode = this.pSpriteProxy.GetSpriteNode();

			// Remove it from the manager
			Debug.Assert(pSpriteNode != null);
			SpriteBatchMan.Remove(pSpriteNode);

			// Remove collision sprite from spriteBatch

			Debug.Assert(this.poColObject != null);
			Debug.Assert(this.poColObject.pColSprite != null);
			pSpriteNode = this.poColObject.pColSprite.GetSpriteNode();

			Debug.Assert(pSpriteNode != null);
			SpriteBatchMan.Remove(pSpriteNode);

			// Remove from GameObjectMan
			GameObjectNodeMan.Remove(this);

			//Add to ghost list for revival later.
			GhostMan.Attach(this);

		}

		public ColObject GetColObject()
		{
			Debug.Assert(this.poColObject != null);
			return this.poColObject;
		}

		protected void BaseUpdateBoundingBox(Component pStart)
		{
			GameObject pNode = (GameObject)pStart;

			// point to ColTotal
			ColRect ColTotal = this.poColObject.poColRect;

			// Get the first child
			pNode = (GameObject)IteratorForwardComposite.GetChild(pNode);

			if (pNode != null)
			{
				// Initialized the union to the first block
				ColTotal.Set(pNode.poColObject.poColRect);

				// loop through sliblings
				while (pNode != null)
				{
					ColTotal.Union(pNode.poColObject.poColRect);

					// go to next sibling
					pNode = (GameObject)IteratorForwardComposite.GetSibling(pNode);
				}

				this.x = this.poColObject.poColRect.x;
				this.y = this.poColObject.poColRect.y;

				  //Debug.WriteLine("x:{0} y:{1} w:{2} h:{3}", ColTotal.x, ColTotal.y, ColTotal.width, ColTotal.height);
			}
			//no children, so we shouldn't have a rect
			else
			{
				poColObject.poColRect.Clear();
			}
		}


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

		public override object GetName()
		{
			return name;
		}

		public override void Dump()
		{
			Debug.WriteLine("");
			Debug.WriteLine("\tGameObject: --------------");
			Debug.WriteLine("\t\t\t       name: {0} ({1})", this.name, this.GetHashCode());

			if (this.pSpriteProxy != null)
			{
				Debug.WriteLine("\t\t   pProxySprite: {0}", this.pSpriteProxy.name);
				if (this.pSpriteProxy.pSprite == null)
				{
					Debug.WriteLine("\t\t    pRealSprite: null");
				}
				else
				{
					Debug.WriteLine("\t\t    pRealSprite: {0}", this.pSpriteProxy.pSprite.GetName());
				}
			}
			else
			{
				Debug.WriteLine("\t\t   pProxySprite: null");
				Debug.WriteLine("\t\t    pRealSprite: null");
			}
			Debug.WriteLine("\t\t\t      (x,y): {0}, {1}", this.x, this.y);

			base.Dump();
		}
		/**********************
		* 
		* Local Variables
		* 
		**********************/

		public GameObject.Name name;
		public Sprite.Name pSpriteName;
		public float x;
		public float y;

		public SpriteProxy pSpriteProxy;
		public ColObject poColObject;

		public bool bMarkForDeath;
		
	}
}
