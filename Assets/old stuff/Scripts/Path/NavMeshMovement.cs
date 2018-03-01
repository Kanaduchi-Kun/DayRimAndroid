using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent navMeshAgent;

    public static NavMeshMovement instance;
    // Use this for initialization

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }

    void Start () {

        cam = Camera.main;

        // setting Aangular Speed to 0 in the nav mesh agent allows the paper to always stay in the same angle while moving =)
        navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
        /*
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }
        */

	}

    public void Move(Vector3 touchPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //ohne es wieder false zu setzen würde der character nicht wieder laufen, weil er im data controller nach dem laden gestoppt wird.
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(hit.point);
          
  

        }
    }
}
