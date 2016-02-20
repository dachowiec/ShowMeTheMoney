using System;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace ShowMeTheMoney.Tests
{
	public static class ResourceFileLoader
	{
		public static XDocument GetXDocument(string namespacePath, string fileName)
		{
			return XDocument.Parse(GetStringContent(namespacePath, fileName, Assembly.GetCallingAssembly()));
		}

		public static string GetStringContent(string namespacePath, string fileName)
		{
			return GetStringContent(namespacePath, fileName, Assembly.GetCallingAssembly());
		}

		public static Stream GetStream(string namespacePath, string fileName, Assembly assembly)
		{
			var xmlFileResourcePath = string.Format("{0}.{1}", namespacePath, fileName);
			var stream = assembly.GetManifestResourceStream(xmlFileResourcePath);
			if (stream == null)
				throw new ArgumentException("Failed to load resource: " + xmlFileResourcePath);
			return stream;
		}

		public static Stream GetStream(string namespacePath, string fileName)
		{
			return GetStream(namespacePath, fileName, Assembly.GetCallingAssembly());
		}

		public static string GetStringContent(string namespacePath, string fileName, Assembly assembly)
		{
			using (var stream = GetStream(namespacePath, fileName, assembly))
			{
				var streamReader = new StreamReader(stream);
				return streamReader.ReadToEnd();
			}
		}
	}
}