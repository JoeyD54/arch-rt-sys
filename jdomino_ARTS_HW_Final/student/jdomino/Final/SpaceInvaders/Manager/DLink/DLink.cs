using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class DLink : NodeBase
    {

        protected DLink()
        {
            this.Clear();
        }
        public void Clear()
        {
            this.pNext = null;
            this.pPrev = null;
        }

        override public void Dump()
        {
            if (this.pPrev == null)
            {
                Debug.WriteLine("      prev: null");
            }
            else
            {
                NodeBase pTmp = (NodeBase)this.pPrev;
                Debug.WriteLine("      prev: {0} ({1})", pTmp.GetName(), pTmp.GetHashCode());
            }

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

        // Data: -----------------------------
        public DLink pNext;
        public DLink pPrev;

    }
}