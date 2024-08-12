using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class RemoveUFOObserver : ColObserver
	{
		public RemoveUFOObserver()
		{
			pUFOGrid = null;
		}

		public RemoveUFOObserver(RemoveUFOObserver m)
		{
			pUFOGrid = m.pUFOGrid;
		}

		public override void Notify()
		{
			Debug.WriteLine("Alien_Observer: {0} {1}", this.pSubject.pGameObjA, this.pSubject.pGameObjB);

			pUFOGrid = pSubject.pGameObjB;


			if (pUFOGrid.bMarkForDeath == false)
			{
				pUFOGrid.bMarkForDeath = true;

				GameObject pColumn = (GameObject)IteratorForwardComposite.GetChild(pUFOGrid);
				pColumn.bMarkForDeath = true;
				
				//   Delay
				RemoveUFOObserver pObserver = new RemoveUFOObserver(this);
				DelayedObjectMan.Attach(pObserver);
			}


		}

		public override void Execute()
		{
			AlienColumn pAColumn = (AlienColumn)IteratorForwardComposite.GetChild(pUFOGrid);
			AlienUFO pAlienUFO = (AlienUFO)IteratorForwardComposite.GetChild(pAColumn);

			TimerEventMan.Remove(TimerEventMan.Find(TimerEvent.Name.UFOMoveCommand));

			pAlienUFO.Remove();
			pAColumn.Remove();

		}

		GameObject pUFOGrid;
	}
}
