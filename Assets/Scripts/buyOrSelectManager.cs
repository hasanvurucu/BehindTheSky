using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class buyOrSelectManager : MonoBehaviour {

	public resourceManageScript resManage;

	//if it becomes true, ship is bought infinitely
	public static int ship2BuyPayment = 0;
	public static int ship3BuyPayment = 0;
	public static int ship4BuyPayment = 0;
	public static int ship5BuyPayment = 0;
	public static int ship6BuyPayment = 0;

	//selected ships' number
	public static int selectedShipNumb;

	//resources to decrease
	public static int metalResource;
	public static int titaniumResource;

	public GameObject selectShip1Button;
	public GameObject selectShip2Button;
	public GameObject selectShip3Button;
	public GameObject selectShip4Button;
	public GameObject selectShip5Button;
	public GameObject selectShip6Button;

	public GameObject buyShip2Button;
	public GameObject buyShip3Button;
	public GameObject buyShip4Button;
	public GameObject buyShip5Button;
	public GameObject buyShip6Button;

	public GameObject UMK1selected;
	public GameObject UMK2selected;
	public GameObject UMK3selected;
	public GameObject UMK4selected;
	public GameObject UMK5selected;
	public GameObject UMK6selected;

	//ship buy buttons' methods

	private int i;

	void Start()
	{
		metalResource = PlayerPrefs.GetInt ("TheMetalResource", metalResource);
		titaniumResource = PlayerPrefs.GetInt ("TheTitaniumResource", titaniumResource);
		selectedShipNumb = PlayerPrefs.GetInt ("SelectedShipNumb", selectedShipNumb);

		ship2BuyPayment = PlayerPrefs.GetInt ("ship2Bought", ship2BuyPayment);
		ship3BuyPayment = PlayerPrefs.GetInt ("ship3Bought", ship3BuyPayment);
		ship4BuyPayment = PlayerPrefs.GetInt ("ship4Bought", ship4BuyPayment);
		ship5BuyPayment = PlayerPrefs.GetInt ("ship5Bought", ship5BuyPayment);
	}
	void Update()
	{
		//PlayerPrefs.SetInt ("TheMetalResource", metalResource);
		//PlayerPrefs.SetInt ("TheTitaniumResource", titaniumResource);

		PlayerPrefs.SetInt ("ship2Bought", ship2BuyPayment);
		PlayerPrefs.SetInt ("ship3Bought", ship3BuyPayment);
		PlayerPrefs.SetInt ("ship4Bought", ship4BuyPayment);
		PlayerPrefs.SetInt ("ship5Bought", ship5BuyPayment);

		if (ship2BuyPayment == 1) 
		{
			buyShip2Button.SetActive (false);
		//	selectShip2Button.SetActive (true);
		}
		if (ship3BuyPayment == 1) 
		{
			buyShip3Button.SetActive (false);
		//	selectShip3Button.SetActive (true);
		}
		if (ship4BuyPayment == 1) 
		{
			buyShip4Button.SetActive (false);
		//	selectShip4Button.SetActive (true);
		}
		if (ship5BuyPayment == 1) 
		{
			buyShip5Button.SetActive (false);
		//	selectShip5Button.SetActive (true);
		}

		if (selectedShipNumb == 1)
		{
			UMK1selected.SetActive (true);
			selectShip1Button.SetActive (false);
		} else
		{
			UMK1selected.SetActive (false);
			selectShip1Button.SetActive (true);
		}

		if (selectedShipNumb == 2)
		{
			UMK2selected.SetActive (true);
			selectShip2Button.SetActive (false);
		}else
		{
			UMK2selected.SetActive (false);
			if (ship2BuyPayment == 1)
			{
				selectShip2Button.SetActive (true);
			}
		}

		if (selectedShipNumb == 3)
		{
			UMK3selected.SetActive (true);
			selectShip3Button.SetActive (false);
		}else
		{
			UMK3selected.SetActive (false);
			if (ship3BuyPayment == 1)
			{
				selectShip3Button.SetActive (true);
			}
		}

		if (selectedShipNumb == 4)
		{
			UMK4selected.SetActive (true);
			selectShip4Button.SetActive (false);
		}else
		{
			UMK4selected.SetActive (false);
			if (ship4BuyPayment == 1)
			{
				selectShip4Button.SetActive (true);
			}
		}

		if (selectedShipNumb == 5)
		{
			UMK5selected.SetActive (true);
			selectShip5Button.SetActive (false);
		}else
		{
			UMK5selected.SetActive (false);
			if (ship5BuyPayment == 1)
			{
				selectShip5Button.SetActive (true);
			}
		}

		if (selectedShipNumb == 6)
		{
			UMK6selected.SetActive (true);
			selectShip6Button.SetActive (false);
		}else
		{
			UMK6selected.SetActive (false);
			if (ship6BuyPayment == 1)
			{
				selectShip6Button.SetActive (true);
			}
		}
	}

	public void buyShip2Method()
	{
		if (metalResource >= 20 && titaniumResource >= 45) {
			selectedShipNumb = 2;
			PlayerPrefs.SetInt ("SelectedShipNumb", selectedShipNumb);
			Debug.Log ("ship is " + selectedShipNumb + " now.");
			ship2BuyPayment = 1;
			buyShip2Button.SetActive (false);
			selectShip2Button.SetActive (true);

			for (i = 0; i < 20; i++) 
			{
				resManage.metalResourceDecrease ();
			}
			for (i = 0; i < 45; i++) 
			{
				resManage.titaniumResourceDecrease ();
			}

			//camMovSc.metalResourceAdd (); //benzeri bir methodla camera movementdan miktarları değiştir.
		}
		else 
		{
			//display: not enough resources message
			Debug.Log("not enough resources");
		}
	}
	public void buyShip3Method()
	{
		if (metalResource >= 60 && titaniumResource >= 30) {
			selectedShipNumb = 3;
			PlayerPrefs.SetInt ("SelectedShipNumb", selectedShipNumb);
			Debug.Log ("ship is " + selectedShipNumb + " now.");
			ship3BuyPayment = 1;
			buyShip3Button.SetActive (false);
			selectShip3Button.SetActive (true);

			for (i = 0; i < 60; i++) 
			{
				resManage.metalResourceDecrease ();
			}
			for (i = 0; i < 30; i++) 
			{
				resManage.titaniumResourceDecrease ();
			}

			//camMovSc.metalResourceAdd (); //benzeri bir methodla camera movementdan miktarları değiştir.
		}
		else 
		{
			//display: not enough resources message
			Debug.Log("not enough resources");
		}
	}
	public void buyShip4Method()
	{
		if (metalResource >= 55 && titaniumResource >= 55) {
			selectedShipNumb = 4;
			PlayerPrefs.SetInt ("SelectedShipNumb", selectedShipNumb);
			Debug.Log ("ship is " + selectedShipNumb + " now.");
			ship4BuyPayment = 1;
			buyShip4Button.SetActive (false);
			selectShip4Button.SetActive (true);

			for (i = 0; i < 55; i++) 
			{
				resManage.metalResourceDecrease ();
			}
			for (i = 0; i < 55; i++) 
			{
				resManage.titaniumResourceDecrease ();
			}

			//camMovSc.metalResourceAdd (); //benzeri bir methodla camera movementdan miktarları değiştir.
		}
		else 
		{
			//display: not enough resources message
			Debug.Log("not enough resources");
		}
	}
	public void buyShip5Method()
	{
		if (metalResource >= 85 && titaniumResource >= 70) {
			selectedShipNumb = 5;
			PlayerPrefs.SetInt ("SelectedShipNumb", selectedShipNumb);
			Debug.Log ("ship is " + selectedShipNumb + " now.");
			ship5BuyPayment = 1;
			buyShip5Button.SetActive (false);
			selectShip5Button.SetActive (true);

			for (i = 0; i < 85; i++) 
			{
				resManage.metalResourceDecrease ();
			}
			for (i = 0; i < 70; i++) 
			{
				resManage.titaniumResourceDecrease ();
			}

			//camMovSc.metalResourceAdd (); //benzeri bir methodla camera movementdan miktarları değiştir.
		}
		else 
		{
			//display: not enough resources message
			Debug.Log("not enough resources");
		}
	}
	public void buyShip6Method()
	{
		if (metalResource >= 90 && titaniumResource >= 75) {
			selectedShipNumb = 6;
			PlayerPrefs.SetInt ("SelectedShipNumb", selectedShipNumb);
			Debug.Log ("ship is " + selectedShipNumb + " now.");
			ship6BuyPayment = 1;
			buyShip6Button.SetActive (false);
			selectShip6Button.SetActive (true);

			for (i = 0; i < 90; i++) 
			{
				resManage.metalResourceDecrease ();
			}
			for (i = 0; i < 75; i++) 
			{
				resManage.titaniumResourceDecrease ();
			}

			//camMovSc.metalResourceAdd (); //benzeri bir methodla camera movementdan miktarları değiştir.
		}
		else 
		{
			//display: not enough resources message
			Debug.Log("not enough resources");
		}
	}

	//ship select button methods
	public void selectShip1Method()
	{
		selectedShipNumb = 1;
		PlayerPrefs.SetInt ("SelectedShipNumb", selectedShipNumb);
		Debug.Log ("ship is " + selectedShipNumb + " now.");
		UMK1selected.SetActive (true);
	}
	public void selectShip2Method()
	{
		selectedShipNumb = 2;
		PlayerPrefs.SetInt ("SelectedShipNumb", selectedShipNumb);
		Debug.Log ("ship is " + selectedShipNumb + " now.");
		UMK2selected.SetActive (true);
	}
	public void selectShip3Method()
	{
		selectedShipNumb = 3;
		PlayerPrefs.SetInt ("SelectedShipNumb", selectedShipNumb);
		Debug.Log ("ship is " + selectedShipNumb + " now.");
		UMK3selected.SetActive (true);
	}
	public void selectShip4Method()
	{
		selectedShipNumb = 4;
		PlayerPrefs.SetInt ("SelectedShipNumb", selectedShipNumb);
		Debug.Log ("ship is " + selectedShipNumb + " now.");
		UMK4selected.SetActive (true);
	}
	public void selectShip5Method()
	{
		selectedShipNumb = 5;
		PlayerPrefs.SetInt ("SelectedShipNumb", selectedShipNumb);
		Debug.Log ("ship is " + selectedShipNumb + " now.");
		UMK5selected.SetActive (true);
	}
	public void selectShip6Method()
	{
		selectedShipNumb = 6;
		PlayerPrefs.SetInt ("SelectedShipNumb", selectedShipNumb);
		Debug.Log ("ship is " + selectedShipNumb + " now.");
		UMK6selected.SetActive (true);
	}
}
