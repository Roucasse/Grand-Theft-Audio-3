using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndMission : MonoBehaviour {

	public GameObject playerPlayOrange;
	public GameObject playerPlay;

	public GameObject playerIntroOrange;
	public GameObject playerIntroNormal;

	public GameObject heightBallOrange;
	public GameObject heightBallNormal;

	public GameObject package;
	public GameObject blackBar;
	public GameObject gameUI;
	public Camera introCamera;
	public Text introText;

	void OnTriggerEnter(Collider other)
	{
		other.gameObject.SetActive(false);
		StartCoroutine("startEnd");
	}

	IEnumerator startEnd()
	{
		playerPlayOrange.gameObject.SetActive(false);
		gameUI.gameObject.SetActive(false);

		heightBallOrange.gameObject.SetActive(true);
		playerIntroOrange.gameObject.SetActive(true);
		blackBar.gameObject.SetActive(true);
		introCamera.gameObject.SetActive(true);
		introText.gameObject.SetActive(true);

		heightBallOrange.transform.position = new Vector3(-224, -3, 161);
		heightBallOrange.transform.eulerAngles = new Vector3(0, 45, 0);
		playerIntroOrange.transform.position = new Vector3(-224, -3, 165);
		playerIntroOrange.transform.eulerAngles = new Vector3(0, 120, 0);
		introCamera.transform.position = new Vector3(-232, 5, 158);
		introCamera.transform.eulerAngles = new Vector3(25, 75, 0);

		yield return new WaitForSeconds(2f);
		introText.text = "This is the place right here, let's get off the street and find a change of clothes!";
		yield return new WaitForSeconds(5f);
		introText.text = "";

		heightBallOrange.gameObject.SetActive(false);
		playerIntroOrange.gameObject.SetActive(false);
		heightBallNormal.gameObject.SetActive(true);
		playerIntroNormal.gameObject.SetActive(true);

		heightBallNormal.transform.position = new Vector3(-221, -3, 164);
		heightBallNormal.transform.eulerAngles = new Vector3(0, -80, 0);
		playerIntroNormal.transform.position = new Vector3(-225, -3, 165);
		playerIntroNormal.transform.eulerAngles = new Vector3(0, 100, 0);
		introCamera.transform.position = new Vector3(-225, 0, 160);
		introCamera.transform.eulerAngles = new Vector3(20, 25, 0);

		yield return new WaitForSeconds(1f);
		introText.text = "Now explore the city ! I found a package, I've heard there are more hidden in the city.";
		yield return new WaitForSeconds(6f);
		package.gameObject.SetActive(true);
		introText.text = "Take this one and find the others.";
		yield return new WaitForSeconds(5f);
		introText.text = "";

		heightBallNormal.gameObject.SetActive(false);
		playerIntroNormal.gameObject.SetActive(false);
		blackBar.gameObject.SetActive(false);
		introCamera.gameObject.SetActive(false);
		introText.gameObject.SetActive(false);

		playerPlay.gameObject.SetActive(true);
		gameUI.gameObject.SetActive(true);

		PlayerPrefs.SetString("player", "normal");
		this.gameObject.SetActive(false);
	}
}
