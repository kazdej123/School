using NUnit.Framework;
using System;

namespace School.Tests
{
	internal sealed class TeacherTests
	{
		/**
		 * Tests for Teacher.Teacher(int? teacherId) constructor.
		 **/

		[Test]
		public static void Teacher_TriesToCallConstructorWithNullTeacherId_ThrownNullArgumentException()
		{
			_ = Assert.Throws<ArgumentNullException>(() => new Teacher(null));
		}

		[Test]
		public static void Teacher_TriesToCallConstructorWithNotNullNegativeTeacherId_ThrownArgumentOutOfRangeException()
		{
			_ = Assert.Throws<ArgumentOutOfRangeException>(
				() => new Teacher(-1)
			);
		}

		[Test]
		public static void Class_CallsConstructorWithNotNullZeroTeacherId_ThrownNoExceptions()
		{
			Assert.DoesNotThrow(() => new Teacher(0));
		}

		[Test]
		public static void Class_CallsConstructorWithNotNullPositiveTeacherId_ThrownNoExceptions()
		{
			Assert.DoesNotThrow(() => new Teacher(1));
		}


		/**
		 * Tests for Teacher.Id get-property.
		 **/

		[Test]
		public static void Id_GetsZeroId_ReturnedZero()
		{
			Assert.AreEqual(0, new Teacher(0).Id);
		}

		[Test]
		public static void Id_GetsPositiveId_ReturnedProperId()
		{
			Assert.AreEqual(1, new Teacher(1).Id);
		}


		/**
		 * Tests for Teacher.Name property.
		 **/

		[Test]
		public static void Name_TriesToSetNullTeacherName_ThrownArgumentNullException()
		{
			_ = Assert.Throws<ArgumentNullException>(
				() => new Teacher(1).Name = null
			);
		}

		[Test]
		public static void Name_GetsDefaultTeacherName_ReturnedProperName()
		{
			Assert.AreEqual("", new Teacher(1).Name);
		}

		[Test]
		public static void Name_SetsAndGetsNotNullTeacherName_ThrownNoExceptionsAndReturnedProperName()
		{
			var teacher = new Teacher(1);

			Assert.DoesNotThrow(() => teacher.Name = "Jacek");
			Assert.AreEqual("Jacek", teacher.Name);
		}
	}
}
