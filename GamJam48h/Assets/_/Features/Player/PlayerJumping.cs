using System;
using UIManager;
using UnityEngine;

namespace Player
{
    public class PlayerJumping : MonoBehaviour
    {
        #region Api Unity
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _startPosition = transform.position;
        }

        private void OnEnable()
        {
            
        }

        void Update()
        {
            _uiPlayerTimer += Time.deltaTime;
            if (_isRunning)
            {
                transform.Translate(Vector3.right * (_moveSpeed * Time.deltaTime));
                if (_isJumping) Jumping();
                if (_uiPlayerTimer >= _uiPlayer && _left == true && _isJumping == true)
                {
                    _uiPlayerTimer = 0f;
                    _left = false;
                    _spriteRenderer.sprite = _sprites[0];
                }

                if (_uiPlayerTimer >= _uiPlayer && _left == false && _isJumping == true)
                {
                    _uiPlayerTimer = 0f;
                    _left = true;
                    _spriteRenderer.sprite = _sprites[1];
                }
                
            }
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Finish"))
            {
                _changeGame.SetActive(true);
                _isJumping = false;
                _isRunning = false;
                _uiTimer.m_isRunning = false;
                _recordTimer.SaveTimeData();
                _camera.gameObject.SetActive(true);
                _currentGame.SetActive(false);  
                
                ResetPlayer();
            }

            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                _isJumping = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                _uiTimer.m_timer += 2f;
            }
        }

        #endregion
        
        
        #region Utils

        private void Jumping()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _isJumping = false;
                _spriteRenderer.sprite = _sprites[2];
            }
        }

        private void ResetPlayer()
        {
            transform.position = _startPosition;
            _left = true;
            _spriteRenderer.sprite = _sprites[0];
            _isJumping = false;
            _isRunning = true;
            _uiTimer.m_timer = 0f;
            _uiTimer.m_isRunning = true;
        }
        
        #endregion
        
        
        #region Private And Protected
        
        [SerializeField] private float _jumpForce = 100f;
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private float _uiPlayer = 0.5f;
        [SerializeField] private GameObject _changeGame;
        [SerializeField] private GameObject _currentGame;
        [SerializeField] private Timer _uiTimer;
        [SerializeField] private TimerData _recordTimer;
        [SerializeField] private Camera _camera;
        
        private SpriteRenderer _spriteRenderer;
        private Vector3 _startPosition;
        private bool _isJumping = true;
        private Rigidbody2D _rigidbody2D;
        private bool _isRunning = true;
        private float _uiPlayerTimer = 0f;
        private bool _left = true;

        #endregion
    }
}
