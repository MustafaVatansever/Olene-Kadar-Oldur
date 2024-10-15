using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OyuncuKontrolu : NetworkBehaviour
{
    public Transform MermimizinCikisNoktasi;
    public GameObject Mermi;
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            CmdAtesEtme();
        }

        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 100f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 4f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
    [Command]
    public void CmdAtesEtme() 
    {
        GameObject mermimiz = Instantiate(Mermi,MermimizinCikisNoktasi.position,MermimizinCikisNoktasi.rotation) as GameObject;
        mermimiz.GetComponent<Rigidbody>().velocity = transform.forward * 5;

        NetworkServer.Spawn(mermimiz);
        Destroy(mermimiz,4);
    }

}
