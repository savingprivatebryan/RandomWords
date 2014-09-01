using System;
using System.Collections.Generic;
using System.Text;

using KeePass.Plugins;
using System.Security.Cryptography;

namespace RandomWords
{
	public sealed class RandomWordsExt : Plugin
	{
		IPluginHost host;
		RandomWordsPwGenerator generator;
		
		public override bool Initialize(IPluginHost host)
		{
			if (host == null) 
				return false;
			this.host = host;

			generator = new RandomWordsPwGenerator();
			host.PwGeneratorPool.Add(generator);

			return true;
		}

		public override void Terminate()
		{
			if (host != null)
			{
				host.PwGeneratorPool.Remove(generator.Uuid);
				generator = null;
				host = null;
			}

			base.Terminate();
		}
	}
}
