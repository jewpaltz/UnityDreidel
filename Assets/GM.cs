using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour
{
    public List<Player> players = new List<Player>();
    public int iCurrentPlayer = 0;
    public int pot = 3;

    // Use this for initialization
    void Start()
    {
        players.Add( new Player { name = "Moshe", points = 100 } );
        players.Add( new Player { name = "Raphi", points = 100 } );
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndOfTurn()
    {
        iCurrentPlayer = iCurrentPlayer++ % players.Count;

    }
}
