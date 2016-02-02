using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using BusinessLayer;

namespace MovieList.Droid
{
	[Activity (Label = "MovieList.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : Activity
	{
		DataManager dataManager;
		ListView listView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.main_activity);
			dataManager = DataManager.Instance;
			if (dataManager.CurrentUser == null) {
				StartActivity (new Intent (this, typeof(LoginActivity)));
//				Finish ();
			}
			listView = FindViewById<ListView> (Resource.Id.listView);
			ApplyAdapter ();
		}

		protected async void ApplyAdapter ()
		{
			var progressDialog = ProgressDialog.Show (this, "Please wait...", "Loading movies", true);
			await dataManager.RefreshDataSet ();
			progressDialog.Dismiss ();
			listView.Adapter = new MovieAdapter (this, dataManager.Movies.ToArray ());
			listView.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) => {
				int position = e.Position;
				Intent intent = new Intent (this, typeof(MovieDetailActivity));
				intent.PutExtra ("selectKey", dataManager.Movies.ToArray () [position].id);
				StartActivity (intent);
			};

			listView.ItemLongClick += (object sender, AdapterView.ItemLongClickEventArgs e) => {
				new AlertDialog.Builder (this)
			.SetMessage (String.Format ("Are you sure you want to delete {0}?", dataManager.Movies.ToArray () [e.Position].name))
			.SetPositiveButton ("Delete", (object uSender, DialogClickEventArgs uE) => 
						DeleteMovie (e.Position)
				)
			.Create ().Show ();
				
			};
		}

		private async void DeleteMovie (int position)
		{
			Boolean success = await dataManager.DeleteMovie (dataManager.Movies.ToArray () [position]);
			if (success) {
				listView.Adapter = new MovieAdapter (this, dataManager.Movies.ToArray ());
			} else {
				Toast.MakeText (this, "Failed to Delete", ToastLength.Short).Show ();
			}

		}
	}
}

