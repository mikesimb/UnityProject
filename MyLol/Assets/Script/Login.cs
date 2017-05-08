using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	public InputField edt_username;
	[SerializeField]
	public InputField edt_password;
	[SerializeField]
	private Button loginBtn;


	[SerializeField]
	public InputField edt_reg_username;
	[SerializeField]
	public InputField edt_reg_password;
	[SerializeField]
	public InputField edt_reg_repeat_password;
	[SerializeField]
	private Button btn_reg_regitster;

	[SerializeField]
	private GameObject regpanel;


	[SerializeField]
	private GameObject MessageBox;

	[SerializeField]
	private Text MessageInfo;
	public void LoginOnClick(){
	
		if (edt_username.text.Length == 0 || edt_username.text.Length > 6) {
			Debug.Log("账号不合法");
			return;
		}

		if (edt_password.text.Length == 0 || edt_password.text.Length > 6) {
		
			Debug.Log ("密码不合法");
			return;
		}
		loginBtn.enabled = false;

		Debug.Log("申请登陆");
	}

	public void ShowRegPanel()
	{
		regpanel.SetActive (true);
	}

	public void HideRegPanel()
	{
		regpanel.SetActive (false);
	}


	public void RegeditUsername()
	{
		if (edt_reg_username.text.Length == 0 || edt_reg_username.text.Length > 6) {
			MessageInfo.text = "账号不合法";
			MessageBox.SetActive (true);
			return;
		}else
		if (edt_reg_password.text.Length == 0 || edt_reg_password.text.Length > 6) {
			MessageInfo.text = "密码不合法";
			MessageBox.SetActive (true);
			return;
		}else
		if (!edt_reg_password.text.Equals(edt_reg_repeat_password.text)) {
				MessageInfo.text = "两次输入的密码不一致";
				MessageBox.SetActive (true);
				return;
			}
						
		MessageInfo.text = "注册通过";
		MessageBox.SetActive (true);
		//HideRegPanel ();



	}

	public void CloseMessageBox()
	{
		MessageBox.SetActive (false);
	}
	public 
	void Start () {
		//Debug.Log ("function start");
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("function update");
	}
}
