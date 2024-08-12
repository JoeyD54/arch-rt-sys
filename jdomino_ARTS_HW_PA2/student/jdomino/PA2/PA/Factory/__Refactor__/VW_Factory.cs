//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Volkswagen_Factory : Factory_Base
    {
        public override Vehicle Create(Vehicle.Model _m, Vehicle.Color _c)
        {

            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if(_m == Vehicle.Model.Atlas)
			{
                return new Atlas(Vehicle.Doors.Four, _c, Vehicle.Engine.Petrol);
			}
            else if(_m == Vehicle.Model.Golf)
			{
                return new Golf(Vehicle.Doors.Two, _c, Vehicle.Engine.Petrol);
            }
            else if (_m == Vehicle.Model.Jetta)
            {
                return new Jetta(Vehicle.Doors.Four, _c, Vehicle.Engine.Diesel);
            }
            else if (_m == Vehicle.Model.Tiguan)
            {
                return new Tiguan(Vehicle.Doors.Four, _c, Vehicle.Engine.Electric);
            }

            return null;
        }
    }
}

// --- End of File ---
