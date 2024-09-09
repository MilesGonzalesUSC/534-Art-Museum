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

    private AudioSource PlayerAudio;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAudio = Player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //make the magnifying glass appear
        if(DistanceToAppear >= Vector3.Distance(transform.position,Player.transform.position)) {
            gameObject.transform.GetChild( 0 ).gameObject.SetActive( true );
            PlayerAudio.clip = Huh;
            PlayerAudio.Play();
            //rotate the magnifying glass
            if(FacePlayerBool) {
                Quaternion targetRotation = Quaternion.LookRotation( Player.transform.position - transform.position );
                float t = Mathf.Min( 1.7f * Time.deltaTime, 1 );
                transform.rotation = Quaternion.Lerp( transform.rotation, targetRotation, t );
            }
        } else if(DistanceToAppear <= Vector3.Distance( transform.position, Player.transform.position )){
            gameObject.transform.GetChild( 0 ).gameObject.SetActive( false );
        }
    }
}
