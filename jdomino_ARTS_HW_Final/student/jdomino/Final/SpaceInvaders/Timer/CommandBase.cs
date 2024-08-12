using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	abstract public class CommandBase
	{
		//Everything Command controls must do this
		abstract public void Execute(float deltaTime);
	}
}
