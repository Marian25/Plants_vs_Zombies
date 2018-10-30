using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    [SerializeField] Camera myCamera;

    private GameObject defenderParent;
    private StarDisplay starDisplay;

    private void Start()
    {
        defenderParent = GameObject.Find("Defenders");
        starDisplay = FindObjectOfType<StarDisplay>();

        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }

    private void OnMouseDown()
    {
        if (Button.selectedDefender) {
            int defenderCost = Button.selectedDefender.GetComponent<Defender>().starCost;

            if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS) {
                SpawnDefender();
            } else {
                Debug.Log("Insufficient stars to spawn");
            }

        }
    }

    private void SpawnDefender()
    {
        Vector2 roundedPos = SnapToGrid(CalculateWorldPointOfMouseClick());
        GameObject newDef = Instantiate(Button.selectedDefender, roundedPos, Quaternion.identity);
        newDef.transform.parent = defenderParent.transform;
    }

    private Vector2 CalculateWorldPointOfMouseClick() {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 triplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(triplet);

        return worldPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos) {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
}
