using System;
using System.Collections.Generic;

namespace School
{
	public sealed class Class : SchoolObject
	{
		private int _studentsCounter = 0;

		public int TeachersNumber { set; get; } = 0;

		public Dictionary<int, Student> StudentsDictionary { get; }
			= new Dictionary<int, Student>();

		public bool AddStudent(Student student)
		{
			try {
				StudentsDictionary.Add(student.Id, student);
				return true;
			} catch (ArgumentException) {
				return false;
			}
		}

		public bool AddStudent()
		{
			try {
				StudentsDictionary.Add(++_studentsCounter, new Student());
				return true;
			} catch (ArgumentException) {
				return false;
			}
		}

		public bool RemoveStudent(int studentId)
		{
			return StudentsDictionary.Remove(studentId);
		}

		public Student GetStudent(int studentId)
		{
			_ = StudentsDictionary.TryGetValue(studentId, out Student student);
			return student;
		}
	}
}