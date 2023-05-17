using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.libs 
{
	public class Application
	{
		private Login login;
		
		public Application()
		{
			User.Register(new User(0, "Matheus Macedo", "matheus@email.com", "123456"));
			
			bool systemOpened = loginArea();
			if (systemOpened) 
			{
				Console.WriteLine($"The system has been opened!");
			}
		}
		
		private bool loginArea() 
		{
			Console.Write($"Email: ");
			string email = Console.ReadLine();
			
			Console.Write($"Password: ");
			string password = Console.ReadLine();
			
			login = new Login();
			
			string loginResponse = login.turnLoggedIn(email, password);
			Console.WriteLine(loginResponse);
			
			return login.IsLoggedIn;
		}
	}
}