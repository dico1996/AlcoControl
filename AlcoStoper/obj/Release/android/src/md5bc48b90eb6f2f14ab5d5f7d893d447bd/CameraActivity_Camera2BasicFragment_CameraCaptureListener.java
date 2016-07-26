package md5bc48b90eb6f2f14ab5d5f7d893d447bd;


public class CameraActivity_Camera2BasicFragment_CameraCaptureListener
	extends android.hardware.camera2.CameraCaptureSession.CaptureCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCaptureCompleted:(Landroid/hardware/camera2/CameraCaptureSession;Landroid/hardware/camera2/CaptureRequest;Landroid/hardware/camera2/TotalCaptureResult;)V:GetOnCaptureCompleted_Landroid_hardware_camera2_CameraCaptureSession_Landroid_hardware_camera2_CaptureRequest_Landroid_hardware_camera2_TotalCaptureResult_Handler\n" +
			"";
		mono.android.Runtime.register ("AlcoStoper.CameraActivity+Camera2BasicFragment+CameraCaptureListener, AlcoStoper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CameraActivity_Camera2BasicFragment_CameraCaptureListener.class, __md_methods);
	}


	public CameraActivity_Camera2BasicFragment_CameraCaptureListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CameraActivity_Camera2BasicFragment_CameraCaptureListener.class)
			mono.android.TypeManager.Activate ("AlcoStoper.CameraActivity+Camera2BasicFragment+CameraCaptureListener, AlcoStoper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCaptureCompleted (android.hardware.camera2.CameraCaptureSession p0, android.hardware.camera2.CaptureRequest p1, android.hardware.camera2.TotalCaptureResult p2)
	{
		n_onCaptureCompleted (p0, p1, p2);
	}

	private native void n_onCaptureCompleted (android.hardware.camera2.CameraCaptureSession p0, android.hardware.camera2.CaptureRequest p1, android.hardware.camera2.TotalCaptureResult p2);

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
