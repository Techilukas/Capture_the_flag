using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_btn : MonoBehaviour
{
    public Button btn_host;
    public Button btn_client;
    public TMP_Text IP_txt;
    public TMP_InputField IP_input;
    
    // Start is called before the first frame update
    void Start()
    {
        btn_host.onClick.AddListener(starthost);
        btn_client.onClick.AddListener(startclient);
        IP_txt.text = LocalIPAddress();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void starthost()
    {
        GlobalVariables.Netwokrtype = "host";
        SceneManager.LoadScene("Main_Game");
    }

    void startclient()
    {
        GlobalVariables.Netwokrtype = "client";
        GlobalVariables.ConnectionIP = IP_input.text;
        SceneManager.LoadScene("Main_Game");
    }

    public string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP += ip.ToString() +"\n";
                
            }
        }
        return localIP;
    }

    
}
