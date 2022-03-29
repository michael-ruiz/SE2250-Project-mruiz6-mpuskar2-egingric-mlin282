using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainbowSlider : MonoBehaviour
{
    private static bool _isRainbow;
    private Image _sliderColour;

    // Start is called before the first frame update
    void Start()
    {
        _sliderColour = GameObject.FindGameObjectWithTag("Colour").GetComponent<Image>();
        _isRainbow = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Collectable.objCounter == 5)
        {
            _isRainbow = true;
        }
        if (_isRainbow)
        {
            Color rainbow = new Color(Random.value, Random.value, Random.value);
            _sliderColour.color = rainbow;
        }
    }
}
