using kcp2k;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uSurvival;

//added by ConveyorXDeV
public class ServerArgsReader : MonoBehaviour
{
    public NetworkManagerSurvival networkManager;
    public KcpTransport transport;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsServer || Application.platform == RuntimePlatform.LinuxServer || Application.platform == RuntimePlatform.OSXServer)
        {

            string[] args = System.Environment.GetCommandLineArgs();

            if (args.Length < 2)
            {
                Debug.Log("ERR: non-correct arguments in app start!");
                return;
            }

            networkManager.networkAddress = args[1].TrimStart('-');
            ushort.TryParse(args[2].TrimStart('-'), out transport.port);

            Debug.Log(args[1] + "\n" + args[2]);
            Debug.Log("[CX] IP: " + networkManager.networkAddress + "\n" + "Port: " + transport.port);
            Invoke("StartServer", 0.5f);
        }
    }

    private void StartServer() 
    {
        Debug.Log("[CX] Starting Server...");

        //automatically start the server!
        networkManager.StartServer();
    }
}
