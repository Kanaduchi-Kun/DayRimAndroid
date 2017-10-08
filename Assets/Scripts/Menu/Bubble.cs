using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour
{
    public float minSpeed, maxSpeed;
    public float minScale, maxScale;
    public float minDistance, maxDistance;
    private float thisSpeed;
    private float thisScale;
    private float thisDistance;


    void Start()
    {
        thisSpeed = Random.Range(minSpeed, maxSpeed); // random Geschwindigkeit
        thisScale = Random.Range(minScale, maxScale); // random Größe
        thisDistance = Random.Range(minDistance, maxDistance); // random Strecke, die zurückgelegt werden kann, bevor Bubble platzt

        this.transform.localScale = new Vector3(thisScale, thisScale, thisScale);
    }

    void Update()
    {
        // Bubble zerstören, wenn Distanz zurückgelegt
        if (this.transform.position.y >= thisDistance)
            Destroy(this.gameObject);

        // Automatisches Aufsteigen nach Spawn
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, 15, this.transform.position.z), thisSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision) // Bubbles zerstören, wenn sie etwas berühren
    {
        if (collision.gameObject.tag != "Bubble")
            Destroy(this.gameObject);
    }
}
