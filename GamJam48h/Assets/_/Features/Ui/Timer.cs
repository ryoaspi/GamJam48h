using System.IO;
using TMPro;
using UnityEngine;

namespace UIManager
{
    public class Timer : MonoBehaviour
    {   
        #region Publics

        public bool m_isRunning = true;
        public int m_miniGameIndex =0 ; //Index du mini jeu
        public string m_playerName = "Player"; // Sera rempli ailleurs (ex : menu)
           
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
            string path = Path.Combine(Application.persistentDataPath, _timerDataFile);

            TimerData data;

            if (File.Exists(path))
            {
                string existingJson = JsonUtility.ToJson(_TimerText);
                data = JsonUtility.FromJson<TimerData>(existingJson);
            }
            else
            {
                data = new TimerData();
                data.m_playerName = m_playerName;
            }
            
            if (m_miniGameIndex >= 0 && m_miniGameIndex < data.m_times.Length)
                data.m_times[m_miniGameIndex] = _timer;
            
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(json, json);
        }

        public float GetCurrentTime()
        {
            return _timer;
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
        
        [SerializeField] private TMP_Text _TimerText; 

        private float _timer = 0;
        private string _timerDataFile = "TimerData.json";

        #endregion
    }

    [System.Serializable]
    public class TimerData
    {
        public string m_playerName;
        public float[] m_times = new float[6]; // Pour les 3 Mini_jeux
    }
}
