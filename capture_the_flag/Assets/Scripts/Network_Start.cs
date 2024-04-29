using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class Network_Start : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GlobalVariables.Netwokrtype == "host")
        {
            NetworkManager.Singleton.StartHost();
        }
        else if(GlobalVariables.Netwokrtype == "client")
        {
            var unitytransport = NetworkManager.GetComponent<UnityTransport>();
            unitytransport.SetConnectionData(GlobalVariables.ConnectionIP, 7777);
            NetworkManager.Singleton.StartClient();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
