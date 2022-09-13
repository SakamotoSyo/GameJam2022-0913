using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2komaContlrol : MonoBehaviour
{
    [SerializeField] Rigidbody2D _Rigidbody2D;
    [SerializeField] Generator _generator;
    bool _Gravity;
    bool _Ground;
    bool _ins;
    float _time = 0;

    private void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }



    void Update()
    {

        if (!_Gravity)
        {
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                transform.position = transform.position + new Vector3(-0.1f, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                transform.position = transform.position + new Vector3(0.1f, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                transform.Rotate(0, 0, 30);
            }
            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                transform.Rotate(0, 0, -30);
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                _Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                _Gravity = true;

            }
        }

        else if (_Ground && !_ins && _Gravity)
        {
            float x = gameObject.transform.position.x;
            float y = gameObject.transform.position.y;
            if (_Rigidbody2D.velocity == new Vector2(0, 0))
            {
                Debug.Log("‚¤");

                _generator.ItemGenerator();
                _ins = true;

            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stage"))
        {
            _Ground = true;

        }
    }
}
