using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1komaContlrol : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Generator _generator;
    float _fallTime;
    [SerializeField] Slider _slider;
    GameManager _gameManager;
    bool _isGravity;
    bool _isGround;
    bool _isInstance;

    
    void Start()
    {
        _fallTime = 2.5f;
        _slider = GameObject.Find("P1Canvas/P1Slider").GetComponent<Slider>();
        _slider.maxValue = 1;
        _gameManager = GameManager.Instance;
        _generator = GameObject.Find("P1Generator").GetComponent<Generator>();
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!_isInstance) 
        {
            _fallTime -= Time.deltaTime;
            _slider.value = _fallTime;
        }

        if (!_isGravity)
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
                _rb.bodyType = RigidbodyType2D.Dynamic;
                _isGravity = true;
            }
        }
        else if (!_isInstance && _isGravity && _isGround)
        {            
            if (_rb.velocity == new Vector2(0, 0))
            {
                Debug.Log("good");
                _isInstance = true;
                _generator.ItemGenerator();
                _gameManager.Player1AddScore();
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isGravity) 
        {
            _isGround = true;
        }
        

        if (collision.CompareTag("DeadSpace"))
        {
            _gameManager.GameEnd("P1");
        }
    }
}
