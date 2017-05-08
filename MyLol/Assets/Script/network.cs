using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class network : MonoBehaviour {

	[SerializeField]
	private InputField edt_ipaddress;
	[SerializeField]
	private InputField edt_port;



	public void ConnectBtnClick(){	
		string ipaddress = edt_ipaddress.text;
		int port = int.Parse(edt_port.text);
		if (Network.peerType == NetworkPeerType.Disconnected) {
			NetworkConnectionError error=Network.Connect(ipaddress, port);
			if (error != NetworkConnectionError.NoError)
				Debug.Log ("连接成功");
			}

		
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
