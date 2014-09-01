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
		int numberOfWordsInPassword;
		string wordDelimiter;
		bool capitalizeWords;

		public RandomWordsPwGenerator()
		{
			//TODO: implement keepass options
			var assembly = Assembly.GetExecutingAssembly();
			var reader = new StreamReader(assembly.GetManifestResourceStream("RandomWords.3eslmod.txt"));
			words = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
			numberOfWordsInPassword = 4;
			wordDelimiter = "";
			capitalizeWords = false;
		}
		
		public override ProtectedString Generate(PwProfile prf, CryptoRandomStream crsRandomSource)
		{
			if (prf == null) { Debug.Assert(false); }
			else
			{
				Debug.Assert(prf.CustomAlgorithmUuid == Convert.ToBase64String(
					uuid.UuidBytes, Base64FormattingOptions.None));
			}

			//TODO: get a simple strength value based on how many words are in the dictionary
			//double strength = Math.Log(words.Length, 2);

			string[] selectedWords = new string[numberOfWordsInPassword];

			for (int i = 0; i < numberOfWordsInPassword; i++)
			{

				//TODO: optimize random word selection and prevent same word from being selected more than once
				ulong randomNum;
				do
				{
					randomNum = crsRandomSource.GetRandomUInt64();
				} while (randomNum >= ulong.MaxValue - (ulong.MaxValue % (ulong)words.Length));

				int pick = (int)(randomNum % (ulong)words.Length);

				if (capitalizeWords)
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

			string output = string.Join(wordDelimiter, selectedWords);

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
	}
}
