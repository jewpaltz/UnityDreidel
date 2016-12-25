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

    public Text txtPotCoins;
    public Text txtLastPlayer;
    public Text txtLastSpin;
    public Text txtCurPlayer;

    public static GM Current;

    // Use this for initialization
    void Start()
    {
        Current = this;

        txtPotCoins = GameObject.Find("txtPotCoins").GetComponent<Text>();
        txtLastPlayer = GameObject.Find("txtLastPlayer").GetComponent<Text>();
        txtLastSpin = GameObject.Find("txtLastSpin").GetComponent<Text>();
        txtCurPlayer = GameObject.Find("txtCurPlayer").GetComponent<Text>();

        players.Add(new Player { name = "Moshe", coins = 100, txtName = GameObject.Find("txtPlayer1Name").GetComponent<Text>(), txtCoins = GameObject.Find("txtPlayer1Coins").GetComponent<Text>() });
        players.Add(new Player { name = "Raphi", coins = 100, txtName = GameObject.Find("txtPlayer2Name").GetComponent<Text>(), txtCoins = GameObject.Find("txtPlayer2Coins").GetComponent<Text>() });
    }
    public void StartGame()
    {
        GM.Current.isPlaying = true;

        players[0].name = GameObject.Find("Player1Name").GetComponent<InputField>().text;
        players[1].name = GameObject.Find("Player2Name").GetComponent<InputField>().text;

        GameObject.Find("StartPanel").SetActive(false);


        players[0].txtName.text = players[0].name + ":";
        players[1].txtName.text = players[1].name + ":";

        EndOfTurn(DriedelSides.Up);

    }


    // Update is called once per frame
    void Update()
    {

    }

    public void EndOfTurn(DriedelSides letter)
    {
        switch (letter)
        {
            case DriedelSides.Up:
                break;
            case DriedelSides.Nun:
                break;
            case DriedelSides.Gimel:
                players[iCurrentPlayer].coins += pot;
                pot = 0;
                break;
            case DriedelSides.Hey:
                var half = pot / 2;
                players[iCurrentPlayer].coins += half;
                pot -= half;
                break;
            case DriedelSides.Shin:
                players[iCurrentPlayer].coins--;
                pot++;
                break;
            case DriedelSides.UpsideDown:
                break;
            case DriedelSides.Error:
                break;
            default:
                break;
        }
        if(pot <= 0)
        {
            foreach(var p in players)
            {
                p.coins--;
                pot++;
            }
        }

        txtLastSpin.text = letter.ToString();
        txtPotCoins.text = pot.ToString();
        players[0].txtCoins.text = players[0].coins.ToString();
        players[1].txtCoins.text = players[1].coins.ToString();

        players[iCurrentPlayer].txtName.color = Color.black;
        txtLastPlayer.text = players[iCurrentPlayer].name;

        iCurrentPlayer = (iCurrentPlayer + 1) % players.Count;

        players[iCurrentPlayer].txtName.color = Color.red;
        txtCurPlayer.text = players[iCurrentPlayer].name;
    }
}
