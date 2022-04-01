using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainbowSlider : MonoBehaviour
{
    private static bool _isRainbow;
    private Image _sliderColour;
    private float _timer = 0.5f; // Change colour every 0.5 seconds

    // Start is called before the first frame update
    void Start()
    {
        _sliderColour = GameObject.FindGameObjectWithTag("Colour").GetComponent<Image>();
        _isRainbow = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (BossRoomDoor.objCounter >= (BossRoomDoor.totalCollectables / 2))
        {
            _isRainbow = true;
        }
        if (_isRainbow && _timer < 0)
        {
            Color rainbow = new Color(Random.value, Random.value, Random.value);
            _sliderColour.color = rainbow;
            _timer = 0.5f;
        }
        _timer -= Time.smoothDeltaTime;
    }
}
