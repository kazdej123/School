namespace School
{
	public sealed class Class : SchoolObject<string>
	{
		private int _teachersNumber;

		public Class(string className) : base(className) { }

		public NullableIntStudentDictionary StudentsDictionary { get; }
			= new NullableIntStudentDictionary();

		public string Name => UniqueId;

		public int TeachersNumber {
			get => _teachersNumber;
			set {
				if (value >= 0) {
					_teachersNumber = value;
				} else {
					throw new System.ArgumentOutOfRangeException();
				}
			}
		}

		public bool AddStudent(Student student)
			=> StudentsDictionary.Add(student);

		public bool AddStudent(int? studentId)
			=> StudentsDictionary.Add(new Student(studentId));

		public bool RemoveStudent(int? studentId)
			=> StudentsDictionary.Remove(studentId);

		public Student GetStudent(int? studentId)
			=> StudentsDictionary.Get(studentId);
	}
}