using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

namespace UIManager
{
    public class LeaderboarDisplay : MonoBehaviour
    {
        #region Api Unity
        void Start()
        {
            string path = Path.Combine(Application.persistentDataPath,"TimerData.json");

            if (!File.Exists(path))
            {
                _leaderboarText.text = "Aucun score encore enregistré.";
                return;
            }
            string jsonString = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(jsonString);
            
            List<(string name, float total)> scores = new List<(string name, float total)>();

            foreach (var player in data.players)
            {
                float total = player.m_times.Sum();

                scores.Add((player.m_playerName, total));
            }

            scores = scores.OrderBy(s => s.total).ToList();
            _leaderboarText.text = "Classement : /n";

            int rank = 1;
            foreach (var score in scores)
            {
                _leaderboarText.text += $"{rank}. {score.name} - {score.total: 0.00} sec \n";
                rank++;
            }
            
        }
        
        #endregion


        #region Private And Protected

        [SerializeField] private TMP_Text _leaderboarText;

        #endregion
    }
}
