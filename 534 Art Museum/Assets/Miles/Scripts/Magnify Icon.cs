using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MagnifyIcon : MonoBehaviour
{
    public bool FacePlayerBool;
    public GameObject Player;
    public float DistanceToAppear;
    public AudioClip Huh;

    public GameObject InteractCanvas;


    private bool ClipRun;
    private bool CanvasActive;
    private AudioSource PlayerAudio;
    public GameObject GC;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAudio = Player.GetComponent<AudioSource>();
        ClipRun = false;
        CanvasActive = false;
        GC = GameObject.FindWithTag( "GameController" );
    }

    // Update is called once per frame
    void Update()
    {
        //make the magnifying glass appear
        if(DistanceToAppear >= Vector3.Distance(transform.position,Player.transform.position)) {
            gameObject.transform.GetChild( 0 ).gameObject.SetActive( true );
            if(!ClipRun) {
                PlayerAudio.clip = Huh;
                PlayerAudio.Play();
                ClipRun = true;
            }
            //rotate the magnifying glass
            if(FacePlayerBool) {
                Quaternion targetRotation = Quaternion.LookRotation( Player.transform.position - transform.position );
                float t = Mathf.Min( 1.7f * Time.deltaTime, 1 );
                transform.rotation = Quaternion.Lerp( transform.rotation, targetRotation, t );
            }

            // interact action which pulls up UI
            if(Input.GetKeyDown( KeyCode.E ) && CanvasActive == false) {
                UIActive();

            }

            if(CanvasActive && Input.GetKeyDown( KeyCode.Escape )) {
                UIInactive();

            }
        } else if(DistanceToAppear <= Vector3.Distance( transform.position, Player.transform.position )){
            gameObject.transform.GetChild( 0 ).gameObject.SetActive( false );
            ClipRun = false;
        }
    }

    public void UIActive( ) {
        InteractCanvas.gameObject.SetActive( true );
        CanvasActive = true;
        Player.GetComponent<FPSController>().canMove = false;
        GC.GetComponent<GameController>().InMenu = true;

    }

    public void UIInactive( ) {
        InteractCanvas.gameObject.SetActive( false );
        CanvasActive = false;
        Player.GetComponent<FPSController>().canMove = true;
        StartCoroutine( DelayInMenu(0.2f) );
        
    }

    private IEnumerator DelayInMenu(float delay ) {
        yield return new WaitForSeconds( delay );
        GC.GetComponent<GameController>().InMenu = false;

    }
}
