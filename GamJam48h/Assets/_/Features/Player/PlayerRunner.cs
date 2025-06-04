using System;
using UIManager;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    public class PlayerRunner : MonoBehaviour
    {
        #region Api Unity

        private void Start()
        {
            _spritesRenderers = GetComponent<SpriteRenderer>();
            _startPosition = transform.position;
        }

        private void OnEnable()
        {
            
        }

        private void Update()
        {
            if (_isRunning) Move();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Finish"))
            {
                _changeGame.SetActive(true);
                _isRunning = false;
                _uiTimer.m_isRunning = false;
                _recordTimer.SaveTimeData();     
                _camera.gameObject.SetActive(true);
                _currentGame.SetActive(false);

                ResetPlayer();

            }
        }

        #endregion
        
        
        #region Utils

        private void Move()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(Vector3.right * (_runSpeed * Time.deltaTime));
                _left = !_left;
                
                if (_left == false) _spritesRenderers.sprite = _sprite[1];
                
                else if (_left==true) _spritesRenderers.sprite = _sprite[0];
                
            }
        }

        private void ResetPlayer()
        {
            transform.position = _startPosition;
            _left = true;
            _spritesRenderers.sprite = _sprite[0];
            
            _isRunning = true;
            _uiTimer.m_isRunning = true;
            _uiTimer.m_timer = 0f;

        }
        
        #endregion
        
        
        #region Private And Protected
        
        [SerializeField] private float _runSpeed = 5f;
        [SerializeField] private Sprite[] _sprite;
        [SerializeField] private GameObject _changeGame;
        [SerializeField] private GameObject _currentGame;
        [SerializeField] private Timer _uiTimer;
        [SerializeField] private TimerData _recordTimer;
        [SerializeField] private Camera _camera;
        
        private SpriteRenderer _spritesRenderers;
        private bool _isRunning = true;
        private Vector3 _startPosition;
        private bool _left = true;

        #endregion
    }
}
