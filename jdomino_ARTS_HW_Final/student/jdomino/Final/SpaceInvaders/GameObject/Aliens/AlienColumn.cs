using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class AlienColumn : Composite
	{

		/**********************
		* 
		* Constructor
		* 
		**********************/

		public AlienColumn()
			: base()
		{
			name = Name.AlienColumn;

			poColObject.pColSprite.SetColor(0, 0, 1);
		}


		/**********************
		* 
		* Overrides
		* 
		**********************/

		public override void Update()
		{
			base.BaseUpdateBoundingBox(this);
			base.Update();
		}

		public override void Resurrect()
		{
			base.Resurrect();

			this.SetCollisionColor(0.0f, 1.0f, 0.0f);
		}


		public override void Print()
		{
			Debug.WriteLine("");
			Debug.WriteLine("Column");

			Iterator pIterator = this.poDLinkMan.GetIterator();
			Debug.Assert(pIterator != null);

			GameObject pNode = (GameObject)pIterator.First();

			while (!pIterator.IsDone())
			{
				Debug.Assert(pNode != null);

				pNode.Dump();

				pNode = (GameObject)pIterator.Next();
			}
		}

		public override void Accept(ColVisitor other)
		{
			//Column Collision
			other.VisitColumn(this);
		}

		public override void VisitMissileGroup(MissileGroup m)
		{
			// AlienColumn vs MissileGroup
			Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

			// MissileGroup vs Columns
			GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
			//Add something here to remove the col on empty (mark for death?)
			ColPair.Collide(m, pGameObj);
		}

		public override void VisitShieldColumn(ShieldColumn s)
		{
			// AlienColumn vs ShieldColumn
			Debug.WriteLine("         collide:  {0} <-> {1}", s.name, this.name);

			// MissileGroup vs Columns
			GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(s);
			//Add something here to remove the col on empty (mark for death?)
			ColPair.Collide(pGameObj, this);
		}

		//LTN - AlienColumn
		private static SpriteProxyNull psSpriteProxyNull = new SpriteProxyNull();
	}
}
