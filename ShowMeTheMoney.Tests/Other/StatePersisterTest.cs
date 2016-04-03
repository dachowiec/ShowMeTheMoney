using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using Ploeh.Albedo;
using ReactiveUI;
using ShowMeTheMoney.Other;
using Xunit;

namespace ShowMeTheMoney.Tests.Other
{
	public class StatePersisterTest
	{
		public StatePersisterTest()
		{
			_stateDao = A.Fake<IStateDao>();
			_statePersister = new StatePersister(_stateDao);
		}

		[Fact]
		public void ObservableObjectShouldThrowPropertyChanged()
		{
			var observeMethod = typeof (StatePersister).GetMethod("Observe");

			Type genericArguments = observeMethod.GetGenericMethodDefinition()
					.GetGenericArguments()
					.First();

			genericArguments.GetGenericParameterConstraints()
				.Should()
				.Contain(typeof (INotifyPropertyChanged));
		}

		[Fact]
		public void CannotPassNull()
		{
			_statePersister.Invoking(x => x.Observe((Foo)null))
				.ShouldThrow<ArgumentNullException>();
		}

		[Fact]
		public void MustPassPropertiesToPersist()
		{
			_statePersister.Invoking(x => x.Observe(new Foo()))
				.ShouldThrow<ArgumentException>().WithMessage("No properties passed");
		}

		[Fact]
		public void RestoresValue()
		{
			A.CallTo(() => _stateDao.Get<Foo>())
				.Returns(new StateDto
					{
						Name = "Foo",
						PropertyValues = new List<Tuple<string, object>> { Tuple.Create("Text", (object)"karol") }
					});

			var itemToObserve = new Foo();
			_statePersister.Observe(itemToObserve, Properties.Select(() => itemToObserve.Text));

			itemToObserve.Text.Should().Be("karol");
		}

		[Fact]
		public void StoresValueOnValueChange()
		{
			var itemToObserve = new Foo();
			_statePersister.Observe(itemToObserve, Properties.Select(() => itemToObserve.Text));

			itemToObserve.Text = "włodek";

			A.CallTo(() => _stateDao.Save(A<StateDto>._)).MustHaveHappened();
		}

		private readonly StatePersister _statePersister;
		private readonly IStateDao _stateDao;
	}

	public class Foo : ReactiveObject
	{
		private string _text;

		public string Text
		{
			get { return _text; }
			set { this.RaiseAndSetIfChanged(ref _text, value); }
		}

	}
}