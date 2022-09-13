using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Turn 
    {
        WaitTurn,
        P1,
        P2,
    }

    private Turn _nowTurn;
    public Turn NowTurn => _nowTurn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
