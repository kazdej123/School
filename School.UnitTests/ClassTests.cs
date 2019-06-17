using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace School.Tests
{
	internal sealed class ClassTests
	{
		private sealed class IntList : List<int> { }

		private sealed class StudentList : List<Student> { }


		/**
		 * Tests for Class.Class(string className) constructor.
		 **/

		[Test]
		public static void Class_TriesToCallConstructorWithNullClassName_ThrownNullArgumentException()
		{
			_ = Assert.Throws<ArgumentNullException>(() => new Class(null));
		}

		[Test]
		public static void Class_CallsConstructorWithNotNullClassName_ThrownNoExceptions()
		{
			Assert.DoesNotThrow(() => new Class("1a"));
		}


		/**
		 * Tests for Class.Name get-property.
		 **/

		[Test]
		public static void Name_GetsName_ReturnedProperName()
		{
			Assert.AreEqual("1a", new Class("1a").Name);
		}


		/**
		 * Tests for Class.TeachersNumber property.
		 **/

		[Test]
		public static void TeachersNumber_TriesToSetNegativeTeachersNumber_ThrownArgumentOutOfRangeException()
		{
			_ = Assert.Throws<ArgumentOutOfRangeException>(
				() => new Class("1a").TeachersNumber = -1
			);
		}

		[Test]
		public static void TeachersNumber_SetsAndGetsZeroTeachersNumber_ThrownNoExceptionsAndReturnedZero()
		{
			var @class = new Class("1a");

			Assert.DoesNotThrow(() => @class.TeachersNumber = 0);
			Assert.AreEqual(0, @class.TeachersNumber);
		}

		[Test]
		public static void TeachersNumber_SetsAndGetsPositiveTeachersNumber_ThrownNoExceptionsAndReturnedProperNumber()
		{
			var @class = new Class("1a");

			Assert.DoesNotThrow(() => @class.TeachersNumber = 1);
			Assert.AreEqual(1, @class.TeachersNumber);
		}


		/**
		 * Tests for Class.AddStudent(Student student) method.
		 **/

		[Test]
		public static void AddStudent_TriesToAddNullStudentToEmptyStudentsDictionary_ReturnedFalseAndStudentsDictionaryIsEmpty()
		{
			var @class = new Class("1a");

			Assert.IsFalse(@class.AddStudent((Student)null));

			CollectionAssert.IsEmpty(@class.StudentsDictionary);
		}

		[Test]
		public static void AddStudent_TriesToAddNullStudentToNotEmptyStudentsDictionary_ReturnedFalseAndStudentsDictionaryEqualsToProper()
		{
			var @class = new Class("1a");
			var student = new Student(1);
			var studentsDictionary = @class.StudentsDictionary;
			_ = studentsDictionary.Add(student);

			Assert.IsFalse(@class.AddStudent((Student)null));

			CollectionAssert.AreEqual(new IntList { 1 },
									  studentsDictionary.Keys);
			CollectionAssert.AreEqual(new StudentList { student },
									  studentsDictionary.Values);
			Assert.AreEqual(student, studentsDictionary[1]);
		}

		[Test]
		public static void AddStudent_TriesToAddNotNullStudentWithNullIdToEmptyStudentsDictionary_ThrownArgumentNullExceptionAndStudentsDictionaryIsEmpty()
		{
			var @class = new Class("1a");

			_ = Assert.Throws<ArgumentNullException>(
				() => @class.AddStudent(new Student(null))
			);

			CollectionAssert.IsEmpty(@class.StudentsDictionary);
		}

		[Test]
		public static void AddStudent_TriesToAddNotNullStudentWithNullIdToNotEmptyStudentsDictionary_ThrownArgumentNullExceptionAndStudentsDictionaryEqualsToProper()
		{
			var @class = new Class("1a");
			var student = new Student(1);
			var studentsDictionary = @class.StudentsDictionary;
			_ = studentsDictionary.Add(student);

			_ = Assert.Throws<ArgumentNullException>(
				() => @class.AddStudent(new Student(null))
			);

			CollectionAssert.AreEqual(new IntList { 1 },
									  studentsDictionary.Keys);
			CollectionAssert.AreEqual(new StudentList { student },
									  studentsDictionary.Values);
			Assert.AreEqual(student, studentsDictionary[1]);
		}

		[Test]
		public static void AddStudent_AddsNotNullStudentToEmptyStudentsDictionary_ReturnedTrueAndStudentsDictionaryEqualsToProper()
		{
			var @class = new Class("1a");
			var student = new Student(1);
			var studentsDictionary = @class.StudentsDictionary;

			Assert.IsTrue(@class.AddStudent(student));

			CollectionAssert.AreEqual(new IntList { 1 },
									  studentsDictionary.Keys);
			CollectionAssert.AreEqual(new StudentList { student },
									  studentsDictionary.Values);
			Assert.AreEqual(student, studentsDictionary[1]);
		}

		[Test]
		public static void AddStudent_TriesToAddNotNullNotUniqueStudentToNotEmptyStudentsDictionary_ReturnedFalseAndStudentsDictionaryEqualsToProper()
		{
			var @class = new Class("1a");
			var student = new Student(1);
			var studentsDictionary = @class.StudentsDictionary;
			_ = studentsDictionary.Add(student);

			Assert.IsFalse(@class.AddStudent(new Student(1)));

			CollectionAssert.AreEqual(new IntList { 1 },
									  studentsDictionary.Keys);
			CollectionAssert.AreEqual(new StudentList { student },
									  studentsDictionary.Values);
			Assert.AreEqual(student, studentsDictionary[1]);
		}

		[Test]
		public static void AddStudent_AddsNotNullUniqueStudentToNotEmptyStudentsDictionary_ReturnedTrueAndStudentsDictionaryEqualsToProper()
		{
			var @class = new Class("1a");
			var student1 = new Student(1);
			var student2 = new Student(2);
			var studentsDictionary = @class.StudentsDictionary;
			_ = studentsDictionary.Add(student1);

			Assert.IsTrue(@class.AddStudent(student2));

			CollectionAssert.AreEqual(new IntList { 1, 2 },
									  studentsDictionary.Keys);
			CollectionAssert.AreEqual(new StudentList { student1, student2 },
									  studentsDictionary.Values);
			Assert.AreEqual(student1, studentsDictionary[1]);
			Assert.AreEqual(student2, studentsDictionary[2]);
		}


		/**
		 * Tests for Class.AddStudent(int? studentId) method.
		 **/

		[Test]
		public static void AddStudent_TriesToAddStudentWithNullIdToEmptyStudentsDictionary_ThrownArgumentNullExceptionAndStudentsDictionaryIsEmpty()
		{
			var @class = new Class("1a");

			_ = Assert.Throws<ArgumentNullException>(
				() => @class.AddStudent((int?)null)
			);

			CollectionAssert.IsEmpty(@class.StudentsDictionary);
		}

		[Test]
		public static void AddStudent_TriesToAddStudentWithNullIdToNotEmptyStudentsDictionary_ThrownArgumentNullExceptionAndStudentsDictionaryEqualsToProper()
		{
			var @class = new Class("1a");
			var student = new Student(1);
			var studentsDictionary = @class.StudentsDictionary;
			_ = studentsDictionary.Add(student);

			_ = Assert.Throws<ArgumentNullException>(
				() => @class.AddStudent((int?)null)
			);

			CollectionAssert.AreEqual(new IntList { 1 },
									  studentsDictionary.Keys);
			CollectionAssert.AreEqual(new StudentList { student },
									  studentsDictionary.Values);
			Assert.AreEqual(student, studentsDictionary[1]);
		}

		[Test]
		public static void AddStudent_AddsStudentWithNotNullIdToEmptyStudentsDictionary_ReturnedTrueAndStudentsDictionaryEqualsToProper()
		{
			var @class = new Class("1a");
			var studentsDictionary = @class.StudentsDictionary;

			Assert.IsTrue(@class.AddStudent(1));

			CollectionAssert.AreEqual(new IntList { 1 },
									  studentsDictionary.Keys);
			Assert.AreEqual(1, studentsDictionary[1].Id);
		}

		[Test]
		public static void AddStudent_TriesToAddStudentWithNotNullNotUniqueIdToNotEmptyStudentsDictionary_ReturnedFalseAndStudentsDictionaryEqualsToProper()
		{
			var @class = new Class("1a");
			var student = new Student(1);
			var studentsDictionary = @class.StudentsDictionary;
			_ = studentsDictionary.Add(student);

			Assert.IsFalse(@class.AddStudent(new Student(1)));

			CollectionAssert.AreEqual(new IntList { 1 },
									  studentsDictionary.Keys);
			CollectionAssert.AreEqual(new StudentList { student },
									  studentsDictionary.Values);
			Assert.AreEqual(student, studentsDictionary[1]);
		}

		[Test]
		public static void AddStudent_AddsStudentWithNotNullUniqueIdToNotEmptyStudentsDictionary_ReturnedTrueAndStudentsDictionaryEqualsToProper()
		{
			var @class = new Class("1a");
			var student = new Student(1);
			var studentsDictionary = @class.StudentsDictionary;
			_ = studentsDictionary.Add(student);

			Assert.IsTrue(@class.AddStudent(2));

			CollectionAssert.AreEqual(new IntList { 1, 2 },
									  studentsDictionary.Keys);
			Assert.AreEqual(student, studentsDictionary[1]);
			Assert.AreEqual(2, studentsDictionary[2].Id);
		}


		/**
		 * Tests for Class.RemoveStudent(int? studentId) method.
		 **/

		[Test]
		public static void RemoveStudent_TriesToRemoveStudentWithNullIdFromEmptyStudentsDictionary_ReturnedFalseAndStudentsDictionaryIsEmpty()
		{
			var @class = new Class("1a");

			Assert.IsFalse(@class.RemoveStudent(null));

			CollectionAssert.IsEmpty(@class.StudentsDictionary);
		}

		[Test]
		public static void RemoveStudent_TriesToRemoveStudentWithNullIdFromNotEmptyStudentsDictionary_ReturnedFalseAndStudentsDictionaryEqualsToProper()
		{
			var @class = new Class("1a");
			var student = new Student(1);
			var studentsDictionary = @class.StudentsDictionary;
			_ = studentsDictionary.Add(student);

			Assert.IsFalse(@class.RemoveStudent(null));

			CollectionAssert.AreEqual(new IntList { 1 },
									  studentsDictionary.Keys);
			CollectionAssert.AreEqual(new StudentList { student },
									  studentsDictionary.Values);
			Assert.AreEqual(student, studentsDictionary[1]);
		}

		[Test]
		public static void RemoveStudent_TriesToRemoveStudentWithNotNullIdFromEmptyStudentsDictionary_ReturnedFalseAndStudentsDictionaryIsEmpty()
		{
			var @class = new Class("1a");

			Assert.IsFalse(@class.RemoveStudent(1));

			CollectionAssert.IsEmpty(@class.StudentsDictionary);
		}

		[Test]
		public static void RemoveStudent_TriesToRemoveNotExistingStudentWithNotNullIdFromNotEmptyStudentsDictionary_ReturnedFalseAndStudentsDictionaryEqualsToProper()
		{
			var @class = new Class("1a");
			var student = new Student(1);
			var studentsDictionary = @class.StudentsDictionary;
			_ = studentsDictionary.Add(student);

			Assert.IsFalse(@class.RemoveStudent(2));

			CollectionAssert.AreEqual(new IntList { 1 },
									  studentsDictionary.Keys);
			CollectionAssert.AreEqual(new StudentList { student },
									  studentsDictionary.Values);
			Assert.AreEqual(student, studentsDictionary[1]);
		}

		[Test]
		public static void RemoveStudent_RemovesExistingStudentFromOneElementStudentsDictionary_ReturnedTrueAndStudentsDictionaryIsEmpty()
		{
			var @class = new Class("1a");
			var studentsDictionary = @class.StudentsDictionary;
			_ = studentsDictionary.Add(new Student(1));

			Assert.IsTrue(@class.RemoveStudent(1));

			CollectionAssert.IsEmpty(studentsDictionary);
		}

		[Test]
		public static void RemoveStudent_RemovesExistingStudentFromMultipleElementsStudentsDictionary_ReturnedTrueAndStudentsDictionaryEqualsToProper()
		{
			var @class = new Class("1a");
			var student = new Student(2);
			var studentsDictionary = @class.StudentsDictionary;
			_ = studentsDictionary.Add(new Student(1));
			_ = studentsDictionary.Add(student);

			Assert.IsTrue(@class.RemoveStudent(1));

			CollectionAssert.AreEqual(new IntList { 2 },
									  studentsDictionary.Keys);
			CollectionAssert.AreEqual(new StudentList { student },
									  studentsDictionary.Values);
			Assert.AreEqual(student, studentsDictionary[2]);
		}


		/**
		 * Tests for Class.GetStudent(int? studentId) method.
		 **/

		[Test]
		public static void GetStudent_TriesToGetStudentWithNullIdFromEmptyStudentsDictionary_ReturnedNullAndStudentsDictionaryIsEmpty()
		{
			var @class = new Class("1a");

			Assert.IsNull(@class.GetStudent(null));

			CollectionAssert.IsEmpty(@class.StudentsDictionary);
		}

		[Test]
		public static void GetStudent_TriesToGetStudentWithNullIdFromNotEmptyStudentsDictionary_ReturnedNullAndStudentsDictionaryIsUnchanged()
		{
			var @class = new Class("1a");
			var student = new Student(1);
			var studentsDictionary = @class.StudentsDictionary;
			_ = studentsDictionary.Add(student);

			Assert.IsNull(@class.GetStudent(null));

			CollectionAssert.AreEqual(new IntList { 1 },
									  studentsDictionary.Keys);
			CollectionAssert.AreEqual(new StudentList { student },
									  studentsDictionary.Values);
			Assert.AreEqual(student, studentsDictionary[1]);
		}

		[Test]
		public static void GetStudent_TriesToGetStudentWithNotNullIdFromEmptyStudentsDictionary_ReturnedNullAndStudentsDictionaryIsEmpty()
		{
			var @class = new Class("1a");

			Assert.IsNull(@class.GetStudent(1));

			CollectionAssert.IsEmpty(@class.StudentsDictionary);
		}

		[Test]
		public static void GetStudent_TriesToGetNotExistingStudentWithNotNullIdFromNotEmptyStudentsDictionary_ReturnedNullAndStudentsDictionaryIsUnchanged()
		{
			var @class = new Class("1a");
			var student = new Student(1);
			var studentsDictionary = @class.StudentsDictionary;
			_ = studentsDictionary.Add(student);

			Assert.IsNull(@class.GetStudent(2));

			CollectionAssert.AreEqual(new IntList { 1 },
									  studentsDictionary.Keys);
			CollectionAssert.AreEqual(new StudentList { student },
									  studentsDictionary.Values);
			Assert.AreEqual(student, studentsDictionary[1]);
		}

		[Test]
		public static void GetStudent_GetsExistingStudentFromOneElementStudentsDictionary_ReturnedProperStudentAndStudentsDictionaryIsUnchanged()
		{
			var @class = new Class("1a");
			var student = new Student(1);
			var studentsDictionary = @class.StudentsDictionary;
			_ = studentsDictionary.Add(student);

			Assert.AreEqual(student, @class.GetStudent(1));

			CollectionAssert.AreEqual(new IntList { 1 },
									  studentsDictionary.Keys);
			CollectionAssert.AreEqual(new StudentList { student },
									  studentsDictionary.Values);
			Assert.AreEqual(student, studentsDictionary[1]);
		}

		[Test]
		public static void GetStudent_GetsExistingStudentFromMultipleElementsStudentsDictionary_ReturnedProperStudentAndStudentsDictionaryIsUnchanged()
		{
			var @class = new Class("1a");
			var student1 = new Student(1);
			var student2 = new Student(2);
			var studentsDictionary = @class.StudentsDictionary;
			_ = studentsDictionary.Add(student1);
			_ = studentsDictionary.Add(student2);

			Assert.AreEqual(student1, @class.GetStudent(1));

			CollectionAssert.AreEqual(new IntList { 1, 2 },
									  studentsDictionary.Keys);
			CollectionAssert.AreEqual(new StudentList { student1, student2 },
									  studentsDictionary.Values);
			Assert.AreEqual(student1, studentsDictionary[1]);
			Assert.AreEqual(student2, studentsDictionary[2]);
		}
	}
}
