using System;

namespace School
{
	public class SchoolHuman : SchoolObject<int?>
	{
		private string _name = "";

		private protected SchoolHuman(int? uniqueId) : base(uniqueId)
		{
			if (uniqueId < 0) {
				throw new ArgumentOutOfRangeException();
			}
		}

		public int? Id => UniqueId;

		public string Name {
			get => _name;
			set {
				if (value != null) {
					_name = value;
				} else {
					throw new ArgumentNullException();
				}
			}
		}
	}
}
