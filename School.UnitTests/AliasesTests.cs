using NUnit.Framework;

namespace School.Tests
{
	internal sealed class AliasesTests
	{
		[Test]
		public static void StringClassDictionary_CallsConstructor_ThrownNoExceptions()
		{
			Assert.DoesNotThrow(() => new StringClassDictionary());
		}

		[Test]
		public static void NullableIntStudentDictionary_CallsConstructor_ThrownNoExceptions()
		{
			Assert.DoesNotThrow(() => new NullableIntStudentDictionary());
		}

		[Test]
		public static void StringSubjectDictionary_CallsConstructor_ThrownNoExceptions()
		{
			Assert.DoesNotThrow(() => new StringSubjectDictionary());
		}

		[Test]
		public static void NullableIntTeacherDictionary_CallsConstructor_ThrownNoExceptions()
		{
			Assert.DoesNotThrow(() => new NullableIntTeacherDictionary());
		}
	}
}