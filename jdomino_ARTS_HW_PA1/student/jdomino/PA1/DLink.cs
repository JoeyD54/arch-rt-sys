using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Sample
{
	public abstract class DLink
	{
		public DLink()
		{
			pNext = null;
			pPrev = null;
		}

		/****************
		 * 
		 * Class variables
		 * 
		 ***************/

		public DLink pNext;
		public DLink pPrev;
	}
}
