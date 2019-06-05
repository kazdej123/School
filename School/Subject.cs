using System;
using System.Collections.Generic;

namespace School
{
	public sealed class Subject : SchoolObject
	{
		private int _teachersCounter = 0;

		public int LessonsNumber { set; get; }

		public int TasksNumber { set; get; }

		public Dictionary<int, Teacher> TeachersDictionary { get; }
			= new Dictionary<int, Teacher>();

		public bool AddTeacher(Teacher teacher)
		{
			try {
				TeachersDictionary.Add(teacher.Id, teacher);
				return true;
			} catch (ArgumentException) {
				return false;
			}
		}

		public bool AddTeacher()
		{
			try {
				TeachersDictionary.Add(++_teachersCounter, new Teacher());
				return true;
			} catch (ArgumentException) {
				return false;
			}
		}

		public bool RemoveTeacher(int teacherId)
		{
			return TeachersDictionary.Remove(teacherId);
		}

		public Teacher GetTeacher(int teacherId)
		{
			_ = TeachersDictionary.TryGetValue(teacherId, out Teacher teacher);
			return teacher;
		}
	}
}