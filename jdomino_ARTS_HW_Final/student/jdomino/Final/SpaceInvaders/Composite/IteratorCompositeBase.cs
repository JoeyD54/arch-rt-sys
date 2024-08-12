using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
	abstract public class IteratorCompositeBase
	{
		abstract public Component Next();
		abstract public Component First();
		abstract public Component Curr();
		abstract public bool IsDone();
	}
}
