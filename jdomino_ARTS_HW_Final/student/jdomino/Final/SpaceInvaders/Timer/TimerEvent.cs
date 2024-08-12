using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class TimerEvent : DLink
	{
		/**********************
		* 
		* Constructor and Enum
		* 
		**********************/

		//Used to discern what action we are taking
		//On timer called
		public enum Name
		{
			MoveGrid,
			Animation,
			BombAnimation,
			TimedCharacter,
			BombSpawnEvent,
			UpdateScoreCommand,
			RandomUFOSpawn,
			UFOMoveCommand,
			RemoveExplosionCommand,
			LevelCompleted,
			LoadNextSceneCommand,
			DieCommand,
			JesusMode,
			ResetShip,

			GameOverEvent,


			Unitialized
		}

		public TimerEvent()
			:base()
		{
			name = TimerEvent.Name.Unitialized;
			pCommand = null;
			timeTrigger = 0.0f;
			deltaTime = 0.0f;
		}

		/**********************
		* 
		* Public Methods
		* 
		**********************/

		public void Set(TimerEvent.Name eventName, CommandBase _pCommand, float deltaTimeToTrigger)
		{
			Debug.Assert(_pCommand != null);

			name = eventName;
			pCommand = _pCommand;
			deltaTime = deltaTimeToTrigger;

			timeTrigger = TimerEventMan.GetCurrTime() + deltaTimeToTrigger;
		}

		public void Process()
		{
			Debug.Assert(pCommand != null);

			pCommand.Execute(deltaTime);
		}

		public new void Clear()
		{
			name = TimerEvent.Name.Unitialized;
			pCommand = null;
			timeTrigger = 0.0f;
			deltaTime = 0.0f;
		}

		/**********************
		* 
		* Private Methods
		* 
		**********************/

		/**********************
		* 
		* Overrides
		* 
		**********************/

		public override void Wash()
		{
			base.Clear();
			this.Clear();
		}

		override public void Dump()
		{
			// Dump - Print contents to the debug output window
			//        Using HASH code as its unique identifier 
			Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());

			// Data:
			Debug.WriteLine("      Command: {0}", this.pCommand);
			Debug.WriteLine("   Event Name: {0}", this.name);
			Debug.WriteLine(" Trigger Time: {0}", this.timeTrigger);
			Debug.WriteLine("   Delta Time: {0}", this.deltaTime);

			base.Dump();
		}
		override public bool Compare(NodeBase pTarget)
		{
			// This is used in ManBase.Find() 
			Debug.Assert(pTarget != null);

			TimerEvent pDataB = (TimerEvent)pTarget;

			bool status = false;

			if (this.name == pDataB.name)
			{
				status = true;
			}

			return status;
		}


		/**********************
		* 
		* Local Variables
		* 
		**********************/

		public Name name;
		public CommandBase pCommand;
		public float timeTrigger;
		public float deltaTime;
	}
}
