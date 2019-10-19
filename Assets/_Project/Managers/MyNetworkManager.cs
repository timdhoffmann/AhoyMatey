using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager
{
    public void StartAsHost()
    {
        Debug.Log(Time.timeSinceLevelLoad + ": Starting Host.");
        StartHost();
    }

    public override void OnStartHost()
    {
        Debug.Log(Time.timeSinceLevelLoad + ": Host started.");
    }

    public override void OnStartClient (NetworkClient client)
    {
        base.OnStartClient(client);
        Debug.Log(Time.timeSinceLevelLoad + ": Client started.");
        InvokeRepeating("IndicateConnecting", 0f, 1f);
    }

    public override void OnClientConnect (NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        Debug.Log(Time.timeSinceLevelLoad + ": Client connected to address " + conn.address);
        CancelInvoke();
    }

    private void IndicateConnecting()
    {
        Debug.Log("...connecting.");
    }
}
