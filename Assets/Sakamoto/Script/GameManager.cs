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

    [Header("Player�̏����e�L�X�g")]
    [SerializeField] List<GameObject> _winText = new List<GameObject>();

    int _player1Score = 0;
    int _player2Score = 0;

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
    /// ���݂̃^�[�����Z�b�g����
    /// </summary>
    /// <param name="turn"></param>
    public void SetNowTurn(Turn turn) 
    {
        _nowTurn = turn;
    }

    /// <summary>
    /// �Q�[�����I��������Ƀ��U���g��\������
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

    public void Player1AddScore() 
    {
        _player1Score++;
    }

    public void Player2AddScore()
    {
        _player2Score++;
    }
}
