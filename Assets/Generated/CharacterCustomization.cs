using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Generated
{
    public class CharacterCustomization : MonoBehaviour
    {
        [SerializeField] private Slider _sliderPrefab;

        [Tooltip("The UnityEvent to trigger when the height slider is modified.")]
        public UnityEvent onHeightSliderChanged;

        [Tooltip("The UnityEvent to trigger when the girth slider is modified.")]
        public UnityEvent onGirthSliderChanged;

        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        private void Start()
        {
            // Create height slider
            // var heightSlider = Instantiate(_sliderPrefab);
            // heightSlider.onValueChanged.AddListener(delegate { onHeightSliderChanged.Invoke(); });
            // heightSlider.GetComponent<RectTransform>().anchoredPosition = new Vector2(10, -10);
            // heightSlider.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 20);
            // heightSlider.colors = new ColorBlock { normalColor = Color.black, highlightedColor = Color.gray, pressedColor = Color.white, disabledColor = Color.gray, colorMultiplier = 1 };
            //
            // // Create girth slider
            // var girthSlider = Instantiate(_sliderPrefab);
            // girthSlider.onValueChanged.AddListener(delegate { onGirthSliderChanged.Invoke(); });
            // girthSlider.GetComponent<RectTransform>().anchoredPosition = new Vector2(10, -40);
            // girthSlider.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 20);
            // girthSlider.colors = new ColorBlock { normalColor = Color.black, highlightedColor = Color.gray, pressedColor = Color.white, disabledColor = Color.gray, colorMultiplier = 1 };
            //
            // // Create labels
            // var heightText = Instantiate(_labelPrefab);
            // heightText.text = "Height";
            // heightText.color = Color.white;
            // heightText.alignment = TextAnchor.MiddleLeft;
            //
            // var girthLabel = new GameObject("Girth Label");
            // girthLabel.transform.SetParent(girthSlider.transform);
            // var girthText = girthLabel.AddComponent<Text>();
            // girthText.text = "Girth";
            // girthText.color = Color.white;
            // girthText.alignment = TextAnchor.MiddleLeft;
        }
    }
}