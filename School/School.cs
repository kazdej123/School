using System;
using System.Collections.Generic;

namespace School
{
	public sealed class School
	{
		public Dictionary<string, Class> ClassesDictionary { get; }
			= new Dictionary<string, Class>();

		public Dictionary<string, Subject> SubjectsDictionary { get; }
			= new Dictionary<string, Subject>();

		public bool AddClass(Class @class)
		{
			try {
				ClassesDictionary.Add(@class.Name, @class);
				return true;
			} catch (ArgumentException) {
				return false;
			}
		}

		public bool AddClass(string className)
		{
			try {
				ClassesDictionary.Add(className, new Class());
				return true;
			} catch (ArgumentException) {
				return false;
			}
		}

		public bool RemoveClass(string className)
		{
			return ClassesDictionary.Remove(className);
		}

		public Class GetClass(string className)
		{
			_ = ClassesDictionary.TryGetValue(className, out Class @class);
			return @class;
		}

		public bool AddStudent(Student student)
		{
			return student.Class.AddStudent(student);
		}

		public bool AddStudent(string className)
		{
			return GetClass(className).AddStudent();
		}

		public bool RemoveStudent(int studentId, string className)
		{
			return GetClass(className).RemoveStudent(studentId);
		}

		public Student GetStudent(int studentId, string className)
		{
			return GetClass(className).GetStudent(studentId);
		}

		public Dictionary<int, Student> GetStudentsDictionaryByClass(string className)
		{
			return GetClass(className).StudentsDictionary;
		}

		public Dictionary<KeyValuePair<int, string>, Student> GetAllStudentsDictionary()
		{
			var studentsDictionary = new Dictionary<KeyValuePair<int, string>, Student>();

			foreach (var @class in ClassesDictionary.Values) {
				foreach (var student in @class.StudentsDictionary.Values) {
					try {
						studentsDictionary.Add(new KeyValuePair<int, string>(student.Id, @class.Name), student);
					} catch (ArgumentException) {
						return null;
					}
				}
			}
			return studentsDictionary;
		}

		public bool AddSubject(Subject subject)
		{
			try {
				SubjectsDictionary.Add(subject.Name, subject);
				return true;
			} catch (ArgumentException) {
				return false;
			}
		}

		public bool AddSubject(string subjectName)
		{
			try {
				SubjectsDictionary.Add(subjectName, new Subject());
				return true;
			} catch (ArgumentException) {
				return false;
			}
		}

		public bool RemoveSubject(string subjectName)
		{
			return SubjectsDictionary.Remove(subjectName);
		}

		public Subject GetSubject(string subjectName)
		{
			_ = SubjectsDictionary.TryGetValue(subjectName, out Subject subject);
			return subject;
		}

		public bool AddTeacher(Teacher teacher)
		{
			return teacher.Subject.AddTeacher(teacher);
		}

		public bool AddTeacher(string subjectName)
		{
			return GetSubject(subjectName).AddTeacher();
		}

		public bool RemoveTeacher(int teacherId, string subjectName)
		{
			return GetSubject(subjectName).RemoveTeacher(teacherId);
		}

		public Teacher GetTeacher(int teacherId, string subjectName)
		{
			return GetSubject(subjectName).GetTeacher(teacherId);
		}

		public Dictionary<int, Teacher> GetTeachersDictionaryBySubject(string subjectName)
		{
			return GetSubject(subjectName).TeachersDictionary;
		}

		public Dictionary<KeyValuePair<int, string>, Teacher> GetAllTeachersDictionary()
		{
			var teachersDictionary = new Dictionary<KeyValuePair<int, string>, Teacher>();

			foreach (var subject in SubjectsDictionary.Values) {
				foreach (var teacher in subject.TeachersDictionary.Values) {
					try {
						teachersDictionary.Add(new KeyValuePair<int, string>(teacher.Id, subject.Name), teacher);
					} catch (ArgumentException) {
						return null;
					}
				}
			}
			return teachersDictionary;
		}
	}
}
