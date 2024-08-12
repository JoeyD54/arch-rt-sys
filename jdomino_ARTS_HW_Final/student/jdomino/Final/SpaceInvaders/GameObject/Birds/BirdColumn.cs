using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class BirdColumn : Composite
	{
		public BirdColumn()
			: base(GameObject.Name.BirdColumn, psSpriteProxyNull)
		{

		}

		public override void Print()
		{
			Debug.WriteLine("");
			Debug.WriteLine("Column");

			Iterator pIterator = this.poDLinkMan.GetIterator();
			Debug.Assert(pIterator != null);

			GameObject pNode = (GameObject)pIterator.First();

			while(!pIterator.IsDone())
			{
				Debug.Assert(pNode != null);

				pNode.Dump();

				pNode = (GameObject)pIterator.Next();
			}
		}

		//LTN - BirdColumn
		private static SpriteProxyNull psSpriteProxyNull = new SpriteProxyNull();
	}
}
