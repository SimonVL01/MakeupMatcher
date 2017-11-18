package md598f4f8887a6a3d1e4766ed14d63b1e21;


public class ProductView
	extends md59de2239e30a2c8a38dd75adc5c2e9d40.MvxActivity_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("MakeupMatcher.UI.Droid.Views.ProductView, MakeupMatcher.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ProductView.class, __md_methods);
	}


	public ProductView ()
	{
		super ();
		if (getClass () == ProductView.class)
			mono.android.TypeManager.Activate ("MakeupMatcher.UI.Droid.Views.ProductView, MakeupMatcher.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
