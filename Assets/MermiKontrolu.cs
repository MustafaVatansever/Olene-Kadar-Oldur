using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiKontrolu : MonoBehaviour
{
     private void OnCollisionEnter(Collision collision)
    {
        var carptigiObjeninCani = collision.gameObject.GetComponent<OyuncununCani>();

        if (carptigiObjeninCani != null)
        {
            carptigiObjeninCani.HasarAl(30);
        }
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
