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
    public class Leaf : Component
    {
        public Leaf(string _name) : base()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            base.name = _name;
            base.isLeaf = true;
        }

        public override void RemoveLeaf(Component pComponent)
		{
            Debug.Print("We're removing a leaf");
		}
    }


}

// --- End of File ---
