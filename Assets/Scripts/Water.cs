using UnityEngine;

public class Water : MonoBehaviour {

	public GameObject player;
	public GameObject playerOrange;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			player.transform.position = new Vector3(-22, 3, -62);
		}
		else if (collision.gameObject.name == "Player (orange)")
		{
			playerOrange.transform.position = new Vector3(-22, 3, -62);
		}
		else if (collision.gameObject.CompareTag("car"))
		{
			if (PlayerPrefs.GetString("player") == "orange")
			{
				playerOrange.transform.position = new Vector3(-22, 3, -62);
			}
			else if (PlayerPrefs.GetString("player") == "normal")
			{
				player.transform.position = new Vector3(-22, 3, -62);
			}
		}
	}
}
