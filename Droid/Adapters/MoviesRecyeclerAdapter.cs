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
using System.Collections.Generic;
using BusinessLayer.Models;
using Android.Support.V7.Widget.Helper;
using Android.Support.V4.Widget;
using XamarinItemTouchHelper;
using Android.Support.V4.View;

namespace MovieList.Droid
{
	public class MoviesRecyeclerAdapter : RecyclerView.Adapter
	{
		public List<Movie> Movies{ get; set; }

		protected Context context;


		public MoviesRecyeclerAdapter (Context context, List<Movie> movies)
		{
			Movies = movies;
			this.context = context;
		}


		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			MovieViewHolder mHolder = holder as MovieViewHolder;
			mHolder.Movie = Movies.ToArray () [position];
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{
			View itemView = LayoutInflater.From (parent.Context).
                    Inflate (Resource.Layout.movieViewHolderLayout, parent, false);
			MovieViewHolder vh = new MovieViewHolder (itemView, this);
			return vh;
		}

		public override int ItemCount {
			get {
				return Movies.Count;
			}
		}

	}

	internal class MovieViewHolder : RecyclerView.ViewHolder, ViewPager.IOnPageChangeListener, IDialogInterfaceOnDismissListener
	{
		private Movie _movie;
		MoviesRecyeclerAdapter parentAdapter;
		ValuePagerAdapter adapter;
		private Context _context;
		ViewPager viewPager;

		public MovieViewHolder (View itemView, MoviesRecyeclerAdapter parentAdapter) : base (itemView)
		{
			_context = itemView.Context;
			this.parentAdapter = parentAdapter;
			viewPager = itemView.FindViewById<ViewPager> (Resource.Id.viewPager).JavaCast<ViewPager> ();
			adapter = new ValuePagerAdapter (itemView.Context);
			viewPager.Adapter = adapter;
			viewPager.AddOnPageChangeListener (this);
			viewPager.SetCurrentItem (1, false);
		}

		public Movie Movie {
			get { return _movie; }
			set {
				_movie = value;
				adapter.Movie = value;
			}
		}

		public void OnPageScrollStateChanged (int state)
		{

		}

		public void OnPageScrolled (int position, float positionOffset, int positionOffsetPixels)
		{

		}

		public void OnPageSelected (int position)
		{
			switch (position) {
			case 0:
				ShowActorsPopup ();
				break;
			case 2:
				DeleteMovieConfirm ();
				break;
			}

		}

		private void DeleteMovieConfirm ()
		{
			new Android.Support.V7.App.AlertDialog.Builder (_context)
			.SetMessage (String.Format ("Are you sure you want to delete {0}?", _movie.name))
			.SetPositiveButton ("Delete", (object uSender, DialogClickEventArgs uE) => 
						DeleteMovie ()
			)
			.SetOnDismissListener (this)
			.Create ().Show ();
				
		}

		public void OnDismiss (IDialogInterface dialog)
		{
			viewPager.SetCurrentItem (1, true);
		}

		private async void DeleteMovie ()
		{
			Boolean success = await DataManager.Instance.DeleteMovie (_movie);
			if (success) {
				parentAdapter.Movies.Remove (_movie);
				parentAdapter.NotifyDataSetChanged ();
			} else {
				Toast.MakeText (_context, "Failed to Delete", ToastLength.Short).Show ();
			}
			viewPager.SetCurrentItem (1, true);

		}

		private async void ShowActorsPopup ()
		{
			var builder = new Android.Support.V7.App.AlertDialog.Builder (_context);
			ListView listView = new ListView (_context);
			List<Actor> actors = await DataManager.Instance.GetAllActorsForMovie (_movie);
			listView.Adapter = new ActorsArrayAdapter (_context as Activity, actors.ToArray ());
			listView.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) => {
				int position = e.Position;
				Intent intent = new Intent (_context, typeof(ActorDetailActivity));
				intent.PutExtra ("selectKey", actors.ToArray () [position].id);
				_context.StartActivity (intent);
			};
			builder.SetView (listView);
			builder.SetOnDismissListener (this);
			builder.Create ().Show ();
		}
	}

	internal class ValuePagerAdapter : PagerAdapter
	{
		Context context;
		private Movie _movie;
		TextView mainTitle;

		public ValuePagerAdapter (Context context)
		{
			this.context = context;
		}



		public override Java.Lang.Object InstantiateItem (ViewGroup container, int position)
		{
			LayoutInflater inflater = LayoutInflater.From (context);
			Java.Lang.Object obj = container;
			var viewPager = obj.JavaCast<ViewGroup> ();

			View layout = (View)inflater.Inflate (Resource.Layout.titlePage, viewPager, false);
			viewPager.AddView (layout);
			TextView title = layout.FindViewById<TextView> (Resource.Id.title);

			switch (position) {
			case 0:
				title.SetBackgroundResource (Resource.Color.green);
				title.Text = "Actors";
				title.Gravity = GravityFlags.Right | GravityFlags.CenterVertical;
				break;
			case 1:
				mainTitle = title;
				if (_movie != null)
					mainTitle.Text = _movie.name;
				mainTitle.Click += (object sender, EventArgs e) => {
					Intent intent = new Intent (container.Context, typeof(MovieDetailActivity));
					intent.PutExtra ("selectKey", _movie.id);
					container.Context.StartActivity (intent);
				};
				break;
			case 2:
				title.SetBackgroundResource (Resource.Color.red);
				title.Text = "Delete";
				break;
			}

			return layout;
		}

		public Movie Movie {
			get { return _movie; }
			set {
				_movie = value;
				if (mainTitle != null)
					mainTitle.Text = value.name;
			}
		}


		public override bool IsViewFromObject (View view, Java.Lang.Object objectValue)
		{
			return view.Equals (objectValue);
		}

		public override void DestroyItem (View container, int position, Java.Lang.Object objectValue)
		{
			
		}

		public override int Count {
			get {
				return 3;
			}
		}

	}


}



