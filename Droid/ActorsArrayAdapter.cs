﻿using System;
using Android.Widget;
using BusinessLayer.Models;
using Android.App;
using Android.Views;

namespace MovieList.Droid
{
	public class ActorsArrayAdapter: BaseAdapter<Actor>
	{
		Actor[] items;
		Activity context;
		public ActorsArrayAdapter(Activity context, Actor[] items) : base() {
			this.context = context;
			this.items = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}




		public override Actor this [int position] {
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

