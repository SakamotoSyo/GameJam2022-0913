using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2komaContlrol : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Generator _generator;
    [SerializeField] Slider _slider;
    float _fallTime;
    GameManager _gameManager;
    bool _isGravity;
    bool _isGround;
    bool _isInstance;
    void Start()
    {
        _fallTime = 2.5f;
        _slider = GameObject.Find("P2Canvas/P2Slider").GetComponent<Slider>();
        _slider.maxValue = 1;
        _gameManager = GameManager.Instance;
        _generator = GameObject.Find("P2Generator").GetComponent<Generator>();
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
            if (Input.GetKey(KeyCode.Keypad4))
            {
                transform.position = transform.position + new Vector3(-0.01f, 0, 0);
            }
            if (Input.GetKey(KeyCode.Keypad6))
            {
                transform.position = transform.position + new Vector3(0.01f, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                transform.Rotate(0, 0, 30);
            }
            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                transform.Rotate(0, 0, -30);
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || _fallTime < 0)
            {
                _rb.bodyType = RigidbodyType2D.Dynamic;
                _isGravity = true;
            }
        }
        else if (!_isInstance && _isGravity && _isGround)
        {
            if (_rb.velocity == new Vector2(0, 0))
            {
                Debug.Log("OK");
                _generator.ItemGenerator();
                _gameManager.Player2AddScore();
                _isInstance = true;
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
            _gameManager.GameEnd("P2");
        }
    }
}
