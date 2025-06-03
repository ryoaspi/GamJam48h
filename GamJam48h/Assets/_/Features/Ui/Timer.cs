using TMPro;
using UnityEngine;

namespace UIManager
{
    public class Timer : MonoBehaviour
    {   
        #region Publics

        public float m_timer = 0;
        public bool m_isRunning = true;
        public TMP_Text m_TimerText; 
       
           
        #endregion
        
        #region Api Unity

        private void Start()
        {
            
        }

        void Update()
        {
            if (m_isRunning)
            {
                m_timer += Time.deltaTime;
                UiTimer();
            }
            
        }
        
        #endregion
        
        
        #region Main Methods

        public void UiTimer()
        {
            m_TimerText.text = m_timer.ToString("0.00");
        }

       
        
        #endregion
        
        
        #region Private And Protected
        
        
        
        #endregion
    }
}
