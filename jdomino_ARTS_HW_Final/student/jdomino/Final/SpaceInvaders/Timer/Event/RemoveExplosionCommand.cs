using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class RemoveExplosionCommand : CommandBase
	{
		public RemoveExplosionCommand(SpriteProxy _proxy)
		{
			proxyToRemove = _proxy;
		}

		public override void Execute(float deltaTime)
		{
			Debug.Assert(proxyToRemove != null);

			SpriteNode pSpriteNode = proxyToRemove.GetSpriteNode();
			Debug.Assert(pSpriteNode != null);

			SpriteBatchMan.Remove(pSpriteNode);
		}

		SpriteProxy proxyToRemove;
	}
}
