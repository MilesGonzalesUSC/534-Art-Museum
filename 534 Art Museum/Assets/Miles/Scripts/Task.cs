using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class Task : MonoBehaviour
{
    public string Task_text;

    [HideInInspector] public GameObject CheckMark;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshPro>().text = Task_text;
        CheckMark = transform.Find( "Checkbox/Check" ).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckActive( ) {
        CheckMark.SetActive( true );
	}

    public void CheckInactive( ) {
        CheckMark.SetActive( false );
	}
}
