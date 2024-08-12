using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
	abstract public class Iterator
	{
		abstract public NodeBase Next();
		abstract public bool IsDone();
		abstract public NodeBase First();
		abstract public NodeBase Curr();
	}
}
