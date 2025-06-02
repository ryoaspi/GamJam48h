using System.IO;
using TMPro;
using UnityEngine;

namespace UIManager
{
    public class Timer : MonoBehaviour
    {   
        #region Publics

        public bool m_isRunning = true;
           
        #endregion
        
        #region Api Unity

        private void Start()
        {
            
        }

        void Update()
        {
            if (m_isRunning)
            {
                _timer += Time.deltaTime;
                UiTimer();
            }
            
        }
        
        #endregion
        
        
        #region Main Methods

        public void UiTimer()
        {
            _TimerText.text = _timer.ToString("0.00");
        }

        public void SaveTimeData()
        {
            string json = JsonUtility.ToJson(_TimerText);
            File.WriteAllText(json, json);
        }
        
        #endregion
        
        
        #region Private And Protected
        
        [SerializeField] private TMP_Text _TimerText; 

        private float _timer = 0;
        private string _timerDataFile = "TimerData.json";

        #endregion
    }
}
