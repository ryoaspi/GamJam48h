using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

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

    [System.Serializable]
    public class TimerData
    {
        #region publics
        
        public float[] m_times = new float[3]; // Pour les 3 Mini_jeux
        public int m_miniGameIndex =0 ; //Index du mini jeu
        public string m_playerName = "Player"; // Sera rempli ailleurs (ex : menu)
        public float m_timer = 0;
        
        #endregion
        
        
        #region Api Unity

        private void Start()
        {
            m_timer = _timer.m_timer;
            _timerText.text = _timer.m_TimerText.text;
        }

        #endregion
        
        
        #region Main Methods
        
        public void SaveTimeData()
        {
            string path = Path.Combine(Application.persistentDataPath, _timerDataFile);
            GameData data;

            if (File.Exists(path))
            {
                string existingJson = JsonUtility.ToJson(_timerText);
                data = JsonUtility.FromJson<GameData>(existingJson);
            }
            else
            {
                data = new GameData();
                
            }
            
            TimerData playerData = data.players.Find(p => p.m_playerName == m_playerName);
            if (playerData == null)
            {
                playerData = new TimerData();
                data.players.Add(playerData);
            }
            
            if (m_miniGameIndex >= 0 && m_miniGameIndex < playerData.m_times.Length)
                playerData.m_times[m_miniGameIndex] = m_timer;
            
            string newJson = JsonUtility.ToJson(data, true);
            File.WriteAllText(path, newJson);
        }

        public float GetCurrentTime()
        {
            return m_timer;
        }

        public static float GetTotalTime()
        {
            string path = Path.Combine(Application.persistentDataPath, "TimerData.json");
            if (!File.Exists(path)) return 0;
            
            string json = File.ReadAllText(path);
            TimerData data = JsonUtility.FromJson<TimerData>(json);
            
            float totalTime = 0;
            foreach (float t in data.m_times)
            {
                totalTime += t;
            }
            return totalTime;
        }
        #endregion
        
        
        #region Private And Protected
        
        private string _timerDataFile = "TimerData.json";
        private Timer _timer;
        private TMP_Text _timerText;
        
        #endregion
    }
}
