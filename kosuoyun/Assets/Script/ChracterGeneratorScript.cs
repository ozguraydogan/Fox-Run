using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterGeneratorScript : MonoBehaviour
{
    public GameObject[] YanKarakterler;
    public Vector3[] konum;
    int Karakter;
    int random;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("nesne_olustur", 0, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //private void OnTriggerEnter(Collider other)
    //{

    //    if (other.gameObject.tag == "Coin" || other.gameObject.tag == "traps")
    //    {
    //        Destroy(other.gameObject);
    //        Debug.Log("Yok edildi");
    //    }
    //}

    void nesne_olustur()
    {
        random = Random.Range(0, 3);
        Karakter = Random.Range(0, 2);
        Instantiate(YanKarakterler[Karakter], konum[random],transform.rotation);


    }
}
