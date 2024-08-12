using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
	class SpriteProxyNull : SpriteProxy
	{
		public SpriteProxyNull()
			:base(SpriteProxy.Name.Null_Object)
		{

		}


		//Do nothing at all. We're empty
		public override void Render()
		{
			
		}

		public override void Update()
		{

		}

	}
}
