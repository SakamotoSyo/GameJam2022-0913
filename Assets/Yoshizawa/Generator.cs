using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject[] _item;
    BoxCollider2D _bc;

    void Start()
    {
        _bc = GetComponent<BoxCollider2D>();
    }

    public void ItemGenerator()
    {
        float X = Random.Range(-_bc.size.x / 2, _bc.size.x / 2);
        float Y = Random.Range(-_bc.size.y / 2, _bc.size.y / 2);
        int random = Random.Range(0, _item.Length);
        _item[random].transform.position =
            new Vector2(X + transform.position.x, Y + transform.position.y);
        Instantiate(_item[random]);
    }
}
