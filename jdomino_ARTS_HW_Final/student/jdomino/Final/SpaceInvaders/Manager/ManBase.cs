using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    // Whole class should have NO knowledge of Node
    abstract public class ManBase
    {
        /**********************
		* 
		* Constructor
		* 
		**********************/

        protected ManBase(ListBase _poActive, ListBase _poReserve, int InitialNumReserved = 5, int DeltaGrow = 2)
        {
            // Check now or pay later
            Debug.Assert(_poActive != null);
            Debug.Assert(_poReserve != null);
            Debug.Assert(InitialNumReserved >= 0);
            Debug.Assert(DeltaGrow > 0);

            // Initialize all variables
            this.mDeltaGrow = DeltaGrow;
            this.mNumReserved = 0;
            this.mNumActive = 0;
            this.mTotalNumNodes = 0;
            this.poActive = _poActive;
            this.poReserve = _poReserve;

            // Preload the reserve
            this.privFillReservedPool(InitialNumReserved);
        }

        /**********************
		* 
		* Public Methods - To be used in derived classes
		* 
		**********************/

        protected void baseSetReserve(int reserveNum, int reserveGrow)
        {
            this.mDeltaGrow = reserveGrow;

            if (reserveNum > this.mNumReserved)
            {
                // Preload the reserve
                this.privFillReservedPool(reserveNum - this.mNumReserved);
            }
        }

        public NodeBase baseAddByPriority(int priority)
		{
            Iterator pIt = poReserve.GetIterator();
            Debug.Assert(pIt != null);

            // Are there any nodes on the Reserve list?
            if (pIt.First() == null)
            {
                // refill the reserve list by the DeltaGrow
                this.privFillReservedPool(this.mDeltaGrow);
            }

            // Always take from the reserve list
            NodeBase pNodeBase = poReserve.RemoveFromFront();
            Debug.Assert(pNodeBase != null);

            // Wash it
            pNodeBase.Wash();

            this.mNumActive++;
            this.mNumReserved--;


            // ADD BY PRIORITY NOT TO FRONT
            poActive.AddByPriority(pNodeBase, priority);

            // YES - here's your new one (may its reused from reserved)
            return pNodeBase;
        }

        public NodeBase baseAddByTimeToTrig(float timeToTrigger)
        {
            Iterator pIt = poReserve.GetIterator();
            Debug.Assert(pIt != null);

            // Are there any nodes on the Reserve list?
            if (pIt.First() == null)
            {
                // refill the reserve list by the DeltaGrow
                this.privFillReservedPool(this.mDeltaGrow);
            }

            // Always take from the reserve list
            NodeBase pNodeBase = poReserve.RemoveFromFront();
            Debug.Assert(pNodeBase != null);

            // Wash it
            pNodeBase.Wash();

            this.mNumActive++;
            this.mNumReserved--;


            // ADD BY PRIORITY NOT TO FRONT
            poActive.AddByTimeToTrig(pNodeBase, timeToTrigger);

            // YES - here's your new one (may its reused from reserved)
            return pNodeBase;
        }

        public NodeBase baseAddToFront()
        {
            Iterator pIt = poReserve.GetIterator();
            Debug.Assert(pIt != null);

            // Are there any nodes on the Reserve list?
            if (pIt.First() == null)
            {
                // refill the reserve list by the DeltaGrow
                this.privFillReservedPool(this.mDeltaGrow);
            }

            // Always take from the reserve list
            NodeBase pNodeBase = poReserve.RemoveFromFront();
            Debug.Assert(pNodeBase != null);

            // Wash it
            pNodeBase.Wash();

            // Update stats
            this.mNumActive++;
            this.mNumReserved--;

            // copy to active
            poActive.AddToFront(pNodeBase);

            // YES - here's your new one (may its reused from reserved)
            return pNodeBase;
        }



        public NodeBase baseAddToEnd()
        {
            Iterator pIt = poReserve.GetIterator();
            Debug.Assert(pIt != null);

            // Are there any nodes on the Reserve list?
            if (pIt.First() == null)
            {
                // refill the reserve list by the DeltaGrow
                this.privFillReservedPool(this.mDeltaGrow);
            }

            // Always take from the reserve list
            NodeBase pNodeBase = poReserve.RemoveFromFront();
            Debug.Assert(pNodeBase != null);

            // Wash it
            pNodeBase.Wash();

            // Update stats
            this.mNumActive++;
            this.mNumReserved--;

            // copy to active
            poActive.AddToEnd(pNodeBase);

            // YES - here's your new one (may its reused from reserved)
            return pNodeBase;
        }



        protected Iterator baseGetIterator()
        {
            return poActive.GetIterator();
        }



        protected NodeBase baseFind(NodeBase pNodeTarget)
        {
            // search the active list
            Iterator pIt = poActive.GetIterator();

            NodeBase pNode = pIt.First();

            // Walk through the nodes
            while (!pIt.IsDone())
            {
                if (pNode.Compare(pNodeTarget))
                {
                    // found it
                    break;
                }
                pNode = pIt.Next();
            }

            return pNode;
        }

        public void baseRemove(NodeBase pNodeBase)
        {
            Debug.Assert(pNodeBase != null);

            // Don't do the work here... delegate it
            poActive.Remove(pNodeBase);

            // wash it before returning to reserve list
            pNodeBase.Wash();

            // add it to the return list
            poReserve.AddToFront(pNodeBase);

            // stats update
            this.mNumActive--;
            this.mNumReserved++;
        }



        public void baseDump()
        {
            Debug.WriteLine("   --- " + this.ToString() + " Begin ---\n");

            Debug.WriteLine("         mDeltaGrow: {0} ", mDeltaGrow);
            Debug.WriteLine("     mTotalNumNodes: {0} ", mTotalNumNodes);
            Debug.WriteLine("       mNumReserved: {0} ", mNumReserved);
            Debug.WriteLine("         mNumActive: {0} \n", mNumActive);

            Iterator pItActive = poActive.GetIterator();
            Debug.Assert(pItActive != null);

            NodeBase pNodeActive = pItActive.First();
            if (pNodeActive == null)
            {
                Debug.WriteLine("    Active Head: null");
            }
            else
            {
                Debug.WriteLine("    Active Head: ({0})", pNodeActive.GetHashCode());
            }

            Iterator pItReserve = poReserve.GetIterator();
            Debug.Assert(pItReserve != null);

            NodeBase pNodeReserve = pItReserve.First();
            if (pNodeReserve == null)
            {
                Debug.WriteLine("   Reserve Head: null\n");
            }
            else
            {
                Debug.WriteLine("   Reserve Head: ({0})\n", pNodeReserve.GetHashCode());
            }

            Debug.WriteLine("   ------ Active List: -----------\n");


            int i = 0;
            NodeBase pData = pItActive.First();
            while (!pItActive.IsDone())
            {
                Debug.WriteLine("   {0}: -------------", i);
                pData.Dump();
                i++;
                pData = pItActive.Next();
            }

            Debug.WriteLine("");
            Debug.WriteLine("   ------ Reserve List: ----------\n");

            i = 0;
            pData = pItReserve.First();
            while (!pItReserve.IsDone())
            {
                Debug.WriteLine("   {0}: -------------", i);
                pData.Dump();
                i++;
                pData = pItReserve.Next();
            }

            Debug.WriteLine("   --- " + this.ToString() + " End ---\n");
        }

        /**********************
		* 
		* Abstract Methods
		* 
		**********************/

        abstract protected NodeBase DerivedCreateNode();

        /**********************
		* 
		* Private Methods
		* 
		**********************/

        private void privFillReservedPool(int count)
        {
            // doesn't make sense if its not at least 1
            Debug.Assert(count >= 0);

            this.mTotalNumNodes += count;
            this.mNumReserved += count;

            // Preload the reserve
            for (int i = 0; i < count; i++)
            {
                NodeBase pNode = this.DerivedCreateNode();
                Debug.Assert(pNode != null);

                poReserve.AddToFront(pNode);
            }
        }

        /**********************
		* 
		* Private Methods
		* 
		**********************/



        /**********************
		* 
		* Local Variables
		* 
		**********************/

        private ListBase poActive;
        private ListBase poReserve;
        private int mDeltaGrow;
        private int mTotalNumNodes;
        private int mNumReserved;
        private int mNumActive;

    }
}
