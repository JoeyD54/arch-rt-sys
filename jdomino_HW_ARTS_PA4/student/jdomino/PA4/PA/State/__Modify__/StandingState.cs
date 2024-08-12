//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class StandingState : State
    {
		// -----------------------------------------------------------
		// Add CODE/REFACTOR here
		// -----------------------------------------------------------
		//      Remember to add the mailbox registration in method
		//          MailBox_StateMethod.Register(...);
		//          MailBox_StateTransition.Register(...);
		// -----------------------------------------------------------
		public StandingState()
			:base(State.Name.StandingState)
		{

		}

		public override void Sit()
		{
			MailBox_StateMethod.Register(MailBox_StateMethod.Status.STANDING_SIT);
			MailBox_StateTransition.Register(MailBox_StateTransition.Status.STANDING_TRANSITION_TO_SITTING);
			base.pContext.SetState(State.Name.SittingState);
		}

		public override void Stand()
		{
			MailBox_StateMethod.Register(MailBox_StateMethod.Status.STANDING_STAND);
			MailBox_StateTransition.Register(MailBox_StateTransition.Status.STANDING_NO_TRANSITION);
		}

		public override void Stop()
		{
			MailBox_StateMethod.Register(MailBox_StateMethod.Status.STANDING_STOP);
			MailBox_StateTransition.Register(MailBox_StateTransition.Status.STANDING_NO_TRANSITION);
		}
		public override void Walk()
		{
			MailBox_StateMethod.Register(MailBox_StateMethod.Status.STANDING_WALK);
			MailBox_StateTransition.Register(MailBox_StateTransition.Status.STANDING_TRANSITION_TO_WALKING);
			base.pContext.SetState(State.Name.WalkingState);
		}
	}
}

// --- End of File ---
