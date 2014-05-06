using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatUIWPF
{
	public sealed class FlatInformation
	{
		private static FlatInformation _instance = null;

		public static FlatInformation Instance { get { return _instance ?? (_instance = new FlatInformation()); } }

		public Dictionary<AwesomeIcon, string> CollectionIcon
		{
			get { return FlatManager.GetIcon(); }
		}

		private FlatInformation() { }


	}
}
