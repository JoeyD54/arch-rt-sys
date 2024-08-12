using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class UFOGrid : Composite
	{
		public UFOGrid()
			: base()
		{
			name = Name.UFOGrid;
			delta = 2f;
			poColObject.pColSprite.SetColor(1, 1, 1);
		}

		public override void Accept(ColVisitor other)
		{
			// Important: at this point we have a UFOGrid
			// Call the appropriate collision reaction    
			other.VisitUFOGrid(this);
		}

		public override void VisitWallGroup(WallGroup w)
		{
			//UFOGrid vs wallgroup
			//Figure out which wall we hit to decide direction

			//Debug.WriteLine("         collide:  {0} <-> {1}", w.name, this.name);
			GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(w);
			ColPair.Collide(this, pGameObj);
		}

		public override void VisitMissileGroup(MissileGroup m)
		{
			// AlienGrid vs MissileGroup
			Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

			// MissileGroup vs Columns
			GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
			ColPair.Collide(m, pGameObj);
		}


		public override void Update()
		{
			//Debug.WriteLine("update: {0}", this);
			base.BaseUpdateBoundingBox(this);

			//We need to remove the buffer space each time a column is killed off
			//Totaly space between all columns
			//float maxSpaceBetween = 33.0f;

			//int count = this.GetNumChildren();

			// proof its working
			//this.poColObject.poColRect.width -= maxSpaceBetween;

			base.Update();
		}

		public void MoveGrid()
		{

			IteratorForwardComposite pFor = new IteratorForwardComposite(this);

			Component pNode = pFor.First();
			while (!pFor.IsDone())
			{
				GameObject pGameObj = (GameObject)pNode;
				pGameObj.x += delta;
				//pGameObj.y += this.y;

				pNode = pFor.Next();
			}
		}

		private float delta;
	}
}
