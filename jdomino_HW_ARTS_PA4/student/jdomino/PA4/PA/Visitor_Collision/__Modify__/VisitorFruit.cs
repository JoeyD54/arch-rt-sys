//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    abstract public class VisitorFruit : ElementFruit
    {
        // -----------------------------------------------------------
        // Add CODE/REFACTOR here - add Visitor contracts here
        // -----------------------------------------------------------
        //      Remember to add the mailbox registration in method
        //          MailBox_CollisionVisitor.Register(...);
        // -----------------------------------------------------------
        public abstract void Visit(Orange pElement);
        public abstract void Visit(Banana pElement);
        public abstract void Visit(Apple pElement);
    }
}

// --- End of File ---

