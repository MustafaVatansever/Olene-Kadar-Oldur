using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class OyuncununCani : NetworkBehaviour
{
    public const int can = 150;
    [SyncVar(hook = "CanDegisikligi")]
    private int guncelCan = can;
    public bool dusmanMi;

    public RectTransform CanCubugununGuncelCani;

    private NetworkStartPosition[] dogmaNoktalari;

    void Start()
    {
        if (isLocalPlayer)
        {
            dogmaNoktalari = FindObjectsOfType<NetworkStartPosition>();
           
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HasarAl(int hasarMiktari)
    {
        if (!isServer)
        {
            return;
        }

        guncelCan -= hasarMiktari;

        if (guncelCan <= 0)
        {
            if (dusmanMi)
            {
                Destroy(gameObject);
            }
            else
            {
                guncelCan = can;
                RpcYenidenDogma();
            }
            
        }

        
    }

    void CanDegisikligi(int guncelCanDegeri)
    {
        CanCubugununGuncelCani.sizeDelta = new Vector2(guncelCanDegeri, CanCubugununGuncelCani.sizeDelta.y);
    }
    [ClientRpc]
    void RpcYenidenDogma()
    {
        
        if (isLocalPlayer || isServer)
        {
            //   transform.position = Vector3.zero;
           Vector3 OyuncununDogmaNoktasi = transform.position;
            if (dogmaNoktalari != null && dogmaNoktalari.Length > 0)
            {
                OyuncununDogmaNoktasi = dogmaNoktalari[Random.Range(0,dogmaNoktalari.Length)].transform.position;
            }
            transform.position = OyuncununDogmaNoktasi;
        }
    }

}
