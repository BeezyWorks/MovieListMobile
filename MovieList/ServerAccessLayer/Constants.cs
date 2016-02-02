using System;

namespace ServerAccessLayer
{
	public static class Constants
	{
		// URL of REST service
		public static string BaseUrl = "http://movielist-beezymovielist.rhcloud.com/api/";
		public static string ActorsForMovieMethod = "Movies/{0}/actors/";
		public static string MoviesWithActorMethod = "Actors/{0}/movies/";
		public static string LoginMethod = "Customers/login";
		public static string SignUpMethod = "Customers";
		public static string DeleteMovieMethod = "Movies/{0}";
		public static string DeleteActorMethod = "Actors/{0}";

	}
}

