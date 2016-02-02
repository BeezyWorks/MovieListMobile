
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BusinessLayer;
using BusinessLayer.Models;

namespace MovieList.Droid
{
	[Activity (Label = "ActorDetail")]			

	public class ActorDetailActivity : Activity{
		
		TextView Name;
		TextView Description;
		TextView DateOfBirth;
		ListView MoviesList;

		Actor detailedActor;
		DataManager dataManager;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.actorDetailLayout);

			int selected = Intent.GetIntExtra ("selectKey", 0);

			dataManager = DataManager.Instance;
			detailedActor = dataManager.GetActorById (selected);

			Name = FindViewById<TextView> (Resource.Id.name);
			Description = FindViewById<TextView> (Resource.Id.description);
			DateOfBirth = FindViewById<TextView> (Resource.Id.dateofbirth);
			MoviesList = FindViewById<ListView> (Resource.Id.moviesList);

			Name.Text = detailedActor.name;
			Description.Text = detailedActor.bio;
			DateOfBirth.Text = String.Format ("Born on: {0}",detailedActor.dateofbirth.ToString ("d"));

			AddMovies ();
		}

		private async void AddMovies(){
			List<Movie> movies = await dataManager.GetAllMoviesWithActor (detailedActor);
			MoviesList.Adapter = new MovieAdapter (this, movies.ToArray ());
			MoviesList.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) => {
				int position = e.Position;
				Intent intent = new Intent(this, typeof(MovieDetailActivity));
				intent.PutExtra ("selectKey", movies.ToArray ()[position].id);
				StartActivity (intent);
			};
		}
	}
}

