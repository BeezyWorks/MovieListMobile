package md5ac7669bcc76f91547372e2c3fa6ecd7d;


public class SimpleItemTouchHelperCallback
	extends android.support.v7.widget.helper.ItemTouchHelper.Callback
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_isLongPressDragEnabled:()Z:GetIsLongPressDragEnabledHandler\n" +
			"n_isItemViewSwipeEnabled:()Z:GetIsItemViewSwipeEnabledHandler\n" +
			"n_getMovementFlags:(Landroid/support/v7/widget/RecyclerView;Landroid/support/v7/widget/RecyclerView$ViewHolder;)I:GetGetMovementFlags_Landroid_support_v7_widget_RecyclerView_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler\n" +
			"n_onMove:(Landroid/support/v7/widget/RecyclerView;Landroid/support/v7/widget/RecyclerView$ViewHolder;Landroid/support/v7/widget/RecyclerView$ViewHolder;)Z:GetOnMove_Landroid_support_v7_widget_RecyclerView_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler\n" +
			"n_onSwiped:(Landroid/support/v7/widget/RecyclerView$ViewHolder;I)V:GetOnSwiped_Landroid_support_v7_widget_RecyclerView_ViewHolder_IHandler\n" +
			"n_onChildDraw:(Landroid/graphics/Canvas;Landroid/support/v7/widget/RecyclerView;Landroid/support/v7/widget/RecyclerView$ViewHolder;FFIZ)V:GetOnChildDraw_Landroid_graphics_Canvas_Landroid_support_v7_widget_RecyclerView_Landroid_support_v7_widget_RecyclerView_ViewHolder_FFIZHandler\n" +
			"n_onSelectedChanged:(Landroid/support/v7/widget/RecyclerView$ViewHolder;I)V:GetOnSelectedChanged_Landroid_support_v7_widget_RecyclerView_ViewHolder_IHandler\n" +
			"n_clearView:(Landroid/support/v7/widget/RecyclerView;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V:GetClearView_Landroid_support_v7_widget_RecyclerView_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler\n" +
			"";
		mono.android.Runtime.register ("XamarinItemTouchHelper.SimpleItemTouchHelperCallback, XamarinItemTouchHelper, Version=1.1.2.0, Culture=neutral, PublicKeyToken=null", SimpleItemTouchHelperCallback.class, __md_methods);
	}


	public SimpleItemTouchHelperCallback () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SimpleItemTouchHelperCallback.class)
			mono.android.TypeManager.Activate ("XamarinItemTouchHelper.SimpleItemTouchHelperCallback, XamarinItemTouchHelper, Version=1.1.2.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean isLongPressDragEnabled ()
	{
		return n_isLongPressDragEnabled ();
	}

	private native boolean n_isLongPressDragEnabled ();


	public boolean isItemViewSwipeEnabled ()
	{
		return n_isItemViewSwipeEnabled ();
	}

	private native boolean n_isItemViewSwipeEnabled ();


	public int getMovementFlags (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1)
	{
		return n_getMovementFlags (p0, p1);
	}

	private native int n_getMovementFlags (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1);


	public boolean onMove (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1, android.support.v7.widget.RecyclerView.ViewHolder p2)
	{
		return n_onMove (p0, p1, p2);
	}

	private native boolean n_onMove (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1, android.support.v7.widget.RecyclerView.ViewHolder p2);


	public void onSwiped (android.support.v7.widget.RecyclerView.ViewHolder p0, int p1)
	{
		n_onSwiped (p0, p1);
	}

	private native void n_onSwiped (android.support.v7.widget.RecyclerView.ViewHolder p0, int p1);


	public void onChildDraw (android.graphics.Canvas p0, android.support.v7.widget.RecyclerView p1, android.support.v7.widget.RecyclerView.ViewHolder p2, float p3, float p4, int p5, boolean p6)
	{
		n_onChildDraw (p0, p1, p2, p3, p4, p5, p6);
	}

	private native void n_onChildDraw (android.graphics.Canvas p0, android.support.v7.widget.RecyclerView p1, android.support.v7.widget.RecyclerView.ViewHolder p2, float p3, float p4, int p5, boolean p6);


	public void onSelectedChanged (android.support.v7.widget.RecyclerView.ViewHolder p0, int p1)
	{
		n_onSelectedChanged (p0, p1);
	}

	private native void n_onSelectedChanged (android.support.v7.widget.RecyclerView.ViewHolder p0, int p1);


	public void clearView (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1)
	{
		n_clearView (p0, p1);
	}

	private native void n_clearView (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1);

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
