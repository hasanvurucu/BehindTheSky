using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class usernameGetSetScript : MonoBehaviour {

	public InputField usernameInput;
	public Text username;
	public static string usernameReal;

	public GameObject panel;
	public static int usernameSet;
	public GameObject changeButton;

	void Awake()
	{
		usernameSet = PlayerPrefs.GetInt ("usernameSet", usernameSet);
		
		if (usernameSet == 1)
		{
			panel.SetActive (false);
		} else
		{
			int i = Random.Range(1000, 9999999);
			username.text = "Guest" + i;
		}

		usernameReal = PlayerPrefs.GetString ("usernameReal", usernameReal);
		username.text = "User: " + usernameReal;
	}

	public void setget()
	{
		username.text = "User: " + usernameInput.text;
		usernameReal = usernameInput.text;
		Debug.Log ("string: " + usernameReal);
		PlayerPrefs.SetString ("usernameReal", usernameReal);
		panel.SetActive (false);
		usernameSet = 1;
		PlayerPrefs.SetInt ("usernameSet", usernameSet);
	}

	public void activeUsernameChange()
	{
		usernameSet = 0;
		panel.SetActive (true);
		changeButton.SetActive (false);
	}
}
