using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class KomaContlrol : MonoBehaviour
{
    Rigidbody2D _rb;
    bool _gravity;
    bool _ground;
    private void Start()
    {

        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
            if (!_gravity)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    transform.position = transform.position + new Vector3(-0.1f, 0, 0);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    transform.position = transform.position + new Vector3(0.1f, 0, 0);
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    transform.Rotate(0, 0, 30);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    transform.Rotate(0, 0, -30);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                _rb.bodyType = RigidbodyType2D.Dynamic;
                    _gravity = true;
                }
            }
            else if(_ground)
            {
                float x = gameObject.transform.position.x;
                float y = gameObject.transform.position.y;
                if (x < 0.1f && y < 0.1f)
                {
                    Debug.Log("OK");
                }
           }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Stage"))
        {
            _ground = true;
        }
    }
}
