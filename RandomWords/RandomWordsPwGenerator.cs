using System;
using System.Collections.Generic;
using System.Text;

using KeePass.Plugins;
using System.Security.Cryptography;
using KeePassLib.Cryptography.PasswordGenerator;
using KeePassLib.Security;
using KeePassLib;
using KeePassLib.Cryptography;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace RandomWords
{
	public class RandomWordsPwGenerator : CustomPwGenerator
	{
		string[] words;

		public RandomWordsOptions RandomWordsOptions { get; set; }

		public RandomWordsPwGenerator()
		{
			//TODO: allow custom words, move to GetOptions
			var assembly = Assembly.GetExecutingAssembly();
			var reader = new StreamReader(assembly.GetManifestResourceStream("RandomWords.3eslmod.txt"));
			words = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
		}
		
		public override ProtectedString Generate(PwProfile prf, CryptoRandomStream crsRandomSource)
		{
			if (prf == null) { Debug.Assert(false); }
			else
			{
				Debug.Assert(prf.CustomAlgorithmUuid == Convert.ToBase64String(
					uuid.UuidBytes, Base64FormattingOptions.None));
			}

			//get options if not already done
			if (RandomWordsOptions == null)
			{
				RandomWordsOptions = RandomWordsOptions.WithDefaultOptions();
			}

			//TODO: get a simple strength value based on how many words are in the dictionary
			//double strength = Math.Log(words.Length, 2);

			string[] selectedWords = new string[RandomWordsOptions.NumberOfWordsInPassword];

			for (int i = 0; i < RandomWordsOptions.NumberOfWordsInPassword; i++)
			{

				//TODO: optimize random word selection and prevent same word from being selected more than once
				ulong randomNum;
				do
				{
					randomNum = crsRandomSource.GetRandomUInt64();
				} while (randomNum >= ulong.MaxValue - (ulong.MaxValue % (ulong)words.Length));

				int pick = (int)(randomNum % (ulong)words.Length);

				if (RandomWordsOptions.CapitalizationMode == CapitalizationMode.TitleCase)
				{
					var chars = words[pick].ToCharArray();
					chars[0] = char.ToUpper(chars[0]);
					selectedWords[i] = new string(chars);
				}
				else
				{
					selectedWords[i] = words[pick];
				}
			}

			string output = string.Join(RandomWordsOptions.WordDelimiter, selectedWords);

			return new ProtectedString(false, output);
		}

		public override string Name
		{
			get 
			{
				return "Random Words";
			}
		}
			
		static PwUuid uuid = new PwUuid(new byte[] {
			0xE8, 0x86, 0x1C, 0xD5, 0xED, 0xFD, 0x40, 0x45, 0x8F, 0x14, 0x43, 0x6F, 0xD2, 0x84, 0x1A, 0xFF
		});
		public override PwUuid Uuid
		{

			get { return uuid; }
		}

		public override bool SupportsOptions
		{
			get
			{
				return true;
			}
		}

		public override string GetOptions(string options)
		{
			RandomWordsOptions = RandomWordsOptions.FromOptionsString(options);

			using (var form = new RandomWordsOptionsForm())
			{
				RandomWordsOptions = form.DoOptions(RandomWordsOptions);
			}

			return RandomWordsOptions.ToOptionsString();
		}
	}
}
