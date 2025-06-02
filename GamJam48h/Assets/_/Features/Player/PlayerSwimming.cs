using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerSwimming : MonoBehaviour
    {
        #region Publics
        
        public Slider m_slider;
        public Slider m_sliderMax;
        public Slider m_sliderMin;
        
        
        #endregion
        
        #region Api Unity
        
        void Start()
        {
        
        }

        
        void Update()
        {
        
        }
        #endregion
        
        
        #region Utils

        private void SliderValue()
        {
            if (m_slider.value <= m_slider.maxValue) m_slider.value -= _sliderValue ;
            if (m_slider.value >= m_slider.minValue) m_slider.value += _sliderValue ;
        }
        
        #endregion
        
        
        #region Private And Protected
        
        [SerializeField] private float _sliderValue;
        
        #endregion
    }
}
