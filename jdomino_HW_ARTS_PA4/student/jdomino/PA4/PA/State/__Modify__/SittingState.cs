//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class SittingState : State
    {
		// -----------------------------------------------------------
		// Add CODE/REFACTOR here
		// -----------------------------------------------------------
		//      Remember to add the mailbox registration in method
		//          MailBox_StateMethod.Register(...);
		//          MailBox_StateTransition.Register(...);
		// -----------------------------------------------------------
		public SittingState()
			:base(State.Name.SittingState)
		{

		}

		public override void Sit()
		{
			MailBox_StateMethod.Register(MailBox_StateMethod.Status.SITTING_SIT);
			MailBox_StateTransition.Register(MailBox_StateTransition.Status.SITTING_NO_TRANSITION);
		}

		public override void Stand()
		{
			MailBox_StateMethod.Register(MailBox_StateMethod.Status.SITTING_STAND);
			MailBox_StateTransition.Register(MailBox_StateTransition.Status.SITTING_TRANSITION_TO_STANDING);
			base.pContext.SetState(State.Name.StandingState);
		}

		public override void Stop()
		{
			MailBox_StateMethod.Register(MailBox_StateMethod.Status.SITTING_STOP);
			MailBox_StateTransition.Register(MailBox_StateTransition.Status.SITTING_NO_TRANSITION);
		}
		public override void Walk()
		{
			MailBox_StateMethod.Register(MailBox_StateMethod.Status.SITTING_WALK);
			MailBox_StateTransition.Register(MailBox_StateTransition.Status.SITTING_NO_TRANSITION);
		}
	}
}

// --- End of File ---
