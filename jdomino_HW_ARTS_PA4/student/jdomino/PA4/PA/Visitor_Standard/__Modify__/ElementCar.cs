﻿//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class ElementCar : Element
    {
		// -------------------------------
		// Add CODE/REFACTOR here
		// -------------------------------
		public override void Accept(Visitor other)
		{
			other.Visit(this);
		}
	}
}

// --- End of File ---

