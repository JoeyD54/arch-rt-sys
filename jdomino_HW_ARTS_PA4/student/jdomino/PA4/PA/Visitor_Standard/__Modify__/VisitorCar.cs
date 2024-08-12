//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class VisitorCar :Visitor
    {
		// -----------------------------------------------------------
		// Add CODE/REFACTOR here
		// -----------------------------------------------------------
		//      Remember to add the mailbox registration in method
		//          MailBox_StandardVisitor.Register(...);
		// -----------------------------------------------------------
		public override void Visit(ElementCar pElement)
		{
			MailBox_StandardVisitor.Register(MailBox_StandardVisitor.Status.CAR_VISIT_CAR);
		}

		public override void Visit(ElementPlane pElement)
		{
			MailBox_StandardVisitor.Register(MailBox_StandardVisitor.Status.CAR_VISIT_PLANE);
		}

		public override void Visit(ElementTruck pElement)
		{
			MailBox_StandardVisitor.Register(MailBox_StandardVisitor.Status.CAR_VISIT_TRUCK);
		}
	}
}

// --- End of File ---

