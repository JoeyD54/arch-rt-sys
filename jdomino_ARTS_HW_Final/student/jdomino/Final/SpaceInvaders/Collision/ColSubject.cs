using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class ColSubject
	{

		/**********************
		* 
		* Constructor and Destructor
		* 
		**********************/
		
		public ColSubject()
		{
			pGameObjA = null;
			pGameObjB = null;

			poSLinkMan = new SLinkMan();
			Debug.Assert(poSLinkMan != null);
		}

		~ColSubject()
		{
			pGameObjA = null;
			pGameObjB = null;
		}

		/**********************
		* 
		* Public Methods
		* 
		**********************/
	
		public void Attach(ColObserver pObserver)
		{
			Debug.Assert(pObserver != null);

			pObserver.pSubject = this;

			poSLinkMan.AddToFront(pObserver);
		}

		public void Notify()
		{
			Iterator pIt = poSLinkMan.GetIterator();

			ColObserver pObserver = (ColObserver)pIt.Curr();

			while (!pIt.IsDone())
			{
				// Fire off listener
				pObserver.Notify();

				pObserver = (ColObserver)pIt.Next();
			}
		}

		public void Detach()
		{

		}

		/**********************
		* 
		* Private Methods
		* 
		**********************/

		/**********************
		* 
		* Overrides
		* 
		**********************/

		/**********************
		* 
		* Local Variables
		* 
		**********************/

		public GameObject pGameObjA;
		public GameObject pGameObjB;

		private SLinkMan poSLinkMan;
	}


}
