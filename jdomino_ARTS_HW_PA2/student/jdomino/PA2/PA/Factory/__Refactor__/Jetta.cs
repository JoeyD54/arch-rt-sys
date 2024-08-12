﻿//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;

namespace PA
{
    public class Jetta : Vehicle
    {
        // ---------------------------------------------------------------
        // Add specialized constructor it must take Doors, Color, Engine
        // ---------------------------------------------------------------
        public Jetta(Doors _d, Color _c, Engine _e)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            d = _d;
            c = _c;
            e = _e;
            poStyle = new Sedan();
        }

        public override void Drive()
        {
            // Do Not Change Method - unique Drive behavior for this model
        }
        public override void Honk()
        {
            // Do Not Change Method - unique Honk behavior for this model
        }
        public override void Park()
        {
            // Do Not Change Method - unique parking behavior for this model
        }



        // ----------------------------------------------------------
        // Public for Unit Testing purposes
        // ----------------------------------------------------------
        //    pass these enum into constructor
        //    other types use a default constructor to initalize
        // ----------------------------------------------------------
        public Doors d;
        public Color c;
        public Engine e;
        public Sedan poStyle;
    }
}

// --- End of File ---

