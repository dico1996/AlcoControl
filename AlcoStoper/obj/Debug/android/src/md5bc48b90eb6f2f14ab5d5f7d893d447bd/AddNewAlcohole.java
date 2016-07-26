package md5bc48b90eb6f2f14ab5d5f7d893d447bd;


public class AddNewAlcohole
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("AlcoStoper.AddNewAlcohole, AlcoStoper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AddNewAlcohole.class, __md_methods);
	}


	public AddNewAlcohole () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AddNewAlcohole.class)
			mono.android.TypeManager.Activate ("AlcoStoper.AddNewAlcohole, AlcoStoper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
