
using System;

namespace Populator
{
	public class DtoSpawn : Attribute
	{
		public DtoSpawn(string name)
		{
			Name = name;
		}

		public static string Name { get; private set; }
	}
}
