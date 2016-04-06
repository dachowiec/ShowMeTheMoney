using System;

namespace ShowMeTheMoney.Other
{
	public class DuplicateCategoryException : Exception
	{
		public DuplicateCategoryException(params string[] categoryNames)
			: base("Duplicate cateogry names: " + string.Join(", ", categoryNames))
		{
		}
	}
}