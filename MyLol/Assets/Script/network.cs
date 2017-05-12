using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;
public class network : MonoBehaviour {

	[SerializeField]
	private InputField edt_ipaddress;
	[SerializeField]
	private InputField edt_port;

    private Socket socket = null;
    private int i = 0;
    private NetworkStream networkStream;
    private TcpClient tcpClient;

    public void ConnectBtnClick(){
        InitSocket();


    }

    void OnConnectedToServer()
    {
        Debug.Log("This CLIENT has connected to a server");
    }

    void OnDisconnectedFromServer(NetworkDisconnection info)
    {
        Debug.Log("This SERVER OR CLIENT has disconnected from a server");
    }

    void OnFailedToConnect(NetworkConnectionError error) {
                Debug.Log("Could not connect to server: " + error);
        }




        // Use this for initialization
        void Start () {
       
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InitSocket()
    {
        if(socket != null)
        {
            socket.Close();
            socket = null;

        }

        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.100"),7001));
        Thread thread = new Thread(new ThreadStart(addThread));
        thread.IsBackground = true;
        thread.Start();

    }

    private void addThread()
    {
        bool live = true;
        while(live)
        {
            try
            {
                byte[] bytes = new byte[byte.MaxValue];
                socket.Receive(bytes);
                Debug.Log(Encoding.UTF8.GetString(bytes));

            }
            catch(SocketException exe)
            {
                live = false;
                socket.Close();
                socket = null;
            }
        }
    }

    void getData(object s)
    {
        bool live = true;
        Socket so = (Socket)s;

        if(live)
        {
            try
            {
                byte[] bytes = new byte[byte.MaxValue];
                so.Receive(bytes);
                Debug.Log(Encoding.UTF8.GetString(bytes));
            }
            catch(Exception e)
            {
                live = false;
            }
        }

    }

    private void Send()
    {
        i++;
        try
        {
            byte[] bytes = Encoding.UTF8.GetBytes("data" + i);
            socket.Send(bytes);
        }
        catch(Exception e)
        {
            socket.Close();
            socket = null;
        }
    }
}
