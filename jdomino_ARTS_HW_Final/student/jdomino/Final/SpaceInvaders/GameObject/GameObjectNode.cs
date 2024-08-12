using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class GameObjectNode : DLink
	{
		/**********************
		* 
		* Constructor
		* 
		**********************/

		public GameObjectNode()
			:base()
		{
			privClear();
		}

		/**********************
		* 
		* Public Methods
		* 
		**********************/

		public void Set(GameObject _pGameObject)
		{
			Debug.Assert(_pGameObject != null);
			pGameObject = _pGameObject;

		}

		/**********************
		* 
		* Private Methods
		* 
		**********************/

		private void privClear()
		{
			pGameObject = null;
		}

		/**********************
		* 
		* Override Methods
		* 
		**********************/

		override public object GetName()
		{
			Debug.Assert(pGameObject != null);

			return pGameObject.name;
		}

		override public void Wash()
		{
			privClear();
		}

		override public bool Compare(NodeBase pTargetNode)
		{
			Debug.Assert(pTargetNode != null);

			GameObjectNode pData = (GameObjectNode)pTargetNode;

			bool status = false;

			if(pData.pGameObject.name == this.pGameObject.name)
			{
				status = true;
			}

			return status;
		}

		override public void Dump()
		{
			// we are using HASH code as its unique identifier 
			Debug.WriteLine("   GameObjectNode: ({0})", this.GetHashCode());

			// Data:
			if (this.pGameObject != null)
			{
				Debug.WriteLine("      GameObject.name: {0} ({1})", this.pGameObject.GetName(), this.pGameObject.GetHashCode());
			}
			else
			{
				Debug.WriteLine("      GameObject.name: null");
			}

			base.Dump();
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/

		public GameObject pGameObject = null;
	}
}
