using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class ImageNode : SLink
	{

		/**********************
		* 
		* Constructor
		* 
		**********************/

		public ImageNode(Image _pImage)
			:base()
		{
			Debug.Assert(_pImage != null);

			pImage = _pImage;
		}

		/**********************
		* 
		* Private Methods
		* 
		**********************/

		private void privClear()
		{
			pImage = null;
		}

		/**********************
		* 
		* Overrides
		* 
		**********************/

		public override void Wash()
		{
			privClear();
		}

		public override void Dump()
		{
			// we are using HASH code as its unique identifier 
			Debug.WriteLine("   ({0}) node", this.GetHashCode());

			// Data:
			Debug.WriteLine("   pImage: {0} ({1})", this.pImage.GetName(), this.pImage.GetHashCode());

			base.Dump();
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/

		public Image pImage;
	}
}
