//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

// ----------------------------------
// ---     DO NOT MODIFY FILE     ---
// ----------------------------------

namespace PA
{
    public class Box 
    {
        public enum Name
        {
            Vitamins,
            Coffee,
            Masks,
            Dogfood,
            Parachute,
            BirdSeed,
            Corkscrew,
            Book,
            WineGlass,
            WineCooler,
            OakIslandHat,
            AcientAlienPoster,
            Empty
        }

        public Box() : base()
        {
            this.name = Box.Name.Empty;
            this.x = -1;
        }

        public void Set(Name _n, int _x)
        {
            this.name = _n;
            this.x = _x;
        }

        public void Delivered()
        {
            this.name = Box.Name.Empty;
            this.x = -1;
        }

        public Name name;
        public int x;
    }
}

// --- End of File ---
