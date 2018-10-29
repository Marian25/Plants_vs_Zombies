using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVolume : MonoBehaviour {

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = FindObjectOfType<MusicManager>();
        if (musicManager) {
            musicManager.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
        } else {
            Debug.LogWarning("No music manager found in Start Scene");
        }
	}

}
