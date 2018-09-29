using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	public Text ram;
	public Text rom;
	public Text bigR;
	public Text roucasseGames;
	public Image fade;

	public GameObject grid;

	void Start ()
	{
		StartCoroutine(RamRomText());
	}

	IEnumerator RamRomText()
	{
		// Grid
		yield return new WaitForSeconds(0.75f);
		grid.gameObject.SetActive(true);
		yield return new WaitForSeconds(1.25f);
		grid.gameObject.SetActive(false);

		// RAM text
		yield return new WaitForSeconds(0.01f);
		ram.text = "R";
		yield return new WaitForSeconds(0.01f);
		ram.text = "RA";
		yield return new WaitForSeconds(0.01f);
		ram.text = "RAM";
		yield return new WaitForSeconds(0.01f);
		ram.text = "RAM	";
		yield return new WaitForSeconds(0.01f);
		ram.text = "RAM	O";
		yield return new WaitForSeconds(0.01f);
		ram.text = "RAM	OK";
		yield return new WaitForSeconds(0.01f);

		// ROM text
		yield return new WaitForSeconds(0.75f);
		rom.text = "R";
		yield return new WaitForSeconds(0.01f);
		rom.text = "RO";
		yield return new WaitForSeconds(0.01f);
		rom.text = "ROM";
		yield return new WaitForSeconds(0.01f);
		rom.text = "ROM	";
		yield return new WaitForSeconds(0.01f);
		rom.text = "ROM	O";
		yield return new WaitForSeconds(0.01f);
		rom.text = "ROM	OK";

		// Remove RAM and ROM text
		yield return new WaitForSeconds(1f);
		ram.text = "";
		rom.text = "";

		// Big R logo
		yield return new WaitForSeconds(0.1f);
		bigR.text = "R";

		// Roucasse Games
		yield return new WaitForSeconds(1.2f);
		roucasseGames.text = "R";
		yield return new WaitForSeconds(0.01f);
		roucasseGames.text = "RO";
		yield return new WaitForSeconds(0.01f);
		roucasseGames.text = "ROU";
		yield return new WaitForSeconds(0.01f);
		roucasseGames.text = "ROUC";
		yield return new WaitForSeconds(0.01f);
		roucasseGames.text = "ROUCA";
		yield return new WaitForSeconds(0.01f);
		roucasseGames.text = "ROUCAS";
		yield return new WaitForSeconds(0.01f);
		roucasseGames.text = "ROUCASS";
		yield return new WaitForSeconds(0.01f);
		roucasseGames.text = "ROUCASSE";
		yield return new WaitForSeconds(0.01f);
		roucasseGames.text = "ROUCASSE ";
		yield return new WaitForSeconds(0.01f);
		roucasseGames.text = "ROUCASSE G";
		yield return new WaitForSeconds(0.01f);
		roucasseGames.text = "ROUCASSE GA";
		yield return new WaitForSeconds(0.01f);
		roucasseGames.text = "ROUCASSE GAM";
		yield return new WaitForSeconds(0.01f);
		roucasseGames.text = "ROUCASSE GAME";
		yield return new WaitForSeconds(0.01f);
		roucasseGames.text = "ROUCASSE GAMES";

		// Fade animation
		yield return new WaitForSeconds(3f);
		fade.gameObject.SetActive(true);

		// Load the game
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("Game");
	}
}
