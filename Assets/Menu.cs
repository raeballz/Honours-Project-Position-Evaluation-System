using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public GameObject Canvas;
	public GameObject Camera;
	bool Paused = false;
	
	void Start(){
		Canvas.gameObject.SetActive (false);
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(Paused == true){
				Time.timeScale = 1.0f;
				Canvas.gameObject.SetActive (false);
				UnityEngine.Cursor.visible = false;
				UnityEngine.Cursor.lockState = CursorLockMode.Locked;

				Paused = false;
			} else {
				Time.timeScale = 0.0f;
				Canvas.gameObject.SetActive (true);
				UnityEngine.Cursor.visible = true;
				UnityEngine.Cursor.lockState = CursorLockMode.Confined;
				Paused = true;
			}
		}
	}
	public void Resume(){
		Time.timeScale = 1.0f;
		Canvas.gameObject.SetActive (false);
		UnityEngine.Cursor.visible = true;
		UnityEngine.Cursor.lockState = CursorLockMode.Locked;
	}
}    