
namespace ConceptMatrix
{
	using System;
	using System.Collections.Generic;
	using System.Resources;

	public static class Strings
	{
		private static Dictionary<Type, ResourceManager> managers = new Dictionary<Type, ResourceManager>();

		public static string GetString<T>(string key)
		{
			Type type = typeof(T);
			if (!managers.ContainsKey(type))
				managers.Add(type, new ResourceManager(type));

			string value = managers[type].GetString(key);

			if (string.IsNullOrEmpty(value))
			{
				Console.WriteLine("Missing string: \"" + key + "\" in resources: \"" + managers[type].BaseName + "\"");
				return "[Missing] " + key;
			}

			return value;
		}
	}
}
