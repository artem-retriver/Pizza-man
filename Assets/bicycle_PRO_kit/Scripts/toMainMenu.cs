// Writen by Boris Chuprin smokerr@mail.ru
using UnityEngine;
using System.Collections;

public class ToMainMenu : MonoBehaviour {

    // Update is called once per frame
    [System.Obsolete]
    void Update () {
		if  (Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel("BPK_MainMenu");
		}
	}
}
