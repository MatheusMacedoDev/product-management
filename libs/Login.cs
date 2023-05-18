namespace ProductManagement.libs 
{
	public class Login
	{
		public User? LoggedInUser { get; private set; }
		public bool IsLoggedIn { get; private set; }
		
		public Login()
		{
			this.IsLoggedIn = false;
		}
		
		public string turnLoggedIn(string email, string password) 
		{
			List<User> users = User.List();
			User findedUser = users.Find(user => user.Email == email);
			
			if (findedUser != null) 
			{
				if (findedUser.TryPassword(password)) 
				{
					LoggedInUser = findedUser;
					IsLoggedIn = true;
					return $"The user has been logged in!";
				}
				else 
				{
					return $"Incorrect password!";
				}
			}
			else 
			{
				return "There is no user with this email!";
			}
			
		}
		
		public string turnLoggedOut() 
		{
			LoggedInUser = null;
			IsLoggedIn = false;
			return $"The user has been logged out!";
		}
	}
}