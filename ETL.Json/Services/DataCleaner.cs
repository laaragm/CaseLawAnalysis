using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ETL.Json.Services
{
	public static class DataCleaner
	{
		private static IList<(string toReplace, string replacement)> Replacements = new List<(string toReplace, string replacement)>
		{
			(@"\s\s+", " "),
			(@"'", ""),
			(@"_", " ")
		};

		public static string Clean(this string text)
		{
			foreach (var (toReplace, replacement) in Replacements)
				text = Regex.Replace(text, toReplace, replacement);

			return text;
		}
	}
}
