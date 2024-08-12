//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Imperial_Adapter : Imperial
    {
        private Imperial_Adapter()
            :base()
        {
            // prevent default constructor
        }
        public Imperial_Adapter(MetricMachine _pMetric)
        {
            Debug.Assert(_pMetric != null);

            poMetric = _pMetric;
            Debug.Assert(poMetric != null);
        }

        
        public override void SetWeight(float pounds)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            poMetric.SetWeight(pounds * 0.45359f);
        }
        public override void SetLength(float feet)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            poMetric.SetLength(feet * 0.3048f);
        }
        public override void SetVolume(float gallons)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            poMetric.SetVolume(gallons * 3.78541f);
        }

        public override float GetWeight()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return poMetric.GetWeight() / 0.45359f;
        }
        public override float GetLength()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return poMetric.GetLength() / 0.3048f;
        }
        public override float GetVolume()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return poMetric.GetVolume() / 3.78541f;
        }


        // -------------------------------------------------
        // NO Extra Data - allowed in this class     
        // -------------------------------------------------
        private MetricMachine poMetric;

    }
}

// --- End of File ---

