using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	abstract public class SLink : NodeBase
	{

		/**********************
		* 
		* Constructor
		* 
		**********************/

		protected SLink()
		{
			this.Clear();
		}

		/**********************
		* 
		* Public Methods
		* 
		**********************/

		public void Clear()
		{
			this.pNext = null;
		}

		/**********************
		* 
		* Overrides
		* 
		**********************/

		public override void Dump()
		{
			if (this.pNext == null)
			{
				Debug.WriteLine("      next: null");
			}
			else
			{
				NodeBase pTmp = (NodeBase)this.pNext;
				Debug.WriteLine("      next: {0} ({1})", pTmp.GetName(), pTmp.GetHashCode());
			}
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/

		public SLink pNext;
	}
}
