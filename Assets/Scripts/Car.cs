using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
	public WheelCollider leftWheel;
	public WheelCollider rightWheel;
	public bool motor;
	public bool steering;
}

public class Car : MonoBehaviour {

	private bool inCar = false;
	public Camera carMinimap;
	public GameObject carCameraSupport;
	public GameObject playerNormal;
	public GameObject playerOrange;
	public Text carText;

	public List<AxleInfo> axleInfos;
	public float maxMotorTorque;
	public float maxSteeringAngle;

	// finds the corresponding visual wheel
	// correctly applies the transform
	public void ApplyLocalPositionToVisuals(WheelCollider collider)
	{
		if (collider.transform.childCount == 0)
		{
			return;
		}

		Transform visualWheel = collider.transform.GetChild(0);

		Vector3 position;
		Quaternion rotation;
		collider.GetWorldPose(out position, out rotation);

		visualWheel.transform.position = position;
		visualWheel.transform.rotation = rotation;
	}

	public void FixedUpdate()
	{
		if (inCar == true)
		{
			float motor = maxMotorTorque * -Input.GetAxis("Vertical");
			float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

			foreach (AxleInfo axleInfo in axleInfos)
			{
				if (axleInfo.steering)
				{
					axleInfo.leftWheel.steerAngle = steering;
					axleInfo.rightWheel.steerAngle = steering;
				}
				if (axleInfo.motor)
				{
					axleInfo.leftWheel.motorTorque = motor;
					axleInfo.rightWheel.motorTorque = motor;
				}
				ApplyLocalPositionToVisuals(axleInfo.leftWheel);
				ApplyLocalPositionToVisuals(axleInfo.rightWheel);
			}

			carMinimap.transform.eulerAngles = new Vector3(90, this.transform.localEulerAngles.y + 180, 0);

			if (Input.GetButton("Fire1") && !Input.GetButton("Fire2"))
			{
				carCameraSupport.transform.eulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y - 90 + 180, this.transform.localEulerAngles.z);
			}
			else if(Input.GetButton("Fire2") && !Input.GetButton("Fire1"))
			{
				carCameraSupport.transform.eulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y + 90 + 180, this.transform.localEulerAngles.z);
			}
			else if (Input.GetButton("Fire1") && Input.GetButton("Fire2"))
			{
				carCameraSupport.transform.eulerAngles = new Vector3(0, this.transform.localEulerAngles.y, 0);
			}
			else
			{
				carCameraSupport.transform.eulerAngles = new Vector3(0, this.transform.localEulerAngles.y + 180, 0);
			}

			if (Input.GetKeyDown(KeyCode.F))
			{
				StartCoroutine("spawnPlayer");
				inCar = false;
				carCameraSupport.SetActive(false);
				carMinimap.gameObject.SetActive(false);
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (Input.GetKeyDown(KeyCode.F) && inCar == false)
			{
				inCar = true;
				if (PlayerPrefs.GetString("player") == "orange")
				{
					playerOrange.SetActive(false);
				}
				else if (PlayerPrefs.GetString("player") == "normal")
				{
					playerNormal.SetActive(false);
				}
				carCameraSupport.SetActive(true);
				carMinimap.gameObject.SetActive(true);
				StartCoroutine("carName");
			}
		}
	}

	IEnumerator spawnPlayer()
	{
		yield return new WaitForSeconds(0.001f);
		if (PlayerPrefs.GetString("player") == "orange")
		{
			playerOrange.SetActive(true);
			playerOrange.transform.position = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
		}
		else if (PlayerPrefs.GetString("player") == "normal")
		{
			playerNormal.SetActive(true);
			playerNormal.transform.position = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
		}
	}

	IEnumerator carName()
	{
		yield return new WaitForSeconds(0.5f);
		carText.gameObject.SetActive(true);
		yield return new WaitForSeconds(5f);
		carText.gameObject.SetActive(false);
	}
}
