using System.Collections;
using UnityEngine;
using Valve.VR;

public class LockVRCamera : MonoBehaviour
{
	private Quaternion lockRotation;

	private bool cameraLock = true;

	public bool CameraLock { get { return cameraLock; } }

	private float fieldOfView = 60;

	public float FieldOfView { get { return fieldOfView; } }

#pragma warning disable CS0108 // ����� ��ӵ� ����� ����ϴ�. new Ű���尡 �����ϴ�.
	private Camera camera;
#pragma warning restore CS0108 // ����� ��ӵ� ����� ����ϴ�. new Ű���尡 �����ϴ�.
	private Transform cameraTransform;
	private SteamVR_CameraHelper steamVRCameraHelper;

	private void Start()
	{ // �̰͵� �浹 ���� Ȥ�� �� ��Ʈ��ũ���� 
		steamVRCameraHelper = FindObjectOfType<SteamVR_CameraHelper>();
		camera = steamVRCameraHelper.GetComponent<Camera>();
		cameraTransform = camera.transform;

		StartCoroutine(Updating());
	}

	private IEnumerator Updating()
	{
		while (true)
		{
			camera.fieldOfView = fieldOfView;

			if (cameraLock)
			{
				steamVRCameraHelper.enabled = false;
				cameraTransform.localPosition = Vector3.zero;
				cameraTransform.rotation = lockRotation;
			}
			else
			{
				steamVRCameraHelper.enabled = false;
			}

			yield return null;
		}
	}

	public void Lock()
	{
		cameraLock = true;
	}

	public void UnLock()
	{
		cameraLock = false;
	}

	public void SetFieldOfView(float value)
	{
		fieldOfView = value;
	}

	public void SetRotation(Vector3 vector3)
	{
		lockRotation.eulerAngles = vector3;
	}

	public void SetRotation(Quaternion quaternion)
	{
		lockRotation = quaternion;
	}
}
