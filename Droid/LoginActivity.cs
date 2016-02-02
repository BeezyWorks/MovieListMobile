
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

using BusinessLayer.Models;
using BusinessLayer;
using System.Net.Http;
using Android.Util;
using System.Text.RegularExpressions;
using System.Globalization;

namespace MovieList.Droid
{
	[Activity (Label = "LoginActivity")]			
	public class LoginActivity : Activity
	{
		DataManager dataManager;

		Button SignUpButton;
		Button LogInButton;
		EditText EmailField;
		EditText PasswordField;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.signinLayout);
			dataManager = DataManager.Instance;

			SignUpButton = FindViewById<Button> (Resource.Id.signUpButton);
			LogInButton = FindViewById<Button> (Resource.Id.logInButton);
			EmailField = FindViewById<EditText> (Resource.Id.emailField);
			PasswordField = FindViewById<EditText> (Resource.Id.passwordField);

			SignUpButton.Click += (object sender, EventArgs e) => {
				User newUser = new User ();
				newUser.email = EmailField.Text.Trim ();
				newUser.password = PasswordField.Text;
				SignUpUser (newUser);
			};

			LogInButton.Click += (object sender, EventArgs e) => {
				User newUser = new User ();
				newUser.email = EmailField.Text.Trim ();
				newUser.password = PasswordField.Text;
				LogInUser (newUser);
			};
		}



		private async void SignUpUser (User user)
		{
			var progressDialog = ProgressDialog.Show (this, "Please wait...", "Signing up", true);
			HttpResponseMessage response = await dataManager.SignUpNewUser (user);
			progressDialog.Dismiss ();
			if (response.IsSuccessStatusCode) {
				dataManager.CurrentUser = user;
				Log.Debug ("User Login", String.Format ("Success {0}", response.ToString ()));
				StartActivity (new Intent (this, typeof(MainActivity)));
			} else {
				Toast.MakeText (this, "Please enter valid email and password", ToastLength.Short).Show ();
			}
		}

		private async void LogInUser (User user)
		{
			var progressDialog = ProgressDialog.Show (this, "Please wait...", "Logging in", true);
			HttpResponseMessage response = await dataManager.SignInUser (user);
			progressDialog.Dismiss ();
			if (response.IsSuccessStatusCode) {
				dataManager.CurrentUser = user;
				Log.Debug ("User Login", String.Format ("Success {0}", response.ToString ()));
				StartActivity (new Intent (this, typeof(MainActivity)));
			} else {
				Toast.MakeText (this, "Invalid email or password", ToastLength.Short).Show ();
			}
		}
	}
}

