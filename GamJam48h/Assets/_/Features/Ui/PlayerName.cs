using TMPro;
using UnityEngine;

namespace UIManager
{
    public class PlayerName : MonoBehaviour
    {
        #region Publics
        
        public static string m_playerName = "PlayerName";
        
        #endregion
        
        
        #region Api Unity
        private void OnEnable()
        {
            if (!string.IsNullOrEmpty(m_playerName))
            {
                _nameInput.text = m_playerName;
                _playerName.text = m_playerName;
            }
        }


        void Update()
        {
        
        }
        #endregion
        
        
        #region Main Methods

        public void SetName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                m_playerName = name;
                _playerName.text = name;
            }
        }
        
        #endregion
        
        
        #region Private And Protected

        [SerializeField] private TMP_InputField _nameInput;
        [SerializeField] private TMP_Text _playerName;

        #endregion
    }
}
