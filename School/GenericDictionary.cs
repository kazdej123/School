using System;
using System.Collections;
using System.Collections.Generic;

namespace School
{
	public class GenericDictionary<TKey, TValue> : IEnumerable
		where TValue : SchoolObject<TKey>
	{
		private readonly IDictionary<TKey, TValue> _dictionary
			= new Dictionary<TKey, TValue>();

		public IEnumerable Keys => _dictionary.Keys;

		public IEnumerable Values => _dictionary.Values;

		public TValue this[TKey key] => _dictionary[key];

		public IEnumerator GetEnumerator() => _dictionary.GetEnumerator();

		public bool Add(TValue value)
		{
			if (value == null) {
				return false;
			}
			try {
				_dictionary.Add(value.UniqueId, value);
				return true;
			} catch (ArgumentException) {
				return false;
			}
		}

		public bool Remove(TKey key)
		{
			return key == null ? false : _dictionary.Remove(key);
		}

		public TValue Get(TKey key)
		{
			if (key == null) {
				return null;
			}
			try {
				return _dictionary[key];
			} catch (KeyNotFoundException) {
				return null;
			}
		}
	}
}