using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class displayHighscores : MonoBehaviour {

	public Text[] highscoreFields;
	Highscores highscoresManager;

	public bool top1000check = false;

	public static string usernameReal;

	void Start() {
		for (int i = 0; i < highscoreFields.Length; i ++) {
			highscoreFields[i].text = i+1 + ". Fetching...";
		}

		usernameReal = PlayerPrefs.GetString ("usernameReal", usernameReal);

		highscoresManager = GetComponent<Highscores>();
		StartCoroutine("RefreshHighscores");

	}

	public void OnHighscoresDownloaded(Highscore[] highscoreList) {
		int i;
		for (i =0; i < highscoreFields.Length; i ++) {
			highscoreFields[i].text = i+1 + ". ";
			if (i < highscoreList.Length) {
				highscoreFields[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
			}
		}
		for (i = 0; i < 998; i++)
		{
			//display current rank
			if (highscoreList [i].username == usernameReal)
			{
				highscoreFields[10].text = i+1 + ". ";
				highscoreFields [10].text += highscoreList [i].username + " - " + highscoreList [i].score;
				top1000check = true;
			}
		}
		if (top1000check == false)
		{
			highscoreFields[10].text = "You're not in top 1000 :(";
		}
	}

	IEnumerator RefreshHighscores() {
		while (true) {
			highscoresManager.DownloadHighscores();
			yield return new WaitForSeconds(30);
		}
	}
}