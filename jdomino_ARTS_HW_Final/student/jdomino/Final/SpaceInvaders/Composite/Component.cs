using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	abstract public class Component : ColVisitor
	{
		/**********************
		* 
		* Constructor and Enum
		* 
		**********************/

		public enum Container
		{
			Leaf,
			Composite,
			NotSet
		}

		public Component(Component.Container _ContainerType)
		{
			containerType = _ContainerType;
			pParent = null;
			pReverse = null;
		}

		public virtual void Resurrect()
		{
			this.pParent = null;
			this.pReverse = null;
		}

		/**********************
		* 
		* Abstract Methods
		* 
		**********************/

		public abstract void Print();
		//public abstract void Move(float x, float y);
		public abstract void Add(Component c);
		public abstract void Remove(Component c);
		public abstract void DumpNode();

		public virtual int GetNumChildren()
		{
			return 0;
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/

		public Container containerType;
		public Component pParent;
		public Component pReverse;
	}
}
