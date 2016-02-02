using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using Newtonsoft.Json;

namespace ServerAccessLayer
{

	class GetRequest<T>
	{
		HttpClient client;

		public GetRequest ()
		{
			client = new HttpClient ();
			client.MaxResponseContentBufferSize = 256000;
		}

		public async Task<List<T>> SendGetRequest (string methodName)
		{
			List<T> Items = new List<T> ();

			try {
				var response = await client.GetAsync (Constants.BaseUrl + methodName);
				if (response.IsSuccessStatusCode) {
					var content = await response.Content.ReadAsStringAsync ();
					Items = JsonConvert.DeserializeObject <List<T>> (content);
					return Items;
				}
			} catch (Exception ex) {
				string error = String.Format (@"ERROR {0}", ex.Message);
			}
			return Items;
		}
	}

	public class BaseSereverAccessor
	{
		public Task<List<Actor>> GetAllActors ()
		{
			var request = new GetRequest<Actor> ();
			return request.SendGetRequest ("Actors");
		}

		public Task<List<Movie>> GetAllMovies ()
		{
			var request = new GetRequest<Movie> ();
			return request.SendGetRequest ("Movies");
		}

		public Task<List<Actor>> GetAllActorsInMovie (Movie movie)
		{
			var request = new GetRequest<Actor> ();
			return request.SendGetRequest (String.Format (Constants.ActorsForMovieMethod, movie.id));
		}

		public Task<List<Movie>> GetAllMoviesWithActor (Actor actor)
		{
			var request = new GetRequest<Movie> ();
			return request.SendGetRequest (String.Format (Constants.MoviesWithActorMethod, actor.id));
		}

		public  Task<HttpResponseMessage> SignInUser (User newUser, String method)
		{
			string json = JsonConvert.SerializeObject (newUser);
			var content = new StringContent (json, Encoding.UTF8, "application/json");
			var uri = new Uri (Constants.BaseUrl + method);
			HttpClient client = new HttpClient ();
			try {
				return client.PostAsync (uri, content);
			} catch {
			
			}

			return null;
		}

		public Task<HttpResponseMessage> DeleteObject (string method, int id)
		{
			HttpClient client = new HttpClient ();
			var uri = new Uri (string.Format (Constants.BaseUrl + method, id));
			return client.DeleteAsync (uri);
		}
			
	}
}

