package md59de2239e30a2c8a38dd75adc5c2e9d40;


public class MvxTabActivity_1
	extends mvvmcross.droid.views.MvxTabActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MvvmCross.Droid.Views.MvxTabActivity`1, MvvmCross.Droid, Version=5.4.2.0, Culture=neutral, PublicKeyToken=null", MvxTabActivity_1.class, __md_methods);
	}


	public MvxTabActivity_1 ()
	{
		super ();
		if (getClass () == MvxTabActivity_1.class)
			mono.android.TypeManager.Activate ("MvvmCross.Droid.Views.MvxTabActivity`1, MvvmCross.Droid, Version=5.4.2.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
