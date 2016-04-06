using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace ShowMeTheMoney.Other
{
	public class StatePersister
	{
		public StatePersister(IStateDao stateDao)
		{
			this.stateDao = stateDao;
		}

		public void Observe<T>(T itemToObserve, params PropertyInfo[] properties) where T : class, INotifyPropertyChanged
		{
			if (itemToObserve == null)
				throw new ArgumentNullException("itemToObserve");
			if (properties.Length == 0)
				throw new ArgumentException("No properties passed");

			TryRestore<T>(itemToObserve, properties);

			itemToObserve.PropertyChanged += (sender, args) =>
			{
				if (properties.All(p => p.Name != args.PropertyName))
					return;

				stateDao.Save(new StateDto
				{
					Name = typeof(T).Name,
					PropertyValues = properties
						.Select(p => new Tuple<string, object>(p.Name, p.GetValue(itemToObserve)))
						.ToList()
				});
			};

		}

		private void TryRestore<T>(object itemToObserve, IEnumerable<PropertyInfo> propertiesToObserve)
		{
			var state = stateDao.Get<T>();
			if (state == null)
				return;

			foreach (var property in propertiesToObserve)
			{
				var tupleValue = state.PropertyValues.FirstOrDefault(tp => tp.Item1 == property.Name);
				if (tupleValue != null)
					property.SetValue(itemToObserve, tupleValue.Item2);
			}
		}

		private readonly IStateDao stateDao;
	}

	public interface IStateDao
	{
		StateDto Get<T>();

		void Save(StateDto stateDto);
	}

	public class XmlFileStateDao : IStateDao
	{
		public XmlFileStateDao()
		{
			if (!Directory.Exists("stored"))
				Directory.CreateDirectory("stored");
		}

		public StateDto Get<T>()
		{
			string path = Path.Combine("stored", typeof(T).Name);
			if (!File.Exists(path))
				return null;

			using (var stream = new FileStream(path, FileMode.Open))
			{
				var doc = XDocument.Load(stream);

				var properties = typeof(T).GetProperties().ToDictionary(x => x.Name);

				return new StateDto
				{
					Name = typeof(T).Name,
					PropertyValues = doc.Root.Elements()
						.Select(x => new Tuple<string, object>(x.Name.LocalName,
							Convert.ChangeType(x.Value, properties[x.Name.LocalName].PropertyType)))
						.ToList()
				};
			}
		}

		public void Save(StateDto stateDto)
		{
			string path = Path.Combine("stored", stateDto.Name);

			var doc = XDocument.Parse("<root></root>");

			foreach (var value in stateDto.PropertyValues)
				doc.Root.Add(new XElement(value.Item1, value.Item2));

			using (var stream = new FileStream(path, FileMode.OpenOrCreate))
				doc.Save(stream);
		}
	}

	public class StateDto
	{
		public string Name { get; set; }

		public List<Tuple<string, object>> PropertyValues
		{
			get { return propertyValues ?? new List<Tuple<string, object>>(); }
			set { propertyValues = value; }
		}

		private List<Tuple<string, object>> propertyValues;
	}
}