package md5bc48b90eb6f2f14ab5d5f7d893d447bd;


public class CameraActivity_Camera2BasicFragment_ErrorDialog
	extends android.app.DialogFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateDialog:(Landroid/os/Bundle;)Landroid/app/Dialog;:GetOnCreateDialog_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("AlcoStoper.CameraActivity+Camera2BasicFragment+ErrorDialog, AlcoStoper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CameraActivity_Camera2BasicFragment_ErrorDialog.class, __md_methods);
	}


	public CameraActivity_Camera2BasicFragment_ErrorDialog () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CameraActivity_Camera2BasicFragment_ErrorDialog.class)
			mono.android.TypeManager.Activate ("AlcoStoper.CameraActivity+Camera2BasicFragment+ErrorDialog, AlcoStoper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public android.app.Dialog onCreateDialog (android.os.Bundle p0)
	{
		return n_onCreateDialog (p0);
	}

	private native android.app.Dialog n_onCreateDialog (android.os.Bundle p0);

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
