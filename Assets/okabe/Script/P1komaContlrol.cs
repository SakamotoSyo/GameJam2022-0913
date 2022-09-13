using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1komaContlrol : MonoBehaviour
{
    [SerializeField] Rigidbody2D _Rigidbody2D;
    [SerializeField] Generator _generator;
    bool _Gravity;
    bool _Ground;
    bool _isPush;
    bool _ins;
    private void Start()
    {
        _generator = GameObject.Find("Generator").GetComponent<Generator>();
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }



    void Update()
    {

        if (!_Gravity && !_isPush)
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
        //if (collision.gameObject.CompareTag("Stage") /*|| collision.gameObject.CompareTag("‹î‚Ìƒ^ƒO") */ )
        
            _Ground = true;
        
    }
}
