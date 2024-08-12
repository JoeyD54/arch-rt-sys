//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Apple : VisitorFruit
    {
		// -----------------------------------------------------------
		// Add CODE/REFACTOR here
		// -----------------------------------------------------------
		//      Remember to add the mailbox registration in method
		//          MailBox_CollisionVisitor.Register(...);
		// -----------------------------------------------------------
		public override void Accept(VisitorFruit other)
		{
			other.Visit(this);
		}

		public override void Visit(Apple pElement)
		{
			MailBox_CollisionVisitor.Register(MailBox_CollisionVisitor.Status.APPLE_VISIT_APPLE);
		}

		public override void Visit(Banana pElement)
		{
			MailBox_CollisionVisitor.Register(MailBox_CollisionVisitor.Status.APPLE_VISIT_BANANA);
		}

		public override void Visit(Orange pElement)
		{
			MailBox_CollisionVisitor.Register(MailBox_CollisionVisitor.Status.APPLE_VISIT_ORANGE);
		}
	}
}

// --- End of File ---

