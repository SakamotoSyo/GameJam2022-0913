using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1komaContlrol : MonoBehaviour
{
    [SerializeField] Rigidbody2D _Rigidbody2D;
    bool _Gravity;
    float _time =0;
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
        //    else if(_Gravity)
        //{
        //}
            else
            {
                float x = gameObject.transform.position.x;
                float y = gameObject.transform.position.y;
                if (x < 0.1f && y < 0.1f)
                {
                    Debug.Log("‚¤");
                _time += Time.deltaTime;
                _time = 0;
                if (_time < 5) return;
                {
                    // Instantiate

                }


            }
            }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Stage"))
            { }
    }
}
