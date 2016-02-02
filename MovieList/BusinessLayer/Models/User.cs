using System;
using Newtonsoft.Json;

namespace BusinessLayer.Models
{
	public class User
	{
		public int UserId{ get; set;}
		public string email{get; set;}
		public string password{ get; set;}

		public void SignIn(string password){
			

		}

		public void SignOut(){
			
		}

		public void Save (){
		}
	}
}

