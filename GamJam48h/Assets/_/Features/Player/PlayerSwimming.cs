using System;
using UIManager;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerSwimming : MonoBehaviour
    {
        #region Publics
        
        public Slider m_slider;
        public Slider m_sliderMax;
        public Slider m_sliderMin;
        
        
        #endregion
        
        #region Api Unity
        
        void Start()
        {
            m_slider.maxValue = _sliderValue;
            m_sliderMax.maxValue = _sliderValue;
            m_sliderMin.maxValue = _sliderValue;
            _rb2D  = GetComponent<Rigidbody2D>();
            _rb2D.linearDamping = _frein;
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
                m_slider.value -= _removeslider;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_slider.value += _jumpForce;
                }
                MoveZone();
                MovePlayer();
                if (_uiPlayerTimer >= _uiPlayer && _spriteIndex == 0)
                {
                    _uiPlayerTimer = 0;
                    _spriteIndex = 1;
                    _spriteRenderer.sprite = _sprites[_spriteIndex];
                }

                if (_uiPlayerTimer >= _uiPlayer && _spriteIndex == 1)
                {
                    _uiPlayerTimer = 0;
                    _spriteIndex = 2;
                    _spriteRenderer.sprite = _sprites[_spriteIndex];
                }

                if (_uiPlayerTimer >= _uiPlayer && _spriteIndex == 2)
                {
                    _uiPlayerTimer = 0;
                    _spriteIndex = 0;
                    _spriteRenderer.sprite = _sprites[_spriteIndex];
                }
                
            }
            transform.rotation =  Quaternion.Euler(0,0,0);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Finish"))
            {
                _isRunning = false;
                _uiTimer.m_isRunning = false;
                _changeGame.SetActive(true);
                _recordTimer.SaveTimeData();
                _camera.gameObject.SetActive(true);
                _currentGame.SetActive(false);
                
                ResetPlayer();
            }
        }

        #endregion
        
        
        #region Utils

        private void MoveZone()
        {
            _changeZone += Time.deltaTime;
            if (_changeZone >= _delayTime)
            {
                _randomRange = Random.Range(m_slider.minValue + 0.05f, m_slider.maxValue - 0.8f );
                _changeZone = 0;
                m_sliderMin.value = _randomRange;
                m_sliderMax.value = _randomRange + Random.Range(0.2f, 0.5f);
            }
            
        }

        private void MovePlayer()
        {
            if (m_slider.value <= m_sliderMax.value && m_slider.value >= m_sliderMin.value)
            {
                _rb2D.AddForce(Vector2.right * _movePlayer);
                
            }
        }

        private void ResetPlayer()
        {
            transform.position = _startPosition;
            _isRunning = true;
            _uiTimer.m_isRunning = true;
            _uiTimer.m_timer = 0f;
            _spriteRenderer.sprite = _sprites[_spriteIndex];
        }
        
        #endregion
        
        
        #region Private And Protected
        
        [SerializeField] private float _sliderValue = 2f;
        [SerializeField] private float _delayTime = 1f;
        [SerializeField] private float _jumpForce = 0.05f;
        [SerializeField] private float _movePlayer = 5f;
        [SerializeField] private float _frein = 3f;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private float _uiPlayer = 0.1f;
        [SerializeField] private GameObject _changeGame;
        [SerializeField] private GameObject _currentGame;
        [SerializeField] private float _removeslider = 0.03f;
        [SerializeField] private Timer _uiTimer;
        [SerializeField] private TimerData _recordTimer;
        [SerializeField] private Camera _camera;
        
        private SpriteRenderer _spriteRenderer;
        private float _changeZone;
        private float _randomRange;
        private Vector3 _startPosition;
        private Rigidbody2D _rb2D;
        private bool _isRunning = true;
        private int _spriteIndex;
        private float _uiPlayerTimer;

        #endregion
    }
}
