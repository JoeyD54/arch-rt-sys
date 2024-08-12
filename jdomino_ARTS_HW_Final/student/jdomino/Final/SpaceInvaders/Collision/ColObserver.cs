using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	abstract public class ColObserver : SLink
	{
		public abstract void Notify();

		public virtual void Execute()
		{

		}

		public override void Wash()
		{
			Debug.Assert(false);
		}

		public ColSubject pSubject;
	}
}
