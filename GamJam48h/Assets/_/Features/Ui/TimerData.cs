using System.IO;
using TMPro;
using UnityEngine;

namespace UIManager
{
    public class TimerData: MonoBehaviour
    {
        #region publics

        public string m_playerName;
        public float[] m_times = new float[3];
        public int m_miniGameIndex =0 ; //Index du mini jeu
        public float m_timer = 0;
        
        #endregion
        
        
        #region Api Unity

        private void Start()
        {
            m_playerName = PlayerName.m_playerName;
            _timer = FindFirstObjectByType<Timer>();
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
                string existingJson = File.ReadAllText(path);
                data = JsonUtility.FromJson<GameData>(existingJson);
            }
            else
            {
                data = new GameData();
                
            }
            
            PlayerTimeData playerData = data.players.Find(p => p.m_playerName == PlayerName.m_playerName);
            if (playerData == null)
            {
                playerData = new PlayerTimeData(PlayerName.m_playerName);
                data.players.Add(playerData);
            }

            if (m_miniGameIndex >= 0 && m_miniGameIndex < playerData.m_times.Length)
            {
                playerData.m_times[m_miniGameIndex] = m_timer;
            }
            
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
            GameData data = JsonUtility.FromJson<GameData>(json);
            
            
            float totalTime = 0;
            
            
                
            foreach (PlayerTimeData playerData in data.players) 
            {
                foreach (float t in playerData.m_times)
                {
                    totalTime += t;
                }
            }
            
            return totalTime;
        }
        #endregion
        
        
        #region Private And Protected
        
        private string _timerDataFile = "TimerData.json";
        private Timer _timer;
        [SerializeField] private TMP_Text _timerText;
        
        #endregion
    }
}