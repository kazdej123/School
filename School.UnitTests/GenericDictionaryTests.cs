using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace School.Tests
{
	[TestFixture(typeof(string), typeof(Class))]
	[TestFixture(typeof(int?), typeof(Student))]
	[TestFixture(typeof(string), typeof(Subject))]
	[TestFixture(typeof(int?), typeof(Teacher))]
	internal sealed class GenericDictionaryTests<TKey, TValue>
		where TValue : SchoolObject<TKey>
	{
		private sealed class TKeyList : List<TKey> { }

		private sealed class TValueList : List<TValue> { }


		/**
		 * Tests for GenericDictionary.Add(TValue value) method.
		 **/

		[Test]
		public static void Add_TriesToAddNullValueToEmptyDictionary_ReturnedFalseAndKeysAndValuesAreEmpty()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();

			Assert.IsFalse(dictionary.Add(null));

			CollectionAssert.IsEmpty(dictionary.Keys);
			CollectionAssert.IsEmpty(dictionary.Values);
		}

		[Test]
		public static void Add_TriesToAddNullValueToNotEmptyDictionary_ReturnedFalseAndKeysAndValuesAreProper()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();
			var key = CreateSampleKey();
			var value = CreateValue(key);
			_ = dictionary.Add(value);

			Assert.IsFalse(dictionary.Add(null));

			CollectionAssert.AreEqual(new TKeyList { key },
									  dictionary.Keys);
			CollectionAssert.AreEqual(new TValueList { value },
									  dictionary.Values);
			Assert.AreEqual(value, dictionary[key]);
		}

		[Test]
		public static void Add_TriesToAddNotNullValueWithNullKeyToEmptyDictionary_ThrownArgumentNullExceptionAndKeysAndValuesAreEmpty()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();

			_ = Assert.Throws<ArgumentNullException>(
				() => dictionary.Add(CreateValue(default))
			);

			CollectionAssert.IsEmpty(dictionary.Keys);
			CollectionAssert.IsEmpty(dictionary.Values);
		}

		[Test]
		public static void Add_TriesToAddNotNullValueWithNullKeyToNotEmptyDictionary_ThrownArgumentNullExceptionAndKeysAndValuesAreProper()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();
			var key = CreateSampleKey();
			var value = CreateValue(key);
			_ = dictionary.Add(value);

			_ = Assert.Throws<ArgumentNullException>(
				() => dictionary.Add(CreateValue(default))
			);

			CollectionAssert.AreEqual(new TKeyList { key },
									  dictionary.Keys);
			CollectionAssert.AreEqual(new TValueList { value },
									  dictionary.Values);
			Assert.AreEqual(value, dictionary[key]);
		}

		[Test]
		public static void Add_AddsNotNullValueWithNotNullKeyToEmptyDictionary_ReturnedTrueAndKeysAndValuesAreProper()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();
			var key = CreateSampleKey();
			var value = CreateValue(key);

			Assert.IsTrue(dictionary.Add(value));

			CollectionAssert.AreEqual(new TKeyList { key },
									  dictionary.Keys);
			CollectionAssert.AreEqual(new TValueList { value },
									  dictionary.Values);
			Assert.AreEqual(value, dictionary[key]);
		}

		[Test]
		public static void Add_TriesToAddNotNullValueWithNotUniqueKeyToNotEmptyDictionary_ReturnedFalseAndKeysAndValuesAreProper()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();
			var key = CreateSampleKey();
			var value = CreateValue(key);
			_ = dictionary.Add(value);

			Assert.IsFalse(dictionary.Add(CreateValue(CreateSampleKey())));

			CollectionAssert.AreEqual(new TKeyList { key },
									  dictionary.Keys);
			CollectionAssert.AreEqual(new TValueList { value },
									  dictionary.Values);
			Assert.AreEqual(value, dictionary[key]);
		}

		[Test]
		public static void Add_AddsNotNullValueWithUniqueKeyToNotEmptyDictionary_ReturnedTrueAndKeysAndValuesAreProper()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();
			var key1 = CreateSampleKey();
			var key2 = CreateDifferentKey();
			var value1 = CreateValue(key1);
			var value2 = CreateValue(key2);
			_ = dictionary.Add(value1);

			Assert.IsTrue(dictionary.Add(value2));

			CollectionAssert.AreEqual(new TKeyList { key1, key2 },
									  dictionary.Keys);
			CollectionAssert.AreEqual(new TValueList { value1, value2 },
									  dictionary.Values);
			Assert.AreEqual(value1, dictionary[key1]);
			Assert.AreEqual(value2, dictionary[key2]);
		}


		/**
		 * Tests for GenericDictionary.Remove(TKey key) method.
		 **/

		[Test]
		public static void Remove_TriesToRemoveValueWithNullKeyFromEmptyDictionary_ReturnedFalseAndDictionaryIsEmpty()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();

			Assert.IsFalse(dictionary.Remove(default));

			CollectionAssert.IsEmpty(dictionary);
		}

		[Test]
		public static void Remove_TriesToRemoveValueWithNullKeyFromNotEmptyDictionary_ReturnedFalseAndDictionaryAreProper()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();
			var key = CreateSampleKey();
			var value = CreateValue(key);
			_ = dictionary.Add(value);

			Assert.IsFalse(dictionary.Remove(default));

			CollectionAssert.AreEqual(new TKeyList { key },
									  dictionary.Keys);
			CollectionAssert.AreEqual(new TValueList { value },
									  dictionary.Values);
			Assert.AreEqual(value, dictionary[key]);
		}

		[Test]
		public static void Remove_TriesToRemoveValueWithNotNullKeyFromEmptyDictionary_ReturnedFalseAndDictionaryIsEmpty()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();

			Assert.IsFalse(dictionary.Remove(CreateSampleKey()));

			CollectionAssert.IsEmpty(dictionary);
		}

		[Test]
		public static void Remove_TriesToRemoveValueWithNotExistingKeyFromNotEmptyDictionary_ReturnedFalseAndDictionaryAreProper()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();
			var key = CreateSampleKey();
			var value = CreateValue(key);
			_ = dictionary.Add(value);

			Assert.IsFalse(dictionary.Remove(CreateDifferentKey()));

			CollectionAssert.AreEqual(new TKeyList { key },
									  dictionary.Keys);
			CollectionAssert.AreEqual(new TValueList { value },
									  dictionary.Values);
			Assert.AreEqual(value, dictionary[key]);
		}

		[Test]
		public static void Remove_RemovesValueWithExistingKeyFromOneElementDictionary_ReturnedTrueAndDictionaryIsEmpty()
		{
			var dictionary = new GenericDictionary<TKey, TValue> {
				CreateValue(CreateSampleKey())
			};

			Assert.IsTrue(dictionary.Remove(CreateSampleKey()));

			CollectionAssert.IsEmpty(dictionary);
		}

		[Test]
		public static void Remove_RemovesValueWithExistingKeyFromMultipleElementsDictionary_ReturnedTrueAndDictionaryAreProper()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();
			var key = CreateDifferentKey();
			var value = CreateValue(key);
			_ = dictionary.Add(CreateValue(CreateSampleKey()));
			_ = dictionary.Add(value);

			Assert.IsTrue(dictionary.Remove(CreateSampleKey()));

			CollectionAssert.AreEqual(new TKeyList { key },
									  dictionary.Keys);
			CollectionAssert.AreEqual(new TValueList { value },
									  dictionary.Values);
			Assert.AreEqual(value, dictionary[key]);
		}


		/**
		 * Tests for GenericDictionary.Get(TKey key) method.
		 **/

		[Test]
		public static void Get_TriesToGetValueWithNullKeyFromEmptyDictionary_ReturnedNullAndDictionaryIsEmpty()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();

			Assert.IsNull(dictionary.Get(default));

			CollectionAssert.IsEmpty(dictionary);
		}

		[Test]
		public static void Get_TriesToGetValueWithNullKeyFromNotEmptyDictionary_ReturnedNullAndDictionaryIsUnchanged()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();
			var key = CreateSampleKey();
			var value = CreateValue(key);
			_ = dictionary.Add(value);

			Assert.IsNull(dictionary.Get(default));

			CollectionAssert.AreEqual(new TKeyList { key },
									  dictionary.Keys);
			CollectionAssert.AreEqual(new TValueList { value },
									  dictionary.Values);
			Assert.AreEqual(value, dictionary[key]);
		}

		[Test]
		public static void Get_TriesToGetValueWithNotNullKeyFromEmptyDictionary_ReturnedNullAndDictionaryIsEmpty()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();

			Assert.IsNull(dictionary.Get(CreateSampleKey()));

			CollectionAssert.IsEmpty(dictionary);
		}

		[Test]
		public static void Get_TriesToGetValueWithNotExistingKeyFromNotEmptyDictionary_ReturnedNullAndDictionaryIsUnchanged()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();
			var key = CreateSampleKey();
			var value = CreateValue(key);
			_ = dictionary.Add(value);

			Assert.IsNull(dictionary.Get(CreateDifferentKey()));

			CollectionAssert.AreEqual(new TKeyList { key },
									  dictionary.Keys);
			CollectionAssert.AreEqual(new TValueList { value },
									  dictionary.Values);
			Assert.AreEqual(value, dictionary[key]);
		}

		[Test]
		public static void Get_GetsValueWithExistingKeyFromOneElementDictionary_ReturnedProperClassAndDictionaryIsUnchanged()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();
			var key = CreateSampleKey();
			var value = CreateValue(key);
			_ = dictionary.Add(value);

			Assert.AreEqual(value, dictionary.Get(key));

			CollectionAssert.AreEqual(new TKeyList { key },
									  dictionary.Keys);
			CollectionAssert.AreEqual(new TValueList { value },
									  dictionary.Values);
			Assert.AreEqual(value, dictionary[key]);
		}

		[Test]
		public static void Get_GetsValueWithExistingKeyFromMultipleElementsDictionary_ReturnedProperClassAndDictionaryIsUnchanged()
		{
			var dictionary = new GenericDictionary<TKey, TValue>();
			var key1 = CreateSampleKey();
			var key2 = CreateDifferentKey();
			var value1 = CreateValue(key1);
			var value2 = CreateValue(key2);
			_ = dictionary.Add(value1);
			_ = dictionary.Add(value2);

			Assert.AreEqual(value1, dictionary.Get(key1));

			CollectionAssert.AreEqual(new TKeyList { key1, key2 },
									  dictionary.Keys);
			CollectionAssert.AreEqual(new TValueList { value1, value2 },
									  dictionary.Values);
			Assert.AreEqual(value1, dictionary[key1]);
			Assert.AreEqual(value2, dictionary[key2]);
		}


		/**
		 * Private methods.
		 **/

		private static TKey CreateSampleKey()
		{
			var keyType = typeof(TKey);

			if (keyType == typeof(string)) {
				return (TKey)(object)"1a";
			}
			if (keyType == typeof(int?)) {
				return (TKey)(object)1;
			}
			return default;
		}

		private static TKey CreateDifferentKey()
		{
			var keyType = typeof(TKey);

			if (keyType == typeof(string)) {
				return (TKey)(object)"2a";
			}
			if (keyType == typeof(int?)) {
				return (TKey)(object)2;
			}
			return default;
		}

		private static TValue CreateValue(TKey key)
		{
			var valueType = typeof(TValue);

			if (valueType == typeof(Class)) {
				return new Class(key as string) as TValue;
			}
			if (valueType == typeof(Student)) {
				return new Student(key as int?) as TValue;
			}
			if (valueType == typeof(Subject)) {
				return new Subject(key as string) as TValue;
			}
			if (valueType == typeof(Teacher)) {
				return new Teacher(key as int?) as TValue;
			}
			return default;
		}
	}
}
