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
			stateDao = A.Fake<IStateDao>();
			statePersister = new StatePersister(stateDao);
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
			statePersister.Invoking(x => x.Observe((Foo)null))
				.ShouldThrow<ArgumentNullException>();
		}

		[Fact]
		public void MustPassPropertiesToPersist()
		{
			statePersister.Invoking(x => x.Observe(new Foo()))
				.ShouldThrow<ArgumentException>().WithMessage("No properties passed");
		}

		[Fact]
		public void RestoresValue()
		{
			A.CallTo(() => stateDao.Get<Foo>())
				.Returns(new StateDto
					{
						Name = "Foo",
						PropertyValues = new List<Tuple<string, object>> { Tuple.Create("Text", (object)"karol") }
					});

			var itemToObserve = new Foo();
			statePersister.Observe(itemToObserve, Properties.Select(() => itemToObserve.Text));

			itemToObserve.Text.Should().Be("karol");
		}

		[Fact]
		public void StoresValueOnValueChange()
		{
			var itemToObserve = new Foo();
			statePersister.Observe(itemToObserve, Properties.Select(() => itemToObserve.Text));

			itemToObserve.Text = "włodek";

			A.CallTo(() => stateDao.Save(A<StateDto>._)).MustHaveHappened();
		}

		private readonly StatePersister statePersister;
		private readonly IStateDao stateDao;
	}

	public class Foo : ReactiveObject
	{
		private string text;

		public string Text
		{
			get { return text; }
			set { this.RaiseAndSetIfChanged(ref text, value); }
		}

	}
}