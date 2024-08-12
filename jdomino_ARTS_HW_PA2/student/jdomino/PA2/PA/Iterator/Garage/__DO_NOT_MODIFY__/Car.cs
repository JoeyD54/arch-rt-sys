//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Car : DLink
    {
        public enum Name
        {
            Jetta,
            Accord,
            Civic,
            Clio,
            Panda,
            Nexon,
            Kona,
            Unlisted
        }

        public Car(Name _n, int _x) : base()
        {
            this.name = _n;
            this.x = _x;
        }
        

        public Name name;
        public int x;
    }
}
