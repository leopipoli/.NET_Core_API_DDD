namespace Domain.Models
{
    public class UserModel
    {
		private Guid _id;

		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}
	}
}
