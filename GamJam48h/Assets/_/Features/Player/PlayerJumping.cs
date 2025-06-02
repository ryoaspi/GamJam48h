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
        }
        
        void Update()
        {
            if (_isJumping)
            {
                transform.Translate(Vector3.right * (_moveSpeed * Time.deltaTime));
                Jumping();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Finish"))
            {
                _isJumping = false;
                _uiTimer.m_isRunning = false;
                _uiTimer.SaveTimeData();
                Debug.Log("Player has finished");
            }
        }

        #endregion
        
        
        #region Utils

        private void Jumping()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.position += Vector3.up * (_jumpSpeed * Time.deltaTime);
            }
        }
        
        #endregion
        
        
        #region Private And Protected
        
        [SerializeField] private float _jumpForce = 100f;
        [SerializeField] private float _jumpSpeed = 10f;
        [SerializeField] private float _moveSpeed = 10f;

        private Timer _uiTimer;
        private bool _isJumping = true;

        #endregion
    }
}
