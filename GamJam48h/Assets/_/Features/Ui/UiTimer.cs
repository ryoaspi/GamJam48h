using TMPro;
using UnityEngine;

namespace UIManager
{
    public class UiTimer : MonoBehaviour
    {
        #region Api Unity

        private void OnEnable()
        {
            _timer = _delayTime;
        }


        void Update()
        {
            _timer -= Time.deltaTime;
            _timerText.text = _timer.ToString("0");
            if (_timer <= 0)
            {
                _miniGameOne.SetActive(true);
                gameObject.SetActive(false);
            }
        }
        
        #endregion
        
        
        #region Private And Protected

        [SerializeField] private float _delayTime = 3f;
        [SerializeField] private GameObject _miniGameOne;
        [SerializeField] private TMP_Text _timerText;
        
        private float _timer;

        #endregion
    }
}
