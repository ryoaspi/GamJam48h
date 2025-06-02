using UnityEngine;

namespace Player
{
    public class PlayerRunner : MonoBehaviour
    {
        #region Api Unity

        private void Update()
        {
            if (_isRunning) Move();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Finish"))
            {
                _isRunning = false;
                Debug.Log("Player has finished");
            }
        }

        #endregion
        
        
        #region Utils

        private void Move()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(Vector2.right * (Time.deltaTime * _runSpeed));
            }
        }
        
        #endregion
        
        
        #region Private And Protected
        
        [SerializeField] private float _runSpeed = 5f;
        
        private bool _isRunning = true;
        
        #endregion
    }
}
