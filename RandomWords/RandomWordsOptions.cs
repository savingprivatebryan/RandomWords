using System;
using System.Collections.Generic;
using System.Text;

namespace RandomWords
{
	public class RandomWordsOptions
	{
		public int NumberOfWordsInPassword { get; set; }
		public string WordDelimiter { get; set; }
		public CapitalizationMode CapitalizationMode { get; set; }

		public static RandomWordsOptions FromOptionsString(string options)
		{
			if (string.IsNullOrEmpty(options))
			{
				return RandomWordsOptions.WithDefaultOptions();
			}

			var optLines = options.Split(new [] { Environment.NewLine }, StringSplitOptions.None);
			var returnVal = new RandomWordsOptions();
			returnVal.NumberOfWordsInPassword = Convert.ToInt32(optLines[0]);
			returnVal.WordDelimiter = optLines[1];
			returnVal.CapitalizationMode = (CapitalizationMode)Convert.ToInt32(optLines[2]);

			return returnVal;
		}

		public string ToOptionsString()
		{
			return NumberOfWordsInPassword + Environment.NewLine +
				WordDelimiter + Environment.NewLine +
				(int)CapitalizationMode;
		}

		public static RandomWordsOptions WithDefaultOptions()
		{
			return new RandomWordsOptions()
			{
				NumberOfWordsInPassword = 4,
				WordDelimiter = "",
				CapitalizationMode = CapitalizationMode.LowerCase
			};
		}

	}
}
