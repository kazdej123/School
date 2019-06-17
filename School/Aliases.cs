namespace School
{
	public sealed class StringClassDictionary
		: GenericDictionary<string, Class> { }

	public sealed class NullableIntStudentDictionary
		: GenericDictionary<int?, Student> { }

	public sealed class StringSubjectDictionary
		: GenericDictionary<string, Subject> { }

	public sealed class NullableIntTeacherDictionary
		: GenericDictionary<int?, Teacher> { }
}
