using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonBehaviour<GameManager>
{
    public enum Turn 
    {
        WaitTurn,
        GameStart,
        GameEnd,
    }

    [SerializeField] Text _Timer;

    [Header("Playerの勝利テキスト")]
    [SerializeField] List<GameObject> _winText = new List<GameObject>();

    private Turn _nowTurn = Turn.WaitTurn;
    public Turn NowTurn => _nowTurn;

    void Start()
    { 

    }

     void Update()
     {
        if (_nowTurn == Turn.GameEnd && Input.GetButtonDown("Submit")) 
        {
            //SceneLoadManage
        }
     }

    /// <summary>
    /// 現在のターンをセットする
    /// </summary>
    /// <param name="turn"></param>
    public void SetNowTurn(Turn turn) 
    {
        _nowTurn = turn;
    }

    /// <summary>
    /// ゲームが終わった時にリザルトを表示する
    /// </summary>
    /// <param name="playerName"></param>
    public void GameEnd(string playerName) 
    {
        if (playerName == "P1")
        {
            _winText[0].SetActive(true);
        }
        else if (playerName == "P2") 
        {
            _winText[1].SetActive(true);
        }

        _nowTurn = Turn.GameEnd;
    }
}
