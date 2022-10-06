using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1komaContlrol : MonoBehaviour
{
    [SerializeField] Rigidbody2D _Rigidbody2D;
    [SerializeField] Generator _generator;
    //[SerializeField] BoxCollider2D _boxCollider2D;
    [Header("ã≠êßìIÇ…óéÇøÇÈéûä‘")]
    [SerializeField]float _fallTime = 1.5f;
    [SerializeField] Slider _slider;
    GameManager _gameManager;
    bool _Gravity;
    bool _Ground;
    bool _ins;

    
    void Start()
    {
        _slider = GameObject.Find("P1Canvas/P1Slider").GetComponent<Slider>();
        _slider.maxValue = 1;
        _gameManager = GameManager.Instance;
        _generator = GameObject.Find("P1Generator").GetComponent<Generator>();
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!_ins) 
        {
            _fallTime -= Time.deltaTime;
            _slider.value = _fallTime;
        }

        if (!_Gravity)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = transform.position + new Vector3(-0.01f, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = transform.position + new Vector3(0.01f, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                transform.Rotate(0, 0, 30);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.Rotate(0, 0, -30);
            }
            if (Input.GetKeyDown(KeyCode.Space) || _fallTime < 0)
            {
               // _boxCollider2D.enabled = true;
                _Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                _Gravity = true;
            }
        }
        else if (!_ins && _Gravity && _Ground)
        {
            //float x = gameObject.transform.position.x;
            //float y = gameObject.transform.position.y;
            if (_Rigidbody2D.velocity == new Vector2(0, 0))
            {
                Debug.Log("Ç†Çì");
                _ins = true;
                _generator.ItemGenerator();
                _gameManager.Player1AddScore();
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_Gravity) 
        {
            _Ground = true;
        }
        

        if (collision.CompareTag("DeadSpace"))
        {
            _gameManager.GameEnd("P1");
        }
    }
}
