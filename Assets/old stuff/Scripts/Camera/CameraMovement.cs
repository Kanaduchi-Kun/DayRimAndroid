using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
	private DeviceOrientation currentOrientation;

    public float speed;
    public float zoom;

    public bool isSceneIndoor;
    

    // Use this for initialization
    void Start()
    {
       // transform.position = new Vector3(ActiveCharacter.activeCharacter.transform.position.x , this.transform.position.y, -10);

		currentOrientation = DeviceOrientation.LandscapeRight;
        this.GetComponent<Camera>().orthographicSize = zoom;

		if(!isSceneIndoor)
			transform.position = new Vector3 (-4.5f, -6.7f, -zoom);

       
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject.Find("Text").GetComponent<Text>().text = (this.GetComponent<Camera>().transform.position).ToString();

        if (!CanvasNavigator.inventar_isActive)
        {
			if (!isSceneIndoor) {
				if (currentOrientation == DeviceOrientation.LandscapeRight && Input.deviceOrientation == DeviceOrientation.Portrait) {
					currentOrientation = DeviceOrientation.Portrait;
					// y auf -3.4 und rotation um 90
					transform.position = new Vector3 (this.transform.position.x, -2.8f, -zoom);
					transform.Rotate (new Vector3 (0, 0, 90));
				} else if (currentOrientation == DeviceOrientation.Portrait && Input.deviceOrientation == DeviceOrientation.LandscapeRight) {
					currentOrientation = DeviceOrientation.LandscapeRight;
					//y auf -6.4 und rotation auf 0
					transform.position = new Vector3 (this.transform.position.x, -6.7f, -zoom);
					transform.Rotate (new Vector3 (0, 0, -90));
				}
			

				if (this.GetComponent<Camera> ().transform.position.x <= -8.4f) {
					transform.position = new Vector3 (-8.3f, this.transform.position.y, -zoom);
				} else if (this.GetComponent<Camera> ().transform.position.x > 8.4f) {
					transform.position = new Vector3 (8.3f, this.transform.position.y, -zoom);
				}
			}

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (!isSceneIndoor)
                {

					//what to do with orientation 
					if (currentOrientation == DeviceOrientation.LandscapeRight)
					{
							currentOrientation = DeviceOrientation.LandscapeRight;


						
						//in bestimmten radius 
						if ((this.GetComponent<Camera> ().transform.position.x >= -8.4f && this.GetComponent<Camera> ().transform.position.x <= 8.4f))
							{
						  //  && (this.GetComponent<Camera> ().transform.position.y >= -6.0f && this.GetComponent<Camera> ().transform.position.y <= 6.0f)) {

							Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
							//transform.Translate (-touchDeltaPosition.x * speed * Time.deltaTime, -touchDeltaPosition.y * speed * Time.deltaTime, 0);
							transform.Translate (-touchDeltaPosition.x * speed * Time.deltaTime,0 , 0);
						} else {
							
							if (this.GetComponent<Camera> ().transform.position.x <= -8.4f) {
								transform.position = new Vector3 (-8.3f, this.transform.position.y, -zoom);
							} else if (this.GetComponent<Camera> ().transform.position.x > 8.4f) {
								transform.position = new Vector3 (8.3f, this.transform.position.y, -zoom);
							}
						}
					} 

					else if(currentOrientation == DeviceOrientation.Portrait)
					{
						if ((this.GetComponent<Camera> ().transform.position.x >= -8.4f && this.GetComponent<Camera> ().transform.position.x <= 8.4f))
						{


							Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
							//transform.Translate (-touchDeltaPosition.x * speed * Time.deltaTime, -touchDeltaPosition.y * speed * Time.deltaTime, 0);
							transform.Translate (0 ,-touchDeltaPosition.y * speed * Time.deltaTime , 0);
						} else {
							
							Debug.Log ("Ja ne!");


							if (this.GetComponent<Camera> ().transform.position.x <= -8.4f) {
								transform.position = new Vector3 (-8.3f, this.transform.position.y, -zoom);
							} else if (this.GetComponent<Camera> ().transform.position.x > 8.4f) {
								transform.position = new Vector3 (8.3f, this.transform.position.y, -zoom);
							}

						}
					}
                }//bis hier hin Outdoor Szenen vom Schrottplatz

                else
                {
                   

                    if (this.GetComponent<Camera>().transform.position.x >= -12.5f && this.GetComponent<Camera>().transform.position.x <= 12.5f)
                    {

                        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                        transform.Translate(-touchDeltaPosition.x * speed * Time.deltaTime, 0, 0);
                    }
                    else {
                        if (this.GetComponent<Camera>().transform.position.x < -12.5f)
                        {
                            transform.position = new Vector3(-12.4f, this.GetComponent<Camera>().transform.position.y, - zoom);
                        }

                        else if (this.GetComponent<Camera>().transform.position.x > 12.5f)
                        {
                            transform.position = new Vector3 ( 12.4f, this.GetComponent<Camera>().transform.position.y, -zoom);
                        }
                    }
                }
            }
        }

    }
}
