package md59de2239e30a2c8a38dd75adc5c2e9d40;


public abstract class MvxActivity_1
	extends mvvmcross.droid.views.MvxActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MvvmCross.Droid.Views.MvxActivity`1, MvvmCross.Droid, Version=5.4.2.0, Culture=neutral, PublicKeyToken=null", MvxActivity_1.class, __md_methods);
	}


	public MvxActivity_1 ()
	{
		super ();
		if (getClass () == MvxActivity_1.class)
			mono.android.TypeManager.Activate ("MvvmCross.Droid.Views.MvxActivity`1, MvvmCross.Droid, Version=5.4.2.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
