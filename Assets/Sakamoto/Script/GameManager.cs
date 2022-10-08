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

    [SerializeField] public Rigidbody _Rigidbody;

    [Header("Playerの勝利テキスト")]
    [SerializeField] List<GameObject> _winText = new List<GameObject>();

    [Header("ScoreText")]
    [SerializeField] Text[] _scoreText;

    int _player1Score = 0;
    int _player2Score = 0;

    private Turn _nowTurn = Turn.GameStart;
    public Turn NowTurn => _nowTurn;

    void Start()
    { 

    }

     void Update()
     {
        if (_nowTurn == Turn.GameEnd && Input.GetButtonDown("Submit")) 
        {
            SceneLoadManager.Instance.ChangeScene("Title Scene");
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
        if (playerName == "P1" && _nowTurn == Turn.GameStart)
        {
            _winText[0].SetActive(true);
        }
        else if (playerName == "P2" && _nowTurn == Turn.GameStart) 
        {
            _winText[1].SetActive(true);
        }

        _nowTurn = Turn.GameEnd;
    }

    public void Player1AddScore() 
    {
        _player1Score++;
        _scoreText[0].text = _player1Score.ToString();
    }

    public void Player2AddScore()
    {
        _player2Score++;
        _scoreText[1].text = _player2Score.ToString();
    }
}
