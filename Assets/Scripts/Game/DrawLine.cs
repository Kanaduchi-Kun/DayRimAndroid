using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DrawLine : MonoBehaviour 
{
    
	private SoundManager soundManager;
	private bool isMousePressed, isTouchPressed;
	private List<Vector3> pointsList;
    private List<Vector3> pointsCheck;
    private List<Vector3> markerList;
    public int countMarker;
    private Vector3 caseA;
    private Vector3 caseB;
    private Vector3 caseC;
    private Vector3 caseD;
    private Vector3 caseE;
    private Vector3 caseF;

    private Vector3 mousePos;
    private Vector3 touchPos;
    
    private int count=0;
    private GameObject[] lines;
    private Touch touch;
 
    private SpriteRenderer zeichenfeld;
    public bool check;


    private AudioSource spraying;

	private bool fertig = false;
    
    struct myLine
	{
		public Vector3 StartPoint;
		public Vector3 EndPoint;
	}
	
	void Start()
	{
		soundManager = GetComponent <SoundManager>();
        markerList = new List<Vector3>();
        touch = new Touch();
        zeichenfeld = GetComponent<SpriteRenderer>();
        spraying = GetComponent<AudioSource>();
       
        setMarker();
        Debug.Log(zeichenfeld.sprite.textureRect.size);
        lines = new GameObject[1000];
		
        lines[count] = new GameObject();
        lines[count].AddComponent<LineRenderer>();
        
        lines[count].gameObject.GetComponent<LineRenderer>().material =  new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
      
        lines[count].gameObject.GetComponent<LineRenderer>().SetVertexCount(0);
        lines[count].gameObject.GetComponent<LineRenderer>().SetWidth(0.4f,0.4f);
        lines[count].gameObject.GetComponent<LineRenderer>().SetColors(Color.red, Color.red);
        lines[count].gameObject.GetComponent<LineRenderer>().useWorldSpace = true;
        

        isMousePressed = false;
        isTouchPressed = false;
        
		pointsList = new List<Vector3>();
        pointsCheck = new List<Vector3>();
		   
    }


	void Update () 
	{

        if (Input.GetMouseButtonDown(0))
		{
			if(fertig == false){
				Debug.Log("BEGAN MOUSE");
				isMousePressed = true;

				if(!spraying.isPlaying)
				{
					spraying.loop = true;
					spraying.Play();
				}

					
	            pointsList.RemoveRange(0,pointsList.Count); //wichtig damit neue line gezeichnet wird und nicht am punkt von der anderen weiter
			}
        
		}
			

		if (Input.touchCount > 0)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began)
			{
				isTouchPressed = true;
				Debug.Log("BEGAN TOUCH");

			} 
			else if(Input.GetTouch(0).phase == TouchPhase.Ended)
			{
				Debug.Log("TOUCH BEENDET");

				spraying.loop = false;
				spraying.Stop();

				count++;
				lines[count] = new GameObject();
				lines[count].AddComponent<LineRenderer>();

				lines[count].gameObject.GetComponent<LineRenderer>().material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
				lines[count].gameObject.GetComponent<LineRenderer>().SetVertexCount(0);
				lines[count].gameObject.GetComponent<LineRenderer>().SetWidth(0.4f, 0.4f);
				lines[count].gameObject.GetComponent<LineRenderer>().SetColors(Color.red, Color.red);
				lines[count].gameObject.GetComponent<LineRenderer>().useWorldSpace = true;
				isMousePressed = false;
				isTouchPressed = false;

			}

		}

        
        if (isMousePressed)
        {
			if(fertig == false){

            if ((Input.mousePosition.y > 0 && Input.mousePosition.y < zeichenfeld.sprite.textureRect.height && Input.mousePosition.x > 0 && Input.mousePosition.x < zeichenfeld.sprite.textureRect.width))
                
            {
        

                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;

                if (!pointsList.Contains(mousePos))
                {
                    pointsList.Add(mousePos);
                    pointsCheck.Add(mousePos);


                    lines[count].gameObject.GetComponent<LineRenderer>().SetVertexCount(pointsList.Count);
                    
                    lines[count].gameObject.GetComponent<LineRenderer>().SetPosition(pointsList.Count -1 , (Vector3)pointsList[pointsList.Count - 1]);
                  
         
                }
				}
			}
			isTouchPressed = false;
        }

        else if(isTouchPressed)
        {
			


		    if(touch.position.y > 0 && touch.position.y < zeichenfeld.sprite.textureRect.height && touch.position.x > 0 && touch.position.x < zeichenfeld.sprite.textureRect.width)
            {
                touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                
                touchPos.z = 0;


                if (!pointsList.Contains(touchPos))
                {

                    pointsList.Add(touchPos);
                    pointsCheck.Add(touchPos);
                    lines[count].gameObject.GetComponent<LineRenderer>().SetVertexCount(pointsList.Count);
                    lines[count].gameObject.GetComponent<LineRenderer>().SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);
				}
            }
			isTouchPressed = false;
        }
    }
  


    private bool checkPoints (Vector3 pointA, Vector3 pointB)
	{
		return (pointA.x == pointB.x && pointA.y == pointB.y);
	}


    public bool checkDrawing()
    {
		if(spraying.isPlaying)
		{
			spraying.loop = false;
			spraying.Stop();
		}

		countMarker = 0;

        for (int i = 0; i < markerList.Count; i++)
        {

            for (float j = 0; j < 0.6F; j = j + 0.1F)
            {

                caseA.x = markerList[i].x + j;
                caseA.y = markerList[i].y + j;
                caseB.x = markerList[i].x - j;
                caseB.y = markerList[i].y - j;
                caseC.x = markerList[i].x;
                caseC.y = markerList[i].y + j;
                caseD.x = markerList[i].x;
                caseD.y = markerList[i].y - j;
                caseE.x = markerList[i].x + j;
                caseE.y = markerList[i].y;
                caseF.x = markerList[i].x - j;
                caseF.y = markerList[i].y;
          
                for (int k = 0; k < pointsCheck.Count; k++) 
				{
                    
					if ((Vector3.Distance(pointsCheck[k], caseA) <= 0.1)|| (Vector3.Distance(pointsCheck[k], caseB) <= 0.1) || (Vector3.Distance(pointsCheck[k], caseC) <= 0.1) || (Vector3.Distance(pointsCheck[k], caseD) <= 0.1) || (Vector3.Distance(pointsCheck[k], caseE) <= 0.1) || (Vector3.Distance(pointsCheck[k], caseF) <= 0.1))
					{
						countMarker++;
						if(countMarker >= 150)
						{
					    check = true;
						}
							
					    
					
					}

					else
					{
						check = false;  
					}


                	if (check)
                	{
                	    break;
                	}


            	}

				if (check)
				{
				    break;
				}
					
			}
			if (check)
			{
				break;
			}
        }
			
		return check;
    }


    private void setMarker()//Werte der Punkte die beim Zeichnen getroffen werden müssen.
    {

        markerList.Add(new Vector3(6.1F, -1.5F)); //v
        markerList.Add(new Vector3(6F, -3.7F)); //a
        markerList.Add(new Vector3(2.6F, -2.7F)); //b
        markerList.Add(new Vector3(-0.5F, -3.6F)); //c
        markerList.Add(new Vector3(-2.3F, -2.8F)); //d
        markerList.Add(new Vector3(-4.9F, -4.0F)); //e
        markerList.Add(new Vector3(6.1F, 0.2F)); //f
        markerList.Add(new Vector3(2.8F, 0.7F)); //g
        markerList.Add(new Vector3(2.3F, -0.5F)); //h
        markerList.Add(new Vector3(0.0F, -1.4F)); //i
        markerList.Add(new Vector3(-5.5F, -1.8F)); //k
        markerList.Add(new Vector3(4.9F, 2.7F)); //l
        markerList.Add(new Vector3(2.4F, 1.8F)); //m
		markerList.Add(new Vector3(0.4F, 4.4F)); //n
        markerList.Add(new Vector3(0.1F, 2.4F)); //o
        markerList.Add(new Vector3(-1.4F, 2.1F)); //p
        markerList.Add(new Vector3(1.5F, 2.3F)); //q
        markerList.Add(new Vector3(-4.2F, 3.5F)); //s
        markerList.Add(new Vector3(-3F,0.3F)); //t
        markerList.Add(new Vector3(-6.1F, 0.3F)); //u
        markerList.Add(new Vector3(-2.6F, 1.4F)); //r
        markerList.Add(new Vector3(-2.8F, -0.6F)); //w

    }


    public void ButtonFunc()//Funktion für die Button, in der die Prüf funktion aufgerufen wird
    {
		if(spraying.isPlaying)
		{
			spraying.loop = false;
			spraying.Stop();
		}

		//Warten Text
		fertig = true;

		if (checkDrawing())
			{
				Debug.Log("checking button");
			    //szenenwechsel
			    //SceneManager.LoadScene(SceneNameManager.junkyardFirst);
			    SceneManager.LoadScene("Junkyard_Scene_01");      
			}
			
			else
			{
				//Falsch Text
			    //bild zurück setzen
			    deleteLines();
				SceneManager.LoadScene("GameScene");

			  
			}

    }

    public void deleteLines()//Löscht die gezeichneten Linien und setzt die Listen/Variablen zurück
    {

        for(int i = count-1; i >= 0; i--)
        {  
            GameObject.Destroy(lines[i]);
            
        }

        countMarker = 0;
        count = 0;
        check = false;
        lines = new GameObject[1000];
        lines[count] = new GameObject();
        pointsList = new List<Vector3>();
        pointsCheck = new List<Vector3>();

    }


    


}