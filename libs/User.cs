namespace ProductManagement.libs 
{
	public class User
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public string Email { get; private set; }
		public string Password { get; private set; }
		public DateTime RegistrationDate { get; private set; }

		private static LinkedList<User> users = new LinkedList<User>();
		
		public User(string name, string email, string password) 
		{
			this.Id = users.Count == 0 ? 0 : users.Last().Id + 1;	
			this.Name = name;
			this.Email = email;
			this.Password = password;
			this.RegistrationDate = DateTime.Now;
		}
		
		public static string Register(User user) 
		{
			users.AddLast(user);
			return $"The user ${user.Name} has been registrated!";
		}
		
		public static List<User> List() 
		{
			return users.ToList();
		}
		
		public static string Delete(byte id) 
		{
			User user = users.ToList().Find(user => user.Id == id);
			
			if (user != null) 
			{
				users.Remove(user);
			}
			
			return $"The user ${user.Name} has been deleted!";
		}
		
		public bool TryPassword(string password) 
		{
			return Password == password;
		}
	}
}