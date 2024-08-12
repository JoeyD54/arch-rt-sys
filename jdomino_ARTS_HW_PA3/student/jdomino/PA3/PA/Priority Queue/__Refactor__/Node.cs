//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

// -----------------------------------------------
// Add CODE/REFACTOR here
// -----------------------------------------------
//    Fill in methods
//    Add additional methods if desired
//    Add additional data if desired
// -----------------------------------------------

namespace PA
{
    public class Node : DLink
    {
        public Node(int _key, string _name) : base()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------

            key = _key;
            name = _name;
        }

        public Node GetNext()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
         
            return (Node)base.pNext;
        }
        public Node GetPrev()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------

            return (Node)base.pPrev;
        }

        // ----------------------------------------------------------
        // Public for Unit Testing purposes
        // ----------------------------------------------------------
        public int key;
        public string name;
    }
}

// --- End of File ---
