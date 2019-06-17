using System;

namespace School
{
	public sealed class Subject : SchoolObject<string>
	{
		private int _lessonsNumber;
		private int _tasksNumber;

		public Subject(string subjectName) : base(subjectName) { }

		public NullableIntTeacherDictionary TeachersDictionary { get; }
			= new NullableIntTeacherDictionary();

		public string Name => UniqueId;

		public int LessonsNumber {
			get => _lessonsNumber;
			set {
				if (value >= 0) {
					_lessonsNumber = value;
				} else {
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public int TasksNumber {
			get => _tasksNumber;
			set {
				if (value >= 0) {
					_tasksNumber = value;
				} else {
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public bool AddTeacher(Teacher teacher)
			=> TeachersDictionary.Add(teacher);

		public bool AddTeacher(int? teacherId)
			=> TeachersDictionary.Add(new Teacher(teacherId));

		public bool RemoveTeacher(int? teacherId)
			=> TeachersDictionary.Remove(teacherId);

		public Teacher GetTeacher(int? teacherId)
			=> TeachersDictionary.Get(teacherId);
	}
}