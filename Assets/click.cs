using UnityEngine;
using System.Collections;

public class click : MonoBehaviour {

    public GameObject DriedelPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Vector3 point;
    void OnMouseDown()
    {

        //Vector3 mousePosition = Input.mousePosition;
        //Debug.Log(mousePosition);
        //mousePosition.z += 10;
        //point = Camera.main.ScreenToWorldPoint(mousePosition);
        //Debug.Log(point);


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f)) {
            point = hit.point;
            point.z -= 2;
        }


        Instantiate(DriedelPrefab, point, Quaternion.Euler(270,0,0));

    }


    void OnMouseDrag()
    {
    }
}
