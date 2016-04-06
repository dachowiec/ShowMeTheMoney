﻿using ReactiveUI;

namespace ShowMeTheMoney.ViewModels
{
	public class EncouragementViewModel : ReactiveObject, IRoutableViewModel
	{
		public string UrlPathSegment { get; private set; }

		public IScreen HostScreen { get; private set; }
	}
}