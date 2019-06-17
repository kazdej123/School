namespace School
{
	public sealed class School
	{
		public StringClassDictionary ClassesDictionary { get; }
			= new StringClassDictionary();

		public StringSubjectDictionary SubjectsDictionary { get; }
			= new StringSubjectDictionary();

		public bool AddClass(Class @class)
			=> ClassesDictionary.Add(@class);

		public bool AddClass(string className)
			=> AddClass(new Class(className));

		public bool RemoveClass(string className)
			=> ClassesDictionary.Remove(className);

		public Class GetClass(string className)
			=> ClassesDictionary.Get(className);

		public bool AddStudent(Class @class, Student student)
			=> @class == null ? false : @class.AddStudent(student);

		public bool AddStudent(string className, Student student)
			=> AddStudent(GetClass(className), student);

		public bool RemoveStudent(Class @class, int? studentId)
			=> @class == null ? false : @class.RemoveStudent(studentId);

		public bool RemoveStudent(string className, int? studentId)
			=> RemoveStudent(GetClass(className), studentId);

		public Student GetStudent(Class @class, int? studentId)
			=> @class?.GetStudent(studentId);

		public Student GetStudent(string className, int? studentId)
			=> GetStudent(GetClass(className), studentId);

		public bool AddSubject(Subject subject)
			=> SubjectsDictionary.Add(subject);

		public bool AddSubject(string subjectName)
			=> AddSubject(new Subject(subjectName));

		public bool RemoveSubject(string subjectName)
			=> SubjectsDictionary.Remove(subjectName);

		public Subject GetSubject(string subjectName)
			=> SubjectsDictionary.Get(subjectName);

		public bool AddTeacher(Subject subject, Teacher teacher)
			=> subject == null ? false : subject.AddTeacher(teacher);

		public bool AddTeacher(string subjectName, Teacher teacher)
			=> AddTeacher(GetSubject(subjectName), teacher);

		public bool RemoveTeacher(Subject subject, int? teacherId)
			=> subject == null ? false : subject.RemoveTeacher(teacherId);

		public bool RemoveTeacher(string subjectName, int? teacherId)
			=> RemoveTeacher(GetSubject(subjectName), teacherId);

		public Teacher GetTeacher(Subject subject, int? teacherId)
			=> subject?.GetTeacher(teacherId);

		public Teacher GetTeacher(string subjectName, int? teacherId)
			=> GetTeacher(GetSubject(subjectName), teacherId);
	}
}
