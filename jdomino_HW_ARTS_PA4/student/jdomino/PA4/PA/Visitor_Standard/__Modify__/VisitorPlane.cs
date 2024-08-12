//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class VisitorPlane : Visitor 
    {
		// -----------------------------------------------------------
		// Add CODE/REFACTOR here
		// -----------------------------------------------------------
		//      Remember to add the mailbox registration in method
		//          MailBox_StandardVisitor.Register(...);
		// -----------------------------------------------------------
		public override void Visit(ElementCar pElement)
		{
			MailBox_StandardVisitor.Register(MailBox_StandardVisitor.Status.CAR_ELEMENT_ERROR);
		}

		public override void Visit(ElementPlane pElement)
		{
			MailBox_StandardVisitor.Register(MailBox_StandardVisitor.Status.PLANE_VISIT_PLANE);
		}

		public override void Visit(ElementTruck pElement)
		{
			MailBox_StandardVisitor.Register(MailBox_StandardVisitor.Status.TRUCK_ELEMENT_ERROR);
		}
	}
}

// --- End of File ---

