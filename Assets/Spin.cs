using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

    private Rigidbody rigidBody;
    public int minSpinSpeed = 500;
    public int maxSpinSpeed = 1000;

    // Use this for initialization
    void Start () {
        this.rigidBody = this.GetComponent<Rigidbody>();
        rigidBody.centerOfMass = new Vector3(0, Random.Range(-.1f,.1f), .7f);
        rigidBody.maxAngularVelocity = maxSpinSpeed;
        rigidBody.AddTorque(0, Random.Range(minSpinSpeed, maxSpinSpeed), 0);
        //rigidBody.angularVelocity = new Vector3(0, spinSpeed, 0);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
