using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public List<Player> players = new List<Player>();
    public int iCurrentPlayer = 0;
    public int pot = 3;
    public bool isPlaying = false;

    public Text txtPlayer1Name;
    public Text txtPlayer1Coins;
    public Text txtPlayer2Name;
    public Text txtPlayer2Coins;
    public Text txtPotCoins;


    public static GM Current;

    // Use this for initialization
    void Start()
    {
        Current = this;

        txtPlayer1Name = GameObject.Find("txtPlayer1Name").GetComponent<Text>();
        txtPlayer1Coins = GameObject.Find("txtPlayer1Coins").GetComponent<Text>();
        txtPlayer2Name = GameObject.Find("txtPlayer2Name").GetComponent<Text>();
        txtPlayer2Coins = GameObject.Find("txtPlayer2Coins").GetComponent<Text>();
        txtPotCoins = GameObject.Find("txtPotCoins").GetComponent<Text>();

        players.Add( new Player { name = "Moshe", points = 100 } );
        players.Add( new Player { name = "Raphi", points = 100 } );
    }
    public void StartGame()
    {
        GM.Current.isPlaying = true;
        GameObject.Find("StartPanel").SetActive(false);
        txtPlayer1Name.text = players[0].name;
        txtPlayer2Name.text = players[1].name;
        txtPotCoins.text = pot.ToString();

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
