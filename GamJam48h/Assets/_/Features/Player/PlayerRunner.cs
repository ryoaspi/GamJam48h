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
        }

        private void Update()
        {
            if (_isRunning) Move();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Finish"))
            {
                _isRunning = false;
                _uiTimer.m_isRunning = false;
                _uiTimer.SaveTimeData();
                Debug.Log("Player has finished");
            }
        }

        #endregion
        
        
        #region Utils

        private void Move()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.position += _runSpeed * Time.deltaTime * Vector3.right;
            }
        }
        
        #endregion
        
        
        #region Private And Protected
        
        [SerializeField] private float _runSpeed = 5f;
        
        private bool _isRunning = true;
        private Timer _uiTimer;

        #endregion
    }
}
