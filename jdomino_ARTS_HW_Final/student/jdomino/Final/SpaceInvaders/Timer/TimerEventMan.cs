using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class TimerEventMan : ManBase
	{
		/**********************
		* 
		* Constructor
		* 
		**********************/

		//LTN - ManBase (the 2 DLinkMan's)
		private TimerEventMan(int reserveNum = 3, int reserveGrow = 1)
			: base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)
		{
			//LTN - TimerEventMan
			poNodeCompare = new TimerEvent();
			mCurrTime = 0.0f;
		}

		/**********************
		* 
		* Public Methods
		* 
		**********************/

		public static void Create(int reserveNum = 3, int reserveGrow = 1)
		{
			Debug.Assert(reserveGrow > 0);
			Debug.Assert(reserveNum > 0);

			Debug.Assert(pInstance == null);

			if(pInstance == null)
			{
				//LTN - TimerEventMan
				pInstance = new TimerEventMan(reserveNum, reserveGrow);
			}
		}

		public static void Destroy()
		{
			TimerEventMan pMan = privGetInstance();
			Debug.Assert(pMan != null);

			// Do something clever here
			// track peak number of active nodes
			// print stats on destroy
			// invalidate the singleton
		}

		public static TimerEvent Add(TimerEvent.Name name, CommandBase pCommand, float deltaTimeToTrigger)
		{
			TimerEventMan pMan = TimerEventMan.privGetInstance();
			Debug.Assert(pMan != null);

			TimerEvent pNode = (TimerEvent)pMan.baseAddByTimeToTrig(deltaTimeToTrigger);
			Debug.Assert(pNode != null);

			Debug.Assert(pCommand != null);
			Debug.Assert(deltaTimeToTrigger >= 0.0f);

			// Initialize the date
			pNode.Set(name, pCommand, deltaTimeToTrigger);
			return pNode;
		}

		public static TimerEvent Find(TimerEvent.Name name)
		{
			TimerEventMan pMan = TimerEventMan.privGetInstance();
			Debug.Assert(pMan != null);

			// Compare functions only compares two Nodes

			// So:  Use the Compare Node - as a reference
			//      use in the Compare() function
			pMan.poNodeCompare.name = name;

			TimerEvent pData = (TimerEvent)pMan.baseFind(pMan.poNodeCompare);
			return pData;
		}


		public static void Remove(TimerEvent pImage)
		{
			Debug.Assert(pImage != null);

			TimerEventMan pMan = TimerEventMan.privGetInstance();
			Debug.Assert(pMan != null);

			pMan.baseRemove(pImage);
		}
		public static void Dump()
		{
			TimerEventMan pMan = TimerEventMan.privGetInstance();
			Debug.Assert(pMan != null);

			pMan.baseDump();
		}

		public static float GetCurrTime()
		{
			TimerEventMan pMan = TimerEventMan.privGetInstance();
			Debug.Assert(pMan != null);

			return pMan.mCurrTime;
		}

		public static void PauseUpdate(float delta)
		{
			// Get the instance
			TimerEventMan pMan = TimerEventMan.privGetInstance();
			Debug.Assert(pMan != null);

			// walk the list
			Iterator pIt = pMan.baseGetIterator();
			Debug.Assert(pIt != null);

			TimerEvent pEvent = (TimerEvent)pIt.First();

			// Update the times
			while (!pIt.IsDone())
			{
				pEvent.timeTrigger += delta;
				pEvent = (TimerEvent)pIt.Next();
			}

		}

		public static void Update(float totalTime)
		{
			TimerEventMan pMan = TimerEventMan.privGetInstance();
			Debug.Assert(pMan != null);

			pMan.mCurrTime = totalTime;

			Iterator pIterator = pMan.baseGetIterator();
			Debug.Assert(pIterator != null);

			TimerEvent pNode = (TimerEvent)pIterator.First();
			TimerEvent pNextNode = null;

			while(!pIterator.IsDone())
			{
				pNextNode = (TimerEvent)pIterator.Next();

				if(pMan.mCurrTime >= pNode.timeTrigger)
				{
					pNode.Process();

					pMan.baseRemove(pNode);
				}

				pNode = pNextNode;
			}
		}


		//Clear all events. This is when switching scenes!

		public static void RemoveAll()
		{
			TimerEventMan pMan = TimerEventMan.privGetInstance();
			Debug.Assert(pMan != null);

			Iterator pIterator = pMan.baseGetIterator();
			Debug.Assert(pIterator != null);

			TimerEvent pNode = (TimerEvent)pIterator.First();
			TimerEvent pNextNode = null;

			while (!pIterator.IsDone())
			{
				pNextNode = (TimerEvent)pIterator.Next();

				pMan.baseRemove(pNode);

				pNode = pNextNode;
			}
		}

		/**********************
		* 
		* Private Methods
		* 
		**********************/

		private static TimerEventMan privGetInstance()
		{
			// Safety - this forces users to call Create() first before using class
			Debug.Assert(pInstance != null);

			return pInstance;
		}

		/**********************
		* 
		* Overrides
		* 
		**********************/

		override protected NodeBase DerivedCreateNode()
		{
			//LTN - TimerEventMan
			NodeBase pNodeBase = new TimerEvent();
			Debug.Assert(pNodeBase != null);

			return pNodeBase;
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/

		private readonly TimerEvent poNodeCompare;
		private static TimerEventMan pInstance = null;
		protected float mCurrTime;
	}
}
