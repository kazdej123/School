using NUnit.Framework;
using System;

namespace School.Tests
{
	internal sealed class StudentTests
	{
		/**
		 * Tests for Student.Student(int? studentId) constructor.
		 **/

		[Test]
		public static void Student_TriesToCallConstructorWithNullStudentId_ThrownNullArgumentException()
		{
			_ = Assert.Throws<ArgumentNullException>(() => new Student(null));
		}

		[Test]
		public static void Student_TriesToCallConstructorWithNotNullNegativeStudentId_ThrownArgumentOutOfRangeException()
		{
			_ = Assert.Throws<ArgumentOutOfRangeException>(
				() => new Student(-1)
			);
		}

		[Test]
		public static void Class_CallsConstructorWithNotNullZeroStudentId_ThrownNoExceptions()
		{
			Assert.DoesNotThrow(() => new Student(0));
		}

		[Test]
		public static void Class_CallsConstructorWithNotNullPositiveStudentId_ThrownNoExceptions()
		{
			Assert.DoesNotThrow(() => new Student(1));
		}


		/**
		 * Tests for Student.Id get-property.
		 **/

		[Test]
		public static void Id_GetsZeroId_ReturnedZero()
		{
			Assert.AreEqual(0, new Student(0).Id);
		}

		[Test]
		public static void Id_GetsPositiveId_ReturnedProperId()
		{
			Assert.AreEqual(1, new Student(1).Id);
		}


		/**
		 * Tests for Student.Name property.
		 **/

		[Test]
		public static void Name_TriesToSetNullStudentName_ThrownArgumentNullException()
		{
			_ = Assert.Throws<ArgumentNullException>(
				() => new Student(1).Name = null
			);
		}

		[Test]
		public static void Name_GetsDefaultStudentName_ReturnedProperName()
		{
			Assert.AreEqual("", new Student(1).Name);
		}

		[Test]
		public static void Name_SetsAndGetsNotNullStudentName_ThrownNoExceptionsAndReturnedProperName()
		{
			var student = new Student(1);

			Assert.DoesNotThrow(() => student.Name = "Jacek");
			Assert.AreEqual("Jacek", student.Name);
		}
	}
}
