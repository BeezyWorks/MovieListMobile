using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using BusinessLayer;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using XamarinItemTouchHelper;

namespace MovieList.Droid
{
	[Activity (Label = "MovieList.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : AppCompatActivity
	{
		DataManager dataManager;

		RecyclerView recyclerView;
		LinearLayoutManager mLayoutManager;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.main_activity);
			dataManager = DataManager.Instance;
//			if (dataManager.CurrentUser == null) {
//				StartActivity (new Intent (this, typeof(LoginActivity)));
//			}
			recyclerView = FindViewById<RecyclerView> (Resource.Id.recyclerView);
			mLayoutManager = new LinearLayoutManager (this);
			recyclerView.SetLayoutManager (mLayoutManager);
			ApplyAdapter ();
		}

		protected async void ApplyAdapter ()
		{
			var progressDialog = ProgressDialog.Show (this, "Please wait...", "Loading movies", true);
			await dataManager.RefreshDataSet ();
			progressDialog.Dismiss ();
			MoviesRecyeclerAdapter adapter = new MoviesRecyeclerAdapter (this, dataManager.Movies);
			recyclerView.SetAdapter (adapter);
		}





	}


}

