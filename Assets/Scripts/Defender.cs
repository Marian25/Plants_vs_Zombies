using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    private StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    // Only being used as a tag for now

    public void AddStars(int amount) {
        starDisplay.AddStars(amount);
    }

}
