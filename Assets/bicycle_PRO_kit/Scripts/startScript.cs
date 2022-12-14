// Writen by Boris Chuprin smokerr@mail.ru
using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	private float camShift = 0.25f;
	private float devShift = 0.25f;
	public Transform menuCam;
	public Transform mobileDevice;

	void OnGUI ()
	{

        GUIStyle biggerText = new()
        {
            fontSize = 40
        };
        biggerText.normal.textColor = Color.white;
		GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 16, 100, 90), "Welcome to", biggerText);
		GUI.Label (new Rect (Screen.width / 2.8f, Screen.height / 6, 100, 90), "BICYCLE PRO KIT", biggerText);

        GUIStyle mediumText = new()
        {
            fontSize = 30
        };
        mediumText.normal.textColor = Color.white;
		GUI.Label (new Rect (Screen.width / 2.6f, Screen.height / 1.1f, 100, 90), "Choose your bicycle", mediumText);

	}

    // Update is called once per frame
    [System.Obsolete]
    void Update () {
	
		//camera moving
		menuCam.transform.Rotate (camShift * Time.deltaTime * Vector3.up);
		if (menuCam.transform.eulerAngles.y >=1 && menuCam.transform.eulerAngles.y <= 5) camShift = -0.25f;
		if (menuCam.transform.eulerAngles.y <=359 && menuCam.transform.eulerAngles.y >= 5) camShift = 0.25f;
		//device moving
		mobileDevice.transform.Rotate (devShift * Time.deltaTime * Vector3.up);
		if (mobileDevice.transform.eulerAngles.y >=1 && mobileDevice.transform.eulerAngles.y <= 5) devShift = -10.5f;
		if (mobileDevice.transform.eulerAngles.y <=359 && mobileDevice.transform.eulerAngles.y >= 5) devShift = 10.5f;


		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit);
            if (hit.transform.gameObject.name == "dirtBike_Selector") {
				Application.LoadLevel("BPK_bicycle_MTB");
			}
			if (hit.transform.gameObject.name == "fullSuspBikeSelector") {
				Application.LoadLevel("BPK_bicycle_FullSuspension");
			}
			if (hit.transform.gameObject.name == "mobDevice_Selector") {
				Application.LoadLevel("BPK_bicycle_mobile");
			}
		}
	}
}
