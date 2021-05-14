using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter_kontrol : MonoBehaviour
{
    [SerializeField] int hiz=10;
    [SerializeField] float NereyeKadar;
    public int slot;
    public string nerede;
   
    Rigidbody rb;
    // Use this for initialization
    void Start () {
       
       
    }
	
    // Update is called once per frame
    void FixedUpdate () {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(NereyeKadar, 0, hiz);
        if (Input.GetKeyDown(KeyCode.A) &&  slot>1 && nerede=="ortada")
        {
            NereyeKadar = -4;
            StartCoroutine(OrtayaAl());
            slot -= 1;
            nerede = "yan";
        }
        if (Input.GetKeyDown(KeyCode.D) && slot < 3 && nerede == "ortada")
        {
            NereyeKadar = 4;
            StartCoroutine(OrtayaAl());
            slot += 1;
            nerede = "yan";
        }
    }
    IEnumerator OrtayaAl()
    {
        yield return new WaitForSeconds(0.4f);
        nerede = "ortada";
        NereyeKadar = 0;
            
    }
 
}

