using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using BusinessLayer.Models;

namespace MovieList.Droid
{
	public class MovieAdapter : BaseAdapter<Movie>
	{
		Movie[] items;
		Activity context;
		public MovieAdapter(Activity context, Movie[] items) : base() {
			this.context = context;
			this.items = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}




		public override Movie this [int position] {
			get {
				return items [position]; 
			}
		}


		public override int Count {
			get { return items.Length; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
			view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position].name;
			return view;
		}
	}
}

