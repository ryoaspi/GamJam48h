using UIManager;
using UnityEngine;

namespace Player
{
    public class PlayerJumping : MonoBehaviour
    {
        #region Api Unity
        void Start()
        {
            _uiTimer = FindFirstObjectByType<Timer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        void Update()
        {
            if (_isRunning)
            {
                transform.Translate(Vector3.right * (_moveSpeed * Time.deltaTime));
                if (_isJumping) Jumping();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Finish"))
            {
                _isJumping = false;
                _isRunning = false;
                _uiTimer.m_isRunning = false;
                _uiTimer.SaveTimeData();
                Debug.Log("Player has finished");
            }

            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                _isJumping = false;
                _isRunning = false;
                _uiTimer.m_isRunning = false;
                Debug.Log("Player failure");
            }

            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                _isJumping = true;
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
            }
        }
        
        #endregion
        
        
        #region Private And Protected
        
        [SerializeField] private float _jumpForce = 100f;
        [SerializeField] private float _moveSpeed = 10f;

        private Timer _uiTimer;
        private bool _isJumping = true;
        private Rigidbody2D _rigidbody2D;
        private bool _isRunning = true;

        #endregion
    }
}
