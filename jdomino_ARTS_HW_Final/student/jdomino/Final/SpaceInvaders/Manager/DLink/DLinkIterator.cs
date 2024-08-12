using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class DLinkIterator : Iterator
    {
        public DLinkIterator()
            : base()
        {
            this.pCurr = null;
            this.bDone = true;
        }
        override public NodeBase Next()
        {
            DLink pLink = (DLink)this.pCurr;

            if (pLink != null)
            {
                pLink = pLink.pNext;
            }

            this.pCurr = pLink;

            if (pLink == null)
            {
                bDone = true;
            }
            else
            {
                bDone = false;
            }

            return pLink;
        }
        override public bool IsDone()
        {
            return bDone;
        }
        override public NodeBase First()
        {
            NodeBase pNode = this.pCurr;
            return pNode;
        }

        public void Reset(DLink pHead)
        {
            if (pHead != null)
            {
                this.bDone = false;
                this.pCurr = pHead;
            }
            else
            {
                this.bDone = true;
                this.pCurr = null;
            }
        }

        public override NodeBase Curr()
        {
            NodeBase pNode = pCurr;
            return pNode;
        }

        public NodeBase pCurr;
        public bool bDone;
    }
}
