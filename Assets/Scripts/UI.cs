using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Text time;
	public Text money;

	private int minutes = 10;
	private int hours = 4;
	private string minutesUI;
	private string hoursUI;

	void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		PlayerPrefs.SetInt("money", 0);
		PlayerPrefs.SetInt("package", 0);
		PlayerPrefs.SetString("player", "orange");
		time.text = "";
		InvokeRepeating("DayTime", 0f, 1f);
	}

	void Update()
	{
		money.text = PlayerPrefs.GetInt("money").ToString();

		if (Input.GetButton("Cancel"))
		{
			Application.Quit();
		}
	}

	void DayTime()
	{
		minutes += 1;
		if (minutes == 60)
		{
			minutes = 0;
			hours += 1;
			if (hours == 24)
			{
				hours = 0;
			}
		}

		if (minutes < 10) minutesUI = "0" + minutes;
		else minutesUI = minutes.ToString();

		if (hours < 10) hoursUI = "0" + hours;
		else hoursUI = hours.ToString();

        time.text = hoursUI + ":" + minutesUI;
	}
}
