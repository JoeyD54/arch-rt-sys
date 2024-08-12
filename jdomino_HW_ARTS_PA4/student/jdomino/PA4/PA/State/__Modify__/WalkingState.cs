//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class WalkingState : State
    {
		// -----------------------------------------------------------
		// Add CODE/REFACTOR here
		// -----------------------------------------------------------
		//      Remember to add the mailbox registration in method
		//          MailBox_StateMethod.Register(...);
		//          MailBox_StateTransition.Register(...);
		// -----------------------------------------------------------
		public WalkingState()
			:base(State.Name.WalkingState)
		{

		}

		public override void Sit()
		{
			MailBox_StateMethod.Register(MailBox_StateMethod.Status.WALKING_SIT);
			MailBox_StateTransition.Register(MailBox_StateTransition.Status.WALKING_NO_TRANSITION);
		}

		public override void Stand()
		{
			MailBox_StateMethod.Register(MailBox_StateMethod.Status.WALKING_STAND);
			MailBox_StateTransition.Register(MailBox_StateTransition.Status.WALKING_NO_TRANSITION);
		}

		public override void Stop()
		{
			MailBox_StateMethod.Register(MailBox_StateMethod.Status.WALKING_STOP);
			MailBox_StateTransition.Register(MailBox_StateTransition.Status.WALKING_TRANSITION_TO_STANDING);
			base.pContext.SetState(State.Name.StandingState);
		}
		public override void Walk()
		{
			MailBox_StateMethod.Register(MailBox_StateMethod.Status.WALKING_WALK);
			MailBox_StateTransition.Register(MailBox_StateTransition.Status.WALKING_NO_TRANSITION);
		}
	}
}

// --- End of File ---
