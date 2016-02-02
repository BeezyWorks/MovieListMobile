
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
using Android.Support.V7.App;

namespace MovieList.Droid
{
	[Activity (Label = "MovieDetailActivity")]			
	public class MovieDetailActivity : AppCompatActivity
	{
		DataManager dataManager;
		TextView titleTextView;
		TextView descriptionTextView;
		TextView runtimeTextView;
		ListView actorsListView;

		Movie detailMovie;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.detailLayout);

			int selected = Intent.GetIntExtra ("selectKey", 0);

			dataManager = DataManager.Instance;
			detailMovie = dataManager.GetMovieById (selected);

			titleTextView = FindViewById<TextView> (Resource.Id.movieTitle);
			descriptionTextView = FindViewById<TextView> (Resource.Id.description);
			runtimeTextView = FindViewById<TextView> (Resource.Id.runtime);
			actorsListView = FindViewById<ListView> (Resource.Id.actorsList);

			titleTextView.Text = detailMovie.name;
			descriptionTextView.Text = detailMovie.description;
			runtimeTextView.Text = String.Format ("Runtime: {0} seconds", detailMovie.runtime);

			AddActors ();
		}

		private async void AddActors ()
		{
			List<Actor> actors = await dataManager.GetAllActorsForMovie (detailMovie);
			actorsListView.Adapter = new ActorsArrayAdapter (this, actors.ToArray ());
			actorsListView.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) => {
				int position = e.Position;
				Intent intent = new Intent (this, typeof(ActorDetailActivity));
				intent.PutExtra ("selectKey", actors.ToArray () [position].id);
				StartActivity (intent);
			};
		}
	}
}

