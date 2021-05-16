using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sahne_Hareket : MonoBehaviour
{

    public float hiz = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.forward * Time.deltaTime * hiz;

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
