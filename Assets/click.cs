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
        if (!GM.Current.isPlaying)
        {
            return;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f)) {
            point = hit.point;
        }


        Instantiate(DriedelPrefab, point, Quaternion.Euler(270,0,0));

    }


    public void ClearDreidels()
    {
        var dreidels = FindObjectsOfType<Spin>();
        foreach (var item in dreidels) {
            Destroy(item.gameObject);
        }
    }
}
