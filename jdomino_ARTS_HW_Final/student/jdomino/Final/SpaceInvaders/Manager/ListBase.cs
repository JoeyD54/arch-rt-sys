using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public abstract class ListBase
	{
		abstract public void AddToFront(NodeBase pNode);
		abstract public void AddToEnd(NodeBase pNode);
		abstract public void AddByPriority(NodeBase pNode, int priority);
		abstract public void AddByTimeToTrig(NodeBase pNode, float timeToTrigger);
		abstract public void Remove(NodeBase pNode);
		abstract public NodeBase RemoveFromFront();

		abstract public Iterator GetIterator();
	}
}
