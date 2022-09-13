using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1komaContlrol : MonoBehaviour
{
    [SerializeField] Rigidbody2D _Rigidbody2D;
    bool _Gravity;
    bool _Ground;
    private void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
       
            if (!_Gravity)
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
            else if(_Ground)
            {
                float x = gameObject.transform.position.x;
                float y = gameObject.transform.position.y;
                if (x < 0.1f && y < 0.1f)
                {
                    Debug.Log("‚¤");
                    // Instantiate
                }
           }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Stage") /*|| collision.gameObject.CompareTag("‹î‚Ìƒ^ƒO") */ )
        {
            _Ground = true;
        }
    }
}
