package md5d3290ee6ca349102245ee05dd3cbc4d1;


public class FlingDetector
	extends android.view.GestureDetector.SimpleOnGestureListener
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onFling:(Landroid/view/MotionEvent;Landroid/view/MotionEvent;FF)Z:GetOnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FFHandler\n" +
			"";
		mono.android.Runtime.register ("MovieList.Droid.FlingDetector, MovieList.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", FlingDetector.class, __md_methods);
	}


	public FlingDetector () throws java.lang.Throwable
	{
		super ();
		if (getClass () == FlingDetector.class)
			mono.android.TypeManager.Activate ("MovieList.Droid.FlingDetector, MovieList.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public FlingDetector (android.support.v4.widget.DrawerLayout p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == FlingDetector.class)
			mono.android.TypeManager.Activate ("MovieList.Droid.FlingDetector, MovieList.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Support.V4.Widget.DrawerLayout, Xamarin.Android.Support.v4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public boolean onFling (android.view.MotionEvent p0, android.view.MotionEvent p1, float p2, float p3)
	{
		return n_onFling (p0, p1, p2, p3);
	}

	private native boolean n_onFling (android.view.MotionEvent p0, android.view.MotionEvent p1, float p2, float p3);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
