using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class AlienSquid : AlienCategory
	{
		public AlienSquid(Sprite.Name spriteName, float posX, float posY)
	: base(GameObject.Name.SquidAlien, spriteName, posX, posY)
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
			//Call squid collision
			other.VisitSquid(this);
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
			// Squid vs Missile
			Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

			// Missile vs Squid
			Debug.WriteLine("-------> Done  <--------");
			ColPair pColPair = ColPairMan.GetActiveColPair();
			pColPair.SetCollision(m, this);
			pColPair.NotifyListeners();
		}

		public override void VisitShieldRoot(ShieldRoot s)
		{
			GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(s);
			ColPair.Collide(pGameObj, this);
		}
		public override void VisitShieldBrick(ShieldBrick s)
		{
			// Squid vs Shield
			Debug.WriteLine("         collide:  {0} <-> {1}", s.name, this.name);

			// Missile vs Squid
			Debug.WriteLine("-------> Done  <--------");
			ColPair pColPair = ColPairMan.GetActiveColPair();
			pColPair.SetCollision(s, this);
			pColPair.NotifyListeners();
		}

		override public void Update()
		{
			base.Update();
		}
	}
}
