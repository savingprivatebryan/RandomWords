using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RandomWords
{
	public enum CapitalizationMode
	{
		/// <summary>
		/// All words lower case
		/// </summary>
		[Description("Lower Case")]
		LowerCase = 1,
		/// <summary>
		/// First letter of each word is capitalized
		/// </summary>
		[Description("Title Case")]
		TitleCase = 2
	}

}
