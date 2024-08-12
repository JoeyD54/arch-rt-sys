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
    public abstract class Component : SLink
    {
        public Component()
        {
            this.name = "uninitialized";
        }

        public Component GetNext()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------

            return (Component)base.pNext;
        }

        public abstract void RemoveLeaf(Component pComponent);

        // ----------------------------------------------------------
        // Public for Unit Testing purposes
        // ----------------------------------------------------------
        public string name;
        public bool isLeaf;
    }
}

// --- End of File ---
