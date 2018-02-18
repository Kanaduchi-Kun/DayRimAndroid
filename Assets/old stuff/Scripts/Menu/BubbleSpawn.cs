using UnityEngine;
using System.Collections;

public class BubbleSpawn : MonoBehaviour
{
    public GameObject bubbleObject; // prefab
    public float minX, maxX, minZ, maxZ; // Bereich, in dem Bubbles spawnen
    public float minWaitTime, maxWaitTime; // Wartezeit zwischen dem Spawnen

	//private BatteryLife batteryLevel;

	void Start()
	{

		//batteryLevel = new BatteryLife ();
	}


    void Update()
    {
        waitForNextSpawn();
    }

    void waitForNextSpawn()
    {
        float timer = Random.Range(minWaitTime, maxWaitTime); // random Zeit, bevor eine Bubble gespawnt wird

		timer -= Time.deltaTime * (BatteryLife.GetBatteryLevel () * 0.1f );

        if (timer <= 0)
        {
            Instantiate(bubbleObject, new Vector3(Random.Range(minX, maxX), this.transform.position.y, Random.Range(minZ, maxZ)), Quaternion.identity);
            timer = Random.Range(minWaitTime, maxWaitTime);
        }
    }
}
