//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public abstract class Visitor 
    {
        // -----------------------------------------------------------
        // Add CODE/REFACTOR here - add Visitor contracts here
        // -----------------------------------------------------------
        //      Remember to add the mailbox registration in method
        //          MailBox_StandardVisitor.Register(...);
        // -----------------------------------------------------------
        abstract public void Visit(ElementCar pElement);
        abstract public void Visit(ElementPlane pElement);
        abstract public void Visit(ElementTruck pElement);
    }
}

// --- End of File ---

