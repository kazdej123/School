using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace School.Tests
{
	internal sealed class SchoolTests
	{
		private sealed class StringList : List<string> { }

		private sealed class ClassList : List<Class> { }


		/**
		 * Tests for School.AddClass(Class @class) method.
		 **/

		[Test]
		public static void AddClass_TriesToAddNullClassToEmptyClassesDictionary_ReturnedFalseAndClassesDictionaryIsEmpty()
		{
			var school = new School();

			Assert.IsFalse(school.AddClass((Class)null));

			CollectionAssert.IsEmpty(school.ClassesDictionary);
		}

		[Test]
		public static void AddClass_TriesToAddNullClassToNotEmptyClassesDictionary_ReturnedFalseAndClassesDictionaryEqualsToProper()
		{
			var school = new School();
			var @class = new Class("1a");
			var classesDictionary = school.ClassesDictionary;
			_ = classesDictionary.Add(@class);

			Assert.IsFalse(school.AddClass((Class)null));

			CollectionAssert.AreEqual(new StringList { "1a" },
									  classesDictionary.Keys);
			CollectionAssert.AreEqual(new ClassList { @class },
									  classesDictionary.Values);
			Assert.AreEqual(@class, classesDictionary["1a"]);
		}

		[Test]
		public static void AddClass_TriesToAddNotNullClassWithNullNameToEmptyClassesDictionary_ThrownArgumentNullExceptionAndClassesDictionaryIsEmpty()
		{
			var school = new School();

			_ = Assert.Throws<ArgumentNullException>(
				() => school.AddClass(new Class(null))
			);

			CollectionAssert.IsEmpty(school.ClassesDictionary);
		}

		[Test]
		public static void AddClass_TriesToAddNotNullClassWithNullNameToNotEmptyClassesDictionary_ThrownArgumentNullExceptionAndClassesDictionaryEqualsToProper()
		{
			var school = new School();
			var @class = new Class("1a");
			var classesDictionary = school.ClassesDictionary;
			_ = classesDictionary.Add(@class);

			_ = Assert.Throws<ArgumentNullException>(
				() => school.AddClass(new Class(null))
			);

			CollectionAssert.AreEqual(new StringList { "1a" },
									  classesDictionary.Keys);
			CollectionAssert.AreEqual(new ClassList { @class },
									  classesDictionary.Values);
			Assert.AreEqual(@class, classesDictionary["1a"]);
		}

		[Test]
		public static void AddClass_AddsNotNullClassToEmptyClassesDictionary_ReturnedTrueAndClassesDictionaryEqualsToProper()
		{
			var school = new School();
			var @class = new Class("1a");
			var classesDictionary = school.ClassesDictionary;

			Assert.IsTrue(school.AddClass(@class));

			CollectionAssert.AreEqual(new StringList { "1a" },
									  classesDictionary.Keys);
			CollectionAssert.AreEqual(new ClassList { @class },
									  classesDictionary.Values);
			Assert.AreEqual(@class, classesDictionary["1a"]);
		}

		[Test]
		public static void AddClass_TriesToAddNotNullNotUniqueClassToNotEmptyClassesDictionary_ReturnedFalseAndClassesDictionaryEqualsToProper()
		{
			var school = new School();
			var @class = new Class("1a");
			var classesDictionary = school.ClassesDictionary;
			_ = classesDictionary.Add(@class);

			Assert.IsFalse(school.AddClass(new Class("1a")));

			CollectionAssert.AreEqual(new StringList { "1a" },
									  classesDictionary.Keys);
			CollectionAssert.AreEqual(new ClassList { @class },
									  classesDictionary.Values);
			Assert.AreEqual(@class, classesDictionary["1a"]);
		}

		[Test]
		public static void AddClass_AddsNotNullUniqueClassToNotEmptyClassesDictionary_ReturnedTrueAndClassesDictionaryEqualsToProper()
		{
			var school = new School();
			var class1 = new Class("1a");
			var class2 = new Class("2a");
			var classesDictionary = school.ClassesDictionary;
			_ = classesDictionary.Add(class1);

			Assert.IsTrue(school.AddClass(class2));

			CollectionAssert.AreEqual(new StringList { "1a", "2a" },
									  classesDictionary.Keys);
			CollectionAssert.AreEqual(new ClassList { class1, class2 },
									  classesDictionary.Values);
			Assert.AreEqual(class1, classesDictionary["1a"]);
			Assert.AreEqual(class2, classesDictionary["2a"]);
		}


		/**
		 * Tests for School.AddClass(string className) method.
		 **/

		[Test]
		public static void AddClass_TriesToAddClassWithNullNameToEmptyClassesDictionary_ThrownArgumentNullExceptionAndClassesDictionaryIsEmpty()
		{
			var school = new School();

			_ = Assert.Throws<ArgumentNullException>(
				() => school.AddClass((string)null)
			);

			CollectionAssert.IsEmpty(school.ClassesDictionary);
		}

		[Test]
		public static void AddClass_TriesToAddClassWithNullNameToNotEmptyClassesDictionary_ThrownArgumentNullExceptionAndClassesDictionaryEqualsToProper()
		{
			var school = new School();
			var @class = new Class("1a");
			var classesDictionary = school.ClassesDictionary;
			_ = classesDictionary.Add(@class);

			_ = Assert.Throws<ArgumentNullException>(
				() => school.AddClass((string)null)
			);

			CollectionAssert.AreEqual(new StringList { "1a" },
									  classesDictionary.Keys);
			CollectionAssert.AreEqual(new ClassList { @class },
									  classesDictionary.Values);
			Assert.AreEqual(@class, classesDictionary["1a"]);
		}

		[Test]
		public static void AddClass_AddsClassWithNotNullNameToEmptyClassesDictionary_ReturnedTrueAndClassesDictionaryEqualsToProper()
		{
			var school = new School();
			var classesDictionary = school.ClassesDictionary;

			Assert.IsTrue(school.AddClass("1a"));

			CollectionAssert.AreEqual(new StringList { "1a" },
									  classesDictionary.Keys);
			Assert.AreEqual("1a", classesDictionary["1a"].Name);
		}

		[Test]
		public static void AddClass_TriesToAddClassWithNotNullNotUniqueNameToNotEmptyClassesDictionary_ReturnedFalseAndClassesDictionaryEqualsToProper()
		{
			var school = new School();
			var @class = new Class("1a");
			var classesDictionary = school.ClassesDictionary;
			_ = classesDictionary.Add(@class);

			Assert.IsFalse(school.AddClass(new Class("1a")));

			CollectionAssert.AreEqual(new StringList { "1a" },
									  classesDictionary.Keys);
			CollectionAssert.AreEqual(new ClassList { @class },
									  classesDictionary.Values);
			Assert.AreEqual(@class, classesDictionary["1a"]);
		}

		[Test]
		public static void AddClass_AddsClassWithNotNullUniqueNameToNotEmptyClassesDictionary_ReturnedTrueAndClassesDictionaryEqualsToProper()
		{
			var school = new School();
			var @class = new Class("1a");
			var classesDictionary = school.ClassesDictionary;
			_ = classesDictionary.Add(@class);

			Assert.IsTrue(school.AddClass("2a"));

			CollectionAssert.AreEqual(new StringList { "1a", "2a" },
									  classesDictionary.Keys);
			Assert.AreEqual(@class, classesDictionary["1a"]);
			Assert.AreEqual("2a", classesDictionary["2a"].Name);
		}


		/**
		 * Tests for School.RemoveClass(string className) method.
		 **/

		[Test]
		public static void RemoveClass_TriesToRemoveClassWithNullNameFromEmptyClassesDictionary_ReturnedFalseAndClassesDictionaryIsEmpty()
		{
			var school = new School();

			Assert.IsFalse(school.RemoveClass(null));

			CollectionAssert.IsEmpty(school.ClassesDictionary);
		}

		[Test]
		public static void RemoveClass_TriesToRemoveClassWithNullNameFromNotEmptyClassesDictionary_ReturnedFalseAndClassesDictionaryEqualsToProper()
		{
			var school = new School();
			var @class = new Class("1a");
			var classesDictionary = school.ClassesDictionary;
			_ = classesDictionary.Add(@class);

			Assert.IsFalse(school.RemoveClass(null));

			CollectionAssert.AreEqual(new StringList { "1a" },
									  classesDictionary.Keys);
			CollectionAssert.AreEqual(new ClassList { @class },
									  classesDictionary.Values);
			Assert.AreEqual(@class, classesDictionary["1a"]);
		}

		[Test]
		public static void RemoveClass_TriesToRemoveClassWithNotNullNameFromEmptyClassesDictionary_ReturnedFalseAndClassesDictionaryIsEmpty()
		{
			var school = new School();

			Assert.IsFalse(school.RemoveClass("1a"));

			CollectionAssert.IsEmpty(school.ClassesDictionary);
		}

		[Test]
		public static void RemoveClass_TriesToRemoveNotExistingClassWithNotNullNameFromNotEmptyClassesDictionary_ReturnedFalseAndClassesDictionaryEqualsToProper()
		{
			var school = new School();
			var @class = new Class("1a");
			var classesDictionary = school.ClassesDictionary;
			_ = classesDictionary.Add(@class);

			Assert.IsFalse(school.RemoveClass("2a"));

			CollectionAssert.AreEqual(new StringList { "1a" },
									  classesDictionary.Keys);
			CollectionAssert.AreEqual(new ClassList { @class },
									  classesDictionary.Values);
			Assert.AreEqual(@class, classesDictionary["1a"]);
		}

		[Test]
		public static void RemoveClass_RemovesExistingClassFromOneElementClassesDictionary_ReturnedTrueAndClassesDictionaryIsEmpty()
		{
			var school = new School();
			var classesDictionary = school.ClassesDictionary;
			_ = classesDictionary.Add(new Class("1a"));

			Assert.IsTrue(school.RemoveClass("1a"));

			CollectionAssert.IsEmpty(classesDictionary);
		}

		[Test]
		public static void RemoveClass_RemovesExistingClassFromMultipleElementsClassesDictionary_ReturnedTrueAndClassesDictionaryEqualsToProper()
		{
			var school = new School();
			var @class = new Class("2a");
			var classesDictionary = school.ClassesDictionary;
			_ = classesDictionary.Add(new Class("1a"));
			_ = classesDictionary.Add(@class);

			Assert.IsTrue(school.RemoveClass("1a"));

			CollectionAssert.AreEqual(new StringList { "2a" },
									  classesDictionary.Keys);
			CollectionAssert.AreEqual(new ClassList { @class },
									  classesDictionary.Values);
			Assert.AreEqual(@class, classesDictionary["2a"]);
		}


		/**
		 * Tests for School.GetClass(string className) method.
		 **/

		[Test]
		public static void GetClass_TriesToGetClassWithNullNameFromEmptyClassesDictionary_ReturnedNullAndClassesDictionaryIsEmpty()
		{
			var school = new School();

			Assert.IsNull(school.GetClass(null));

			CollectionAssert.IsEmpty(school.ClassesDictionary);
		}

		[Test]
		public static void GetClass_TriesToGetClassWithNullNameFromNotEmptyClassesDictionary_ReturnedNullAndClassesDictionaryIsUnchanged()
		{
			var school = new School();
			var @class = new Class("1a");
			var classesDictionary = school.ClassesDictionary;
			_ = classesDictionary.Add(@class);

			Assert.IsNull(school.GetClass(null));

			CollectionAssert.AreEqual(new StringList { "1a" },
									  classesDictionary.Keys);
			CollectionAssert.AreEqual(new ClassList { @class },
									  classesDictionary.Values);
			Assert.AreEqual(@class, classesDictionary["1a"]);
		}

		[Test]
		public static void GetClass_TriesToGetClassWithNotNullNameFromEmptyClassesDictionary_ReturnedNullAndClassesDictionaryIsEmpty()
		{
			var school = new School();

			Assert.IsNull(school.GetClass("1a"));

			CollectionAssert.IsEmpty(school.ClassesDictionary);
		}

		[Test]
		public static void GetClass_TriesToGetNotExistingClassWithNotNullNameFromNotEmptyClassesDictionary_ReturnedNullAndClassesDictionaryIsUnchanged()
		{
			var school = new School();
			var @class = new Class("1a");
			var classesDictionary = school.ClassesDictionary;
			_ = classesDictionary.Add(@class);

			Assert.IsNull(school.GetClass("2a"));

			CollectionAssert.AreEqual(new StringList { "1a" },
									  classesDictionary.Keys);
			CollectionAssert.AreEqual(new ClassList { @class },
									  classesDictionary.Values);
			Assert.AreEqual(@class, classesDictionary["1a"]);
		}

		[Test]
		public static void GetClass_GetsExistingClassFromOneElementClassesDictionary_ReturnedProperClassAndClassesDictionaryIsUnchanged()
		{
			var school = new School();
			var @class = new Class("1a");
			var classesDictionary = school.ClassesDictionary;
			_ = classesDictionary.Add(@class);

			Assert.AreEqual(@class, school.GetClass("1a"));

			CollectionAssert.AreEqual(new StringList { "1a" },
									  classesDictionary.Keys);
			CollectionAssert.AreEqual(new ClassList { @class },
									  classesDictionary.Values);
			Assert.AreEqual(@class, classesDictionary["1a"]);
		}

		[Test]
		public static void GetClass_GetsExistingClassFromMultipleElementsClassesDictionary_ReturnedProperClassAndClassesDictionaryIsUnchanged()
		{
			var school = new School();
			var class1 = new Class("1a");
			var class2 = new Class("2a");
			var classesDictionary = school.ClassesDictionary;
			_ = classesDictionary.Add(class1);
			_ = classesDictionary.Add(class2);

			Assert.AreEqual(class1, school.GetClass("1a"));

			CollectionAssert.AreEqual(new StringList { "1a", "2a" },
									  classesDictionary.Keys);
			CollectionAssert.AreEqual(new ClassList { class1, class2 },
									  classesDictionary.Values);
			Assert.AreEqual(class1, classesDictionary["1a"]);
			Assert.AreEqual(class2, classesDictionary["2a"]);
		}
	}
}
