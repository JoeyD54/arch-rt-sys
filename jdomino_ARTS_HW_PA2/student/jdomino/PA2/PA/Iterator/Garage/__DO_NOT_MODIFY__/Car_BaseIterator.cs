//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    abstract public class Car_BaseIterator
    {
        // -------------------------------------------------------------------
        // Next() - Advances the iterator to the next item after current item
        //          If valide returns the next item
        //          If the item is not valid, return null
        //          This function advances the iterator
        // -------------------------------------------------------------------
        abstract public Car Next();

        // -------------------------------------------------------------------
        // IsDone() - Return status
        //            Is there additional elements after the current item?
        //            Does not advance the iterator
        // -------------------------------------------------------------------
        abstract public bool IsDone();

        // -------------------------------------------------------------------
        // First() - Returns the first element
        //           Does not advance the iterator
        // -------------------------------------------------------------------
        abstract public Car First();

        // -------------------------------------------------------------------
        // Current() - Returns the current item the iterator is pointing to
        //             Does not advance the iterator
        // -------------------------------------------------------------------
        abstract public Car Current();
    }
}

// --- End of File ---

