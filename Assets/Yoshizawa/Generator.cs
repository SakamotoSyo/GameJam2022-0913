using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    /// <summary>落下させたいオブジェクトを入れる</summary>
    [SerializeField] GameObject[] _item;
    BoxCollider2D _bc;
    [SerializeField] GameObject _muzzle;

    void Start()
    {
        _bc = GetComponent<BoxCollider2D>();
    }

    public void ItemGenerator()
    {
        //BoxColliderの範囲内から落とす
        //float X = Random.Range(-_bc.size.x / 2, _bc.size.x / 2);
        //float Y = Random.Range(-_bc.size.y / 2, _bc.size.y / 2);

        //_itemに入れたオブジェクトのどれかを生成する
        int random = Random.Range(0, _item.Length);
       //_item[random].transform.position =
            //new Vector2(X + transform.position.x, Y + transform.position.y);
        Instantiate(_item[random], _muzzle.transform.position, _muzzle.transform.rotation);
    }
}
