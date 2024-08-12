using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class AlienOctopus : AlienCategory
	{
		public AlienOctopus(Sprite.Name spriteName, float posX, float posY)
		: base(GameObject.Name.OctopusAlien, spriteName, posX, posY)
		{

		}

		public void Resurrect(float posX, float posY)
		{
			this.x = posX;
			this.y = posY;

			base.Resurrect();

			this.SetCollisionColor(1.0f, 1.0f, 1.0f);
		}


		public override void Accept(ColVisitor other)
		{
			//Call Octopus collision
			other.VisitOctopus(this);
		}

		public override void VisitMissileGroup(MissileGroup m)
		{
			// Bird vs MissileGroup
			Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

			// Missile vs Bird
			GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
			ColPair.Collide(pGameObj, this);
		}

		public override void VisitMissile(Missile m)
		{
			// Octopus vs Missile
			Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

			// Missile vs Octopus
			Debug.WriteLine("-------> Done  <--------");
			ColPair pColPair = ColPairMan.GetActiveColPair();
			pColPair.SetCollision(m, this);
			pColPair.NotifyListeners();
		}

		override public void Update()
		{
			base.Update();
		}
	}
}
