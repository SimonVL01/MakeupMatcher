package md598f4f8887a6a3d1e4766ed14d63b1e21;


public class SplashScreenView
	extends mvvmcross.droid.views.MvxSplashScreenActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MakeupMatcher.UI.Droid.Views.SplashScreenView, MakeupMatcher.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SplashScreenView.class, __md_methods);
	}


	public SplashScreenView ()
	{
		super ();
		if (getClass () == SplashScreenView.class)
			mono.android.TypeManager.Activate ("MakeupMatcher.UI.Droid.Views.SplashScreenView, MakeupMatcher.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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