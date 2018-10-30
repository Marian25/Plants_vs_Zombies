using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject thisAttacker in attackerPrefabArray) {
            if (IsTimeToSpawn(thisAttacker)) {
                Spawn(thisAttacker);
            }
        }
	}

    private bool IsTimeToSpawn(GameObject attackerGameObject) {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        if (Time.deltaTime > spawnsPerSecond) {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;

        if (Random.value < threshold) {
            return true;
        }

        return false;
    }

    private void Spawn(GameObject attackerGameObject) {
        GameObject newAttacker = Instantiate(attackerGameObject);
        newAttacker.transform.parent = transform;
        newAttacker.transform.position = transform.position;
    }
}
