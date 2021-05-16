using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Obje : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 20f);
    }
}
