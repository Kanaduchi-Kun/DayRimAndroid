using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SoundLevel : MonoBehaviour {

	public Text soundText;

	// Use this for initialization
	void Start () {

		soundText.text = "Sound Volume: " + GetSoundLevel ();
	}
	
	// Update is called once per frame
	void Update () {
	



	}

	public static string GetSoundLevel()
	{
		#if UNITY_IOS
		UIDevice device = UIDevice.CurrentDevice();
		device.batteryMonitoringEnabled = true; // need to enable this first
		Debug.Log("Battery state: " + device.batteryState);
		Debug.Log("Battery level: " + device.batteryLevel);
		return device.batteryLevel*100;
		#elif UNITY_ANDROID

		string text = "";

		if (Application.platform == RuntimePlatform.Android)
		{
			

			try
			{
				using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				//using (AndroidJavaClass audioManager = new AndroidJavaClass("android"))
				{

					if (null != unityPlayer)
					{
						using (AndroidJavaObject currActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
						{
							
							if (null != currActivity)
							{

								//using (AndroidJavaObject audioManager = new AndroidJavaObject("android.content.getSystemService", new object[]{ "Context.AUDIO_SERVICE" }))
								//using (AndroidJavaObject audioManager = new AndroidJavaObject("android.media.AudioManager", new object[]{ "android.Context.getSystemService(android.Context.AUDIO_SERVICE)" }))
								using (AndroidJavaObject audioManager = currActivity.Call<AndroidJavaObject>("getSystemService", new object[]{ "android.Context.AUDIO_SERVICE" }))
								//using (AndroidJavaObject audioManager = currActivity.Call<AndroidJavaObject>("getSystemService", new object[]{ "android.Context.getSystemService(android.Context.AUDIO_SERVICE)" }))
								{

									return text = "alles gut!";

								}
								/*using (AndroidJavaObject intentFilter = new AndroidJavaObject("android.content.IntentFilter", new object[]{ "android.media.VOLUME_CHANGED_ACTION" }))
								{

									using (AndroidJavaObject volumeIntent = currActivity.Call<AndroidJavaObject>("getExtras", new object[]{"android.media.EXTRA_VOLUME_STREAM_VALUE"}))
									{
										return text = "alles gut!";

										Debug.Log("Stage 4 -Check!");
										int value = volumeIntent.Call<int>("getExtras", new object[]{"android.media.EXTRA_VOLUME_STREAM_VALUE"});

										return value + "";

									}

								}*/
							}
						}
					}
				}
			} catch (System.Exception ex)
			{
				text = ex.Message;
			}
		}

		return text;
		#endif

		//HACK for Pc users
		string tempText = "50";
		return tempText;
	}

}
