//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class DLink
    {
        public DLink pNext;
        public DLink pPrev;

        public DLink()
        {
            this.pNext = null;
            this.pPrev = null;
        }
    }
}

// --- End of File ---
