using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Services;
using SkillBridge.Message;

public class UILogin : MonoBehaviour
{

    public InputField username;
    public InputField password;
    public Toggle agreement;
    public Toggle rememberPassword;
    public Button buttonLogin;

    void Start()
    {
        UserService.Instance.OnLogin = this.OnLogin;
    }


    void Update()
    {

    }


    public void OnClickLogin()
    {
        if (string.IsNullOrEmpty(this.username.text))
        {
            MessageBox.Show("请输入账号");
            return;
        }
        if (string.IsNullOrEmpty(this.password.text))
        {
            MessageBox.Show("请输入密码");
            return;
        }
        if (!agreement.isOn)
        {
            MessageBox.Show("请阅读并同意相关协议");
            return;
        }
        UserService.Instance.SendLogin(this.username.text, this.password.text);
    }

    void OnLogin(SkillBridge.Message.Result result, string msg)
    {
        if (result == Result.Success)
        {
            //登录成功，进入角色选择
            MessageBox.Show("登录成功，准备角色选择" + msg, "提示", MessageBoxType.Information);
            SceneManager.Instance.LoadScene("CharSelect");
        }
        else
        {
            MessageBox.Show(msg, "错误", MessageBoxType.Error);
        }
    }

}
