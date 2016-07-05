Example of get only interger Ids fields from a collection of User objects.
	
	var users = new List<User>
	{
		 new User {Id=1, FirstName="George", LastName="Washington"},
		 new User {Id=2, FirstName="John", LastName="Adam"},
		 new User {Id=3, FirstName="Thomas", LastName="Jefferson"},
		 new User {Id=4, FirstName="John", LastName="Kennedy"},
		 new User {Id=5, FirstName="Theodor", LastName="Roosevelt"},
		 new User {Id=6, FirstName="Ronald", LastName="Reagan"}
	};
	
	var ids = (from u in users
	          select u.Id).ToList(); // select only
			  
	public class User
	{
	   public int Id {get; set;}
	   public string FirstName {get; set;}
	   public string LastName {get;set;}
	   public double Salary {get;set;}
	}
