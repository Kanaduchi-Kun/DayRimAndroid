using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BatteryLife {

	//public Text batteryText;
	public static float fakeBatteryLife = 100;
	public static bool onSmartphone = true;

	// Use this for initialization
	void Start () {
	
		//Debug.Log(GetBatteryLevel ());

	}
	
	// Update is called once per frame
	void Update () {

		//batteryText.text = "Battery Life: " + GetBatteryLevel ();

	}



	public static float GetBatteryLevel()
	{
		//HACK returning Battery life for PC use (if else)

		#if UNITY_IOS
		UIDevice device = UIDevice.CurrentDevice();
		device.batteryMonitoringEnabled = true; // need to enable this first
		Debug.Log("Battery state: " + device.batteryState);
		Debug.Log("Battery level: " + device.batteryLevel);
		return device.batteryLevel*100;
		#elif UNITY_ANDROID

		if (Application.platform == RuntimePlatform.Android)
		{
			try
			{
				using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				{
					if (null != unityPlayer)
					{
						using (AndroidJavaObject currActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
						{
							if (null != currActivity)
							{
								using (AndroidJavaObject intentFilter = new AndroidJavaObject("android.content.IntentFilter", new object[]{ "android.intent.action.BATTERY_CHANGED" }))
								{
									using (AndroidJavaObject batteryIntent = currActivity.Call<AndroidJavaObject>("registerReceiver", new object[]{null,intentFilter}))
									{
										int level = batteryIntent.Call<int>("getIntExtra", new object[]{"level",-1});
										int scale = batteryIntent.Call<int>("getIntExtra", new object[]{"scale",-1});

										// Error checking that probably isn't needed but I added just in case.
										if (level == -1 || scale == -1)
										{
											return 50f;
										}
										return ((float)level / (float)scale) * 100.0f; 
									}

								}
							}
						}
					}
				}
			} 
			
			catch (System.Exception ex)
			{

			}
		}

		return 100;
		#endif

		//HACK for PC users
		return fakeBatteryLife;
		

		
	}


 }
