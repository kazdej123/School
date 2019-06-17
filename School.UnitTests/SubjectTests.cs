using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace School.Tests
{
	internal sealed class SubjectTests
	{
		private sealed class IntList : List<int> { }

		private sealed class TeacherList : List<Teacher> { }


		/**
		 * Tests for Subject.Subject(string subjectName) constructor.
		 **/

		[Test]
		public static void Subject_TriesToCallConstructorWithNullSubjectName_ThrownNullArgumentException()
		{
			_ = Assert.Throws<ArgumentNullException>(() => new Subject(null));
		}

		[Test]
		public static void Subject_CallsConstructorWithNotNullSubjectName_ThrownNoExceptions()
		{
			Assert.DoesNotThrow(() => new Subject("matematyka"));
		}


		/**
		 * Tests for Subject.Name get-property.
		 **/

		[Test]
		public static void Name_GetsName_ReturnedProperName()
		{
			Assert.AreEqual("matematyka", new Subject("matematyka").Name);
		}


		/**
		 * Tests for Subject.LessonsNumber property.
		 **/

		[Test]
		public static void LessonsNumber_TriesToSetNegativeLessonsNumber_ThrownArgumentOutOfRangeException()
		{
			_ = Assert.Throws<ArgumentOutOfRangeException>(
				() => new Subject("matematyka").LessonsNumber = -1
			);
		}

		[Test]
		public static void LessonsNumber_SetsAndGetsZeroLessonsNumber_ThrownNoExceptionsAndReturnedZero()
		{
			var subject = new Subject("matematyka");

			Assert.DoesNotThrow(() => subject.LessonsNumber = 0);
			Assert.AreEqual(0, subject.LessonsNumber);
		}

		[Test]
		public static void LessonsNumber_SetsAndGetsPositiveLessonsNumber_ThrownNoExceptionsAndReturnedProperNumber()
		{
			var subject = new Subject("matematyka");

			Assert.DoesNotThrow(() => subject.LessonsNumber = 1);
			Assert.AreEqual(1, subject.LessonsNumber);
		}


		/**
		 * Tests for Subject.TasksNumber property.
		 **/

		[Test]
		public static void TasksNumber_TriesToSetNegativeTasksNumber_ThrownArgumentOutOfRangeException()
		{
			_ = Assert.Throws<ArgumentOutOfRangeException>(
				() => new Subject("matematyka").TasksNumber = -1
			);
		}

		[Test]
		public static void TasksNumber_SetsAndGetsZeroTasksNumber_ThrownNoExceptionsAndReturnedZero()
		{
			var subject = new Subject("matematyka");

			Assert.DoesNotThrow(() => subject.TasksNumber = 0);
			Assert.AreEqual(0, subject.TasksNumber);
		}

		[Test]
		public static void TasksNumber_SetsAndGetsPositiveTasksNumber_ThrownNoExceptionsAndReturnedProperNumber()
		{
			var subject = new Subject("matematyka");

			Assert.DoesNotThrow(() => subject.TasksNumber = 1);
			Assert.AreEqual(1, subject.TasksNumber);
		}


		/**
		 * Tests for Subject.AddTeacher(Teacher teacher) method.
		 **/

		[Test]
		public static void AddTeacher_TriesToAddNullTeacherToEmptyTeachersDictionary_ReturnedFalseAndTeachersDictionaryIsEmpty()
		{
			var subject = new Subject("matematyka");

			Assert.IsFalse(subject.AddTeacher((Teacher)null));

			CollectionAssert.IsEmpty(subject.TeachersDictionary);
		}

		[Test]
		public static void AddTeacher_TriesToAddNullTeacherToNotEmptyTeachersDictionary_ReturnedFalseAndTeachersDictionaryEqualsToProper()
		{
			var subject = new Subject("matematyka");
			var teacher = new Teacher(1);
			var teachersDictionary = subject.TeachersDictionary;
			_ = teachersDictionary.Add(teacher);

			Assert.IsFalse(subject.AddTeacher((Teacher)null));

			CollectionAssert.AreEqual(new IntList { 1 },
									  teachersDictionary.Keys);
			CollectionAssert.AreEqual(new TeacherList { teacher },
									  teachersDictionary.Values);
			Assert.AreEqual(teacher, teachersDictionary[1]);
		}

		[Test]
		public static void AddTeacher_TriesToAddNotNullTeacherWithNullIdToEmptyTeachersDictionary_ThrownArgumentNullExceptionAndTeachersDictionaryIsEmpty()
		{
			var subject = new Subject("matematyka");

			_ = Assert.Throws<ArgumentNullException>(
				() => subject.AddTeacher(new Teacher(null))
			);

			CollectionAssert.IsEmpty(subject.TeachersDictionary);
		}

		[Test]
		public static void AddTeacher_TriesToAddNotNullTeacherWithNullIdToNotEmptyTeachersDictionary_ThrownArgumentNullExceptionAndTeachersDictionaryEqualsToProper()
		{
			var subject = new Subject("matematyka");
			var teacher = new Teacher(1);
			var teachersDictionary = subject.TeachersDictionary;
			_ = teachersDictionary.Add(teacher);

			_ = Assert.Throws<ArgumentNullException>(
				() => subject.AddTeacher(new Teacher(null))
			);

			CollectionAssert.AreEqual(new IntList { 1 },
									  teachersDictionary.Keys);
			CollectionAssert.AreEqual(new TeacherList { teacher },
									  teachersDictionary.Values);
			Assert.AreEqual(teacher, teachersDictionary[1]);
		}

		[Test]
		public static void AddTeacher_AddsNotNullTeacherToEmptyTeachersDictionary_ReturnedTrueAndTeachersDictionaryEqualsToProper()
		{
			var subject = new Subject("matematyka");
			var teacher = new Teacher(1);
			var teachersDictionary = subject.TeachersDictionary;

			Assert.IsTrue(subject.AddTeacher(teacher));

			CollectionAssert.AreEqual(new IntList { 1 },
									  teachersDictionary.Keys);
			CollectionAssert.AreEqual(new TeacherList { teacher },
									  teachersDictionary.Values);
			Assert.AreEqual(teacher, teachersDictionary[1]);
		}

		[Test]
		public static void AddTeacher_TriesToAddNotNullNotUniqueTeacherToNotEmptyTeachersDictionary_ReturnedFalseAndTeachersDictionaryEqualsToProper()
		{
			var subject = new Subject("matematyka");
			var teacher = new Teacher(1);
			var teachersDictionary = subject.TeachersDictionary;
			_ = teachersDictionary.Add(teacher);

			Assert.IsFalse(subject.AddTeacher(new Teacher(1)));

			CollectionAssert.AreEqual(new IntList { 1 },
									  teachersDictionary.Keys);
			CollectionAssert.AreEqual(new TeacherList { teacher },
									  teachersDictionary.Values);
			Assert.AreEqual(teacher, teachersDictionary[1]);
		}

		[Test]
		public static void AddTeacher_AddsNotNullUniqueTeacherToNotEmptyTeachersDictionary_ReturnedTrueAndTeachersDictionaryEqualsToProper()
		{
			var subject = new Subject("matematyka");
			var teacher1 = new Teacher(1);
			var teacher2 = new Teacher(2);
			var teachersDictionary = subject.TeachersDictionary;
			_ = teachersDictionary.Add(teacher1);

			Assert.IsTrue(subject.AddTeacher(teacher2));

			CollectionAssert.AreEqual(new IntList { 1, 2 },
									  teachersDictionary.Keys);
			CollectionAssert.AreEqual(new TeacherList { teacher1, teacher2 },
									  teachersDictionary.Values);
			Assert.AreEqual(teacher1, teachersDictionary[1]);
			Assert.AreEqual(teacher2, teachersDictionary[2]);
		}


		/**
		 * Tests for Subject.AddTeacher(int? teacherId) method.
		 **/

		[Test]
		public static void AddTeacher_TriesToAddTeacherWithNullIdToEmptyTeachersDictionary_ThrownArgumentNullExceptionAndTeachersDictionaryIsEmpty()
		{
			var subject = new Subject("matematyka");

			_ = Assert.Throws<ArgumentNullException>(
				() => subject.AddTeacher((int?)null)
			);

			CollectionAssert.IsEmpty(subject.TeachersDictionary);
		}

		[Test]
		public static void AddTeacher_TriesToAddTeacherWithNullIdToNotEmptyTeachersDictionary_ThrownArgumentNullExceptionAndTeachersDictionaryEqualsToProper()
		{
			var subject = new Subject("matematyka");
			var teacher = new Teacher(1);
			var teachersDictionary = subject.TeachersDictionary;
			_ = teachersDictionary.Add(teacher);

			_ = Assert.Throws<ArgumentNullException>(
				() => subject.AddTeacher((int?)null)
			);

			CollectionAssert.AreEqual(new IntList { 1 },
									  teachersDictionary.Keys);
			CollectionAssert.AreEqual(new TeacherList { teacher },
									  teachersDictionary.Values);
			Assert.AreEqual(teacher, teachersDictionary[1]);
		}

		[Test]
		public static void AddTeacher_AddsTeacherWithNotNullIdToEmptyTeachersDictionary_ReturnedTrueAndTeachersDictionaryEqualsToProper()
		{
			var subject = new Subject("matematyka");
			var teachersDictionary = subject.TeachersDictionary;

			Assert.IsTrue(subject.AddTeacher(1));

			CollectionAssert.AreEqual(new IntList { 1 },
									  teachersDictionary.Keys);
			Assert.AreEqual(1, teachersDictionary[1].Id);
		}

		[Test]
		public static void AddTeacher_TriesToAddTeacherWithNotNullNotUniqueIdToNotEmptyTeachersDictionary_ReturnedFalseAndTeachersDictionaryEqualsToProper()
		{
			var subject = new Subject("matematyka");
			var teacher = new Teacher(1);
			var teachersDictionary = subject.TeachersDictionary;
			_ = teachersDictionary.Add(teacher);

			Assert.IsFalse(subject.AddTeacher(new Teacher(1)));

			CollectionAssert.AreEqual(new IntList { 1 },
									  teachersDictionary.Keys);
			CollectionAssert.AreEqual(new TeacherList { teacher },
									  teachersDictionary.Values);
			Assert.AreEqual(teacher, teachersDictionary[1]);
		}

		[Test]
		public static void AddTeacher_AddsTeacherWithNotNullUniqueIdToNotEmptyTeachersDictionary_ReturnedTrueAndTeachersDictionaryEqualsToProper()
		{
			var subject = new Subject("matematyka");
			var teacher = new Teacher(1);
			var teachersDictionary = subject.TeachersDictionary;
			_ = teachersDictionary.Add(teacher);

			Assert.IsTrue(subject.AddTeacher(2));

			CollectionAssert.AreEqual(new IntList { 1, 2 },
									  teachersDictionary.Keys);
			Assert.AreEqual(teacher, teachersDictionary[1]);
			Assert.AreEqual(2, teachersDictionary[2].Id);
		}


		/**
		 * Tests for Subject.RemoveTeacher(int? teacherId) method.
		 **/

		[Test]
		public static void RemoveTeacher_TriesToRemoveTeacherWithNullIdFromEmptyTeachersDictionary_ReturnedFalseAndTeachersDictionaryIsEmpty()
		{
			var subject = new Subject("matematyka");

			Assert.IsFalse(subject.RemoveTeacher(null));

			CollectionAssert.IsEmpty(subject.TeachersDictionary);
		}

		[Test]
		public static void RemoveTeacher_TriesToRemoveTeacherWithNullIdFromNotEmptyTeachersDictionary_ReturnedFalseAndTeachersDictionaryEqualsToProper()
		{
			var subject = new Subject("matematyka");
			var teacher = new Teacher(1);
			var teachersDictionary = subject.TeachersDictionary;
			_ = teachersDictionary.Add(teacher);

			Assert.IsFalse(subject.RemoveTeacher(null));

			CollectionAssert.AreEqual(new IntList { 1 },
									  teachersDictionary.Keys);
			CollectionAssert.AreEqual(new TeacherList { teacher },
									  teachersDictionary.Values);
			Assert.AreEqual(teacher, teachersDictionary[1]);
		}

		[Test]
		public static void RemoveTeacher_TriesToRemoveTeacherWithNotNullIdFromEmptyTeachersDictionary_ReturnedFalseAndTeachersDictionaryIsEmpty()
		{
			var subject = new Subject("matematyka");

			Assert.IsFalse(subject.RemoveTeacher(1));

			CollectionAssert.IsEmpty(subject.TeachersDictionary);
		}

		[Test]
		public static void RemoveTeacher_TriesToRemoveNotExistingTeacherWithNotNullIdFromNotEmptyTeachersDictionary_ReturnedFalseAndTeachersDictionaryEqualsToProper()
		{
			var subject = new Subject("matematyka");
			var teacher = new Teacher(1);
			var teachersDictionary = subject.TeachersDictionary;
			_ = teachersDictionary.Add(teacher);

			Assert.IsFalse(subject.RemoveTeacher(2));

			CollectionAssert.AreEqual(new IntList { 1 },
									  teachersDictionary.Keys);
			CollectionAssert.AreEqual(new TeacherList { teacher },
									  teachersDictionary.Values);
			Assert.AreEqual(teacher, teachersDictionary[1]);
		}

		[Test]
		public static void RemoveTeacher_RemovesExistingTeacherFromOneElementTeachersDictionary_ReturnedTrueAndTeachersDictionaryIsEmpty()
		{
			var subject = new Subject("matematyka");
			var teachersDictionary = subject.TeachersDictionary;
			_ = teachersDictionary.Add(new Teacher(1));

			Assert.IsTrue(subject.RemoveTeacher(1));

			CollectionAssert.IsEmpty(teachersDictionary);
		}

		[Test]
		public static void RemoveTeacher_RemovesExistingTeacherFromMultipleElementsTeachersDictionary_ReturnedTrueAndTeachersDictionaryEqualsToProper()
		{
			var subject = new Subject("matematyka");
			var teacher = new Teacher(2);
			var teachersDictionary = subject.TeachersDictionary;
			_ = teachersDictionary.Add(new Teacher(1));
			_ = teachersDictionary.Add(teacher);

			Assert.IsTrue(subject.RemoveTeacher(1));

			CollectionAssert.AreEqual(new IntList { 2 },
									  teachersDictionary.Keys);
			CollectionAssert.AreEqual(new TeacherList { teacher },
									  teachersDictionary.Values);
			Assert.AreEqual(teacher, teachersDictionary[2]);
		}


		/**
		 * Tests for Subject.GetTeacher(int? teacherId) method.
		 **/

		[Test]
		public static void GetTeacher_TriesToGetTeacherWithNullIdFromEmptyTeachersDictionary_ReturnedNullAndTeachersDictionaryIsEmpty()
		{
			var subject = new Subject("matematyka");

			Assert.IsNull(subject.GetTeacher(null));

			CollectionAssert.IsEmpty(subject.TeachersDictionary);
		}

		[Test]
		public static void GetTeacher_TriesToGetTeacherWithNullIdFromNotEmptyTeachersDictionary_ReturnedNullAndTeachersDictionaryIsUnchanged()
		{
			var subject = new Subject("matematyka");
			var teacher = new Teacher(1);
			var teachersDictionary = subject.TeachersDictionary;
			_ = teachersDictionary.Add(teacher);

			Assert.IsNull(subject.GetTeacher(null));

			CollectionAssert.AreEqual(new IntList { 1 },
									  teachersDictionary.Keys);
			CollectionAssert.AreEqual(new TeacherList { teacher },
									  teachersDictionary.Values);
			Assert.AreEqual(teacher, teachersDictionary[1]);
		}

		[Test]
		public static void GetTeacher_TriesToGetTeacherWithNotNullIdFromEmptyTeachersDictionary_ReturnedNullAndTeachersDictionaryIsEmpty()
		{
			var subject = new Subject("matematyka");

			Assert.IsNull(subject.GetTeacher(1));

			CollectionAssert.IsEmpty(subject.TeachersDictionary);
		}

		[Test]
		public static void GetTeacher_TriesToGetNotExistingTeacherWithNotNullIdFromNotEmptyTeachersDictionary_ReturnedNullAndTeachersDictionaryIsUnchanged()
		{
			var subject = new Subject("matematyka");
			var teacher = new Teacher(1);
			var teachersDictionary = subject.TeachersDictionary;
			_ = teachersDictionary.Add(teacher);

			Assert.IsNull(subject.GetTeacher(2));

			CollectionAssert.AreEqual(new IntList { 1 },
									  teachersDictionary.Keys);
			CollectionAssert.AreEqual(new TeacherList { teacher },
									  teachersDictionary.Values);
			Assert.AreEqual(teacher, teachersDictionary[1]);
		}

		[Test]
		public static void GetTeacher_GetsExistingTeacherFromOneElementTeachersDictionary_ReturnedProperTeacherAndTeachersDictionaryIsUnchanged()
		{
			var subject = new Subject("matematyka");
			var teacher = new Teacher(1);
			var teachersDictionary = subject.TeachersDictionary;
			_ = teachersDictionary.Add(teacher);

			Assert.AreEqual(teacher, subject.GetTeacher(1));

			CollectionAssert.AreEqual(new IntList { 1 },
									  teachersDictionary.Keys);
			CollectionAssert.AreEqual(new TeacherList { teacher },
									  teachersDictionary.Values);
			Assert.AreEqual(teacher, teachersDictionary[1]);
		}

		[Test]
		public static void GetTeacher_GetsExistingTeacherFromMultipleElementsTeachersDictionary_ReturnedProperTeacherAndTeachersDictionaryIsUnchanged()
		{
			var subject = new Subject("matematyka");
			var teacher1 = new Teacher(1);
			var teacher2 = new Teacher(2);
			var teachersDictionary = subject.TeachersDictionary;
			_ = teachersDictionary.Add(teacher1);
			_ = teachersDictionary.Add(teacher2);

			Assert.AreEqual(teacher1, subject.GetTeacher(1));

			CollectionAssert.AreEqual(new IntList { 1, 2 },
									  teachersDictionary.Keys);
			CollectionAssert.AreEqual(new TeacherList { teacher1, teacher2 },
									  teachersDictionary.Values);
			Assert.AreEqual(teacher1, teachersDictionary[1]);
			Assert.AreEqual(teacher2, teachersDictionary[2]);
		}
	}
}
