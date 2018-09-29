using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Package : MonoBehaviour
{
	public Text packageText;
	public GameObject packageObject;
	private Collider sphere;

	void Start()
	{
		PlayerPrefs.SetInt("package", 0);
		packageText.text = "";
		sphere = GetComponent<Collider>();
	}

	void FixedUpdate()
	{
		transform.Rotate(0, 100 * Time.deltaTime, 0);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerPrefs.SetInt("package", PlayerPrefs.GetInt("package") + 1);
			PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 1000);
			StartCoroutine("SetPackageText");
			sphere.enabled = false;
			packageObject.SetActive(false);
		}
	}

	IEnumerator SetPackageText()
	{
		packageText.text = "Hidden Package " + PlayerPrefs.GetInt("package").ToString() + " of 28";
		yield return new WaitForSeconds(5f);
		packageText.text = "";
		Destroy(this.gameObject);
	}
}
