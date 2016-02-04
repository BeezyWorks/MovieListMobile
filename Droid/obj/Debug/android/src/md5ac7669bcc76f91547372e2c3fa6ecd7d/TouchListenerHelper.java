package md5ac7669bcc76f91547372e2c3fa6ecd7d;


public class TouchListenerHelper
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnTouchListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouch:(Landroid/view/View;Landroid/view/MotionEvent;)Z:GetOnTouch_Landroid_view_View_Landroid_view_MotionEvent_Handler:Android.Views.View/IOnTouchListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("XamarinItemTouchHelper.TouchListenerHelper, XamarinItemTouchHelper, Version=1.1.2.0, Culture=neutral, PublicKeyToken=null", TouchListenerHelper.class, __md_methods);
	}


	public TouchListenerHelper () throws java.lang.Throwable
	{
		super ();
		if (getClass () == TouchListenerHelper.class)
			mono.android.TypeManager.Activate ("XamarinItemTouchHelper.TouchListenerHelper, XamarinItemTouchHelper, Version=1.1.2.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean onTouch (android.view.View p0, android.view.MotionEvent p1)
	{
		return n_onTouch (p0, p1);
	}

	private native boolean n_onTouch (android.view.View p0, android.view.MotionEvent p1);

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
