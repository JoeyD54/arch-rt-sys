using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public abstract class NodeBase
	{
		public abstract void Wash();
		public abstract void Dump();

		virtual public object GetName()
		{
			return null;
		}

		virtual public bool Compare(NodeBase pTargetNode)
		{
			//Not Implemented (should pass to derived classes)
			Debug.Assert(false);
			return false;
		}
    }
}
