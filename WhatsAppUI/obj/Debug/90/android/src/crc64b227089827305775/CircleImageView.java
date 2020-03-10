package crc64b227089827305775;


public class CircleImageView
	extends de.hdodenhof.circleimageview.CircleImageView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Refractored.Controls.CircleImageView, Refractored.Controls.CircleImageView", CircleImageView.class, __md_methods);
	}


	public CircleImageView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CircleImageView.class)
			mono.android.TypeManager.Activate ("Refractored.Controls.CircleImageView, Refractored.Controls.CircleImageView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CircleImageView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CircleImageView.class)
			mono.android.TypeManager.Activate ("Refractored.Controls.CircleImageView, Refractored.Controls.CircleImageView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CircleImageView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CircleImageView.class)
			mono.android.TypeManager.Activate ("Refractored.Controls.CircleImageView, Refractored.Controls.CircleImageView", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
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
