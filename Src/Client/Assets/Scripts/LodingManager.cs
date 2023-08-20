using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

using SkillBridge.Message;
using ProtoBuf;

public class LodingManager : MonoBehaviour {
	public Slider loadingSlider;
	public Text loadingText;
	public Text loadingAmount;

	private string sceneName = "LoginAndRegister";
	IEnumerator Start()
	{
		log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo("log4net.xml"));
		UnityLogger.Init();
		Common.Log.Init("Unity");
		Common.Log.Info("LoadingManager start");

		for (float i = 10; i < 100;)
		{
			i += Random.Range(0.1f, 1.5f);
			loadingSlider.value = i;
			loadingAmount.text = (int)i + "%";
			yield return new WaitForEndOfFrame();
		}
		yield return null;

		Application.LoadLevel(sceneName);
	} 

}
