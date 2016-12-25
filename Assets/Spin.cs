using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spin : MonoBehaviour {

    private new Rigidbody rigidbody;
    public int minSpinSpeed = 500;
    public int maxSpinSpeed = 1000;
    private bool isResting = true;

    const float RESTING_SPEED = .05f;
    const float VALID_STARTING_SPEED = 10f;


    private List<Vector3> directions = new List<Vector3>();
    private List<DriedelSides> sideValues = new List<DriedelSides>();

    void Awake()
    {
        if (directions.Count == 0)
        {
            // Object space directions
            directions.Add(Vector3.up);
            sideValues.Add(DriedelSides.Shin); // up
            directions.Add(Vector3.down);
            sideValues.Add(DriedelSides.Gimel); // down

            directions.Add(Vector3.left);
            sideValues.Add(DriedelSides.Nun); // left
            directions.Add(Vector3.right);
            sideValues.Add(DriedelSides.Hey); // right

            directions.Add(Vector3.forward);
            sideValues.Add(DriedelSides.Up); // forward
            directions.Add(Vector3.back);
            sideValues.Add(DriedelSides.UpsideDown); // back
        }

        // Assert equal side of lists
        if (directions.Count != sideValues.Count)
        {
            Debug.LogError("Not consistent list sizes");
        }
    }
    // Use this for initialization
    void Start () {
        this.rigidbody = this.GetComponent<Rigidbody>();
        StartSpin();
    }

    void StartSpin()
    {
        rigidbody.centerOfMass = new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f), .7f);
        rigidbody.maxAngularVelocity = maxSpinSpeed;
        rigidbody.AddTorque(0, Random.Range(minSpinSpeed, maxSpinSpeed), 0, ForceMode.Force);
    }

    // Update is called once per frame
    void Update () {
	    if(!isResting && rigidbody.angularVelocity.magnitude < RESTING_SPEED)
        {
            isResting = true;
            Debug.Log("Resting");
            var letter = GetLetter(Vector3.up);
            Debug.Log(letter);
            GM.Current.EndOfTurn(letter);
        }
        else if(isResting && rigidbody.angularVelocity.magnitude > VALID_STARTING_SPEED)
        {
            isResting = false;
            Debug.Log("Starting");
        }
    }

    public DriedelSides GetLetter(Vector3 referenceVectorUp, float epsilonDeg = 90f)
    {
        // here I would assert lookup is not empty, epsilon is positive and larger than smallest possible float etc
        // Transform reference up to object space
        Vector3 referenceObjectSpace = transform.InverseTransformDirection(referenceVectorUp);

        // Find smallest difference to object space direction
        float min = float.MaxValue;
        int mostSimilarDirectionIndex = -1;
        for (int i = 0; i < directions.Count; ++i)
        {
            float a = Vector3.Angle(referenceObjectSpace, directions[i]);
            if (a <= epsilonDeg && a < min)
            {
                min = a;
                mostSimilarDirectionIndex = i;
            }
        }

        // -1 as error code for not within bounds
        return (mostSimilarDirectionIndex >= 0) ? sideValues[mostSimilarDirectionIndex] : DriedelSides.Error;
    }
}

public enum DriedelSides
{
    Up, Nun, Gimel, Hey, Shin, UpsideDown = 100, Error = 200
}
