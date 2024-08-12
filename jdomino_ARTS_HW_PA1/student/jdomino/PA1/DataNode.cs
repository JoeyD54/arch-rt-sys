//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace UnitTest_Sample
{
    public class Node : DLink
    {
        public enum Name
        {
            Cat,
            Dog,
            Bird,
            Fish,
            Rabbit,
            Worm,
            Unitialized
        }

        public Node GetNext()
        {
            return (Node)pNext;
        }
        public Node GetPrev()
        {
            return (Node)pPrev;
        }


        // ---------------------------------------
        // Data:
        //       Required fields...
        //       add more data if you want
        // ---------------------------------------
        public Name name;
        public int x;

        //public Node pNext;
        //public Node pPrev;
    }
}

// --- End of File ---

