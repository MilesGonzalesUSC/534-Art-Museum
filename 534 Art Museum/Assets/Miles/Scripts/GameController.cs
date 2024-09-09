using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Player;
    public GameObject OverlayPanel;
    public GameObject ControlsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown( KeyCode.Escape )) {
			if(ControlsMenu.activeSelf) {
                ControlsMenu.SetActive( false );
			} else if(!ControlsMenu.activeSelf) {
                ControlsMenu.SetActive( true );
			}
		}
    }

    public void OverlayPanelActive( ) {
        OverlayPanel.SetActive( true );
        Player.GetComponent<FPSController>().canMove = false;
	}

    public void OverlayPanelInActive( ) {
        OverlayPanel.SetActive( false );
        Player.GetComponent<FPSController>().canMove = true;
    }
}
