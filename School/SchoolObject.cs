namespace School
{
	public class SchoolObject<T>
	{
		private protected SchoolObject(T uniqueId)
		{
			if (uniqueId != null) {
				UniqueId = uniqueId;
			} else {
				throw new System.ArgumentNullException();
			}
		}

		protected internal T UniqueId { get; }
	}
}
