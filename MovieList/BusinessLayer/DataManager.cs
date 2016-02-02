using System;
using System.Collections.Generic;
using BusinessLayer.Models;
using ServerAccessLayer;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace BusinessLayer
{
	public class DataManager
	{
		private static DataManager instance;
		private BaseSereverAccessor serverAccessor;

		public List<Movie> Movies{ get; private set; }

		public List<Actor> Actors{ get; private set; }

		public User CurrentUser{ get; set; }

		public static DataManager Instance {
			get {
				if (instance == null) {
					instance = new DataManager ();
				}
				return instance;
			}
		}


		private DataManager ()
		{
			serverAccessor = new BaseSereverAccessor ();
		}

		public async Task RefreshDataSet ()
		{
			Actors = await serverAccessor.GetAllActors ();
			Movies = await serverAccessor.GetAllMovies ();
		}

		public Actor GetActorById (int id)
		{
			foreach (Actor actor in this.Actors) {
				if (actor.id == id)
					return actor;
			}
			return null;
		}

		public Movie GetMovieById (int id)
		{
			foreach (Movie movie in this.Movies) {
				if (movie.id == id)
					return movie;
			}
			return null;
		}

		public Task<List<Actor>> GetAllActorsForMovie (Movie Movie)
		{
			return serverAccessor.GetAllActorsInMovie (Movie);
		}

		public Task<List<Movie>> GetAllMoviesWithActor (Actor Actor)
		{
			return serverAccessor.GetAllMoviesWithActor (Actor);
		}

		public Task<HttpResponseMessage> SignInUser (User newUser)
		{
			return serverAccessor.SignInUser (newUser, Constants.LoginMethod);
		}

		public Task<HttpResponseMessage> SignUpNewUser (User newUser)
		{
			return serverAccessor.SignInUser (newUser, Constants.SignUpMethod);
		}

		public async Task<Boolean> DeleteMovie (Movie movie)
		{
			HttpResponseMessage response = await serverAccessor.DeleteObject (Constants.DeleteMovieMethod, movie.id);
			if (response.IsSuccessStatusCode) {
				this.Movies.Remove (movie);
				return true;
			}
			Debug.WriteLine (String.Format ("Delete movie failed: {0}"), response.ToString ());
			return false;
		}
	}
}

