package md5bc48b90eb6f2f14ab5d5f7d893d447bd;


public class CameraActivity_Camera2BasicFragment_CameraStateListener
	extends android.hardware.camera2.CameraDevice.StateCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onOpened:(Landroid/hardware/camera2/CameraDevice;)V:GetOnOpened_Landroid_hardware_camera2_CameraDevice_Handler\n" +
			"n_onDisconnected:(Landroid/hardware/camera2/CameraDevice;)V:GetOnDisconnected_Landroid_hardware_camera2_CameraDevice_Handler\n" +
			"n_onError:(Landroid/hardware/camera2/CameraDevice;I)V:GetOnError_Landroid_hardware_camera2_CameraDevice_IHandler\n" +
			"";
		mono.android.Runtime.register ("AlcoStoper.CameraActivity+Camera2BasicFragment+CameraStateListener, AlcoStoper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CameraActivity_Camera2BasicFragment_CameraStateListener.class, __md_methods);
	}


	public CameraActivity_Camera2BasicFragment_CameraStateListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CameraActivity_Camera2BasicFragment_CameraStateListener.class)
			mono.android.TypeManager.Activate ("AlcoStoper.CameraActivity+Camera2BasicFragment+CameraStateListener, AlcoStoper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onOpened (android.hardware.camera2.CameraDevice p0)
	{
		n_onOpened (p0);
	}

	private native void n_onOpened (android.hardware.camera2.CameraDevice p0);


	public void onDisconnected (android.hardware.camera2.CameraDevice p0)
	{
		n_onDisconnected (p0);
	}

	private native void n_onDisconnected (android.hardware.camera2.CameraDevice p0);


	public void onError (android.hardware.camera2.CameraDevice p0, int p1)
	{
		n_onError (p0, p1);
	}

	private native void n_onError (android.hardware.camera2.CameraDevice p0, int p1);

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
