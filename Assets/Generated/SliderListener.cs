using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderListener : MonoBehaviour
{
    [Tooltip("Reference to the Skeleton object")]
    public Skeleton skeleton;

    [Tooltip("Type of value to update")]
    public ValueType valueType;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        if (slider != null)
        {
            slider.onValueChanged.AddListener(OnSliderValueChanged);
        }
    }

    private void OnSliderValueChanged(float value)
    {
        if (skeleton != null)
        {
            skeleton.UpdateValue(valueType, value);
        }
    }
}