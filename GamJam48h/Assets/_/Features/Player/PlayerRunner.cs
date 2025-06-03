using UIManager;
using UnityEngine;

namespace Player
{
    public class PlayerRunner : MonoBehaviour
    {
        #region Api Unity

        private void Start()
        {
            _uiTimer = FindFirstObjectByType<Timer>();
            _spritesRenderers = GetComponent<SpriteRenderer>();
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
                _currentGame.SetActive(false);
                _uiTimer.SaveTimeData();
            }
        }

        #endregion
        
        
        #region Utils

        private void Move()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.position += _runSpeed * Time.deltaTime * Vector3.right;
                _left = !_left;
                
                if (_left == false) _spritesRenderers.sprite = _sprite[1];
                
                else if (_left==true) _spritesRenderers.sprite = _sprite[0];
                
            }
        }
        
        #endregion
        
        
        #region Private And Protected
        
        [SerializeField] private float _runSpeed = 5f;
        [SerializeField] private Sprite[] _sprite;
        [SerializeField] private GameObject _changeGame;
        [SerializeField] private GameObject _currentGame;
        
        private SpriteRenderer _spritesRenderers;
        private bool _isRunning = true;
        private Timer _uiTimer;
        private bool _left = true;

        #endregion
    }
}
