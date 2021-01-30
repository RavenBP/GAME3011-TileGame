using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ResourceTile : MonoBehaviour, IPointerClickHandler
{
    Image image;

    //[SerializeField]
    int numResource;

    int randomNum;

    bool canExtract;
    bool canScan;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        canExtract = true;
        canScan = true;

        randomNum = Random.Range(1, 100);

        RandomizeResourceCount();
    }

    void RandomizeResourceCount()
    {
        if (randomNum > 30)
        {
            if (randomNum > 60)
            {
                if (randomNum > 90)
                {
                    numResource = 100;
                }
                else
                {
                    numResource = 50;
                }
            }
            else
            {
                numResource = 25;
            }
        }
        else
        {
            numResource = 0;
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (TileGameManager.canInteract == true)
        {
            if (canExtract == true && TileGameManager.isScanning == false && (TileGameManager.numExtracts > 0))
            {
                switch (numResource)
                {
                    case 0:
                        image.color = Color.black;
                        TileGameManager.message = "No Resources Were Extracted";
                        break;
                    case 25:
                        image.color = Color.black;
                        TileGameManager.resourcesExtracted += 25;
                        TileGameManager.message = "+25 Resources Extracted";
                        break;
                    case 50:
                        image.color = Color.black;
                        TileGameManager.resourcesExtracted += 50;
                        TileGameManager.message = "+50 Resources Extracted";
                        break;
                    case 100:
                        image.color = Color.black;
                        TileGameManager.resourcesExtracted += 100;
                        TileGameManager.message = "+100 Resources Extracted";
                        break;
                }

                canExtract = false;
                canScan = false;
                TileGameManager.numExtracts--;

                if (TileGameManager.numExtracts == 0) // Player has no remaining extractions
                {
                    TileGameManager.canInteract = false;
                    Debug.Log("Out of Extracts");
                }
            }
            else if (canScan == true && TileGameManager.isScanning == true && (TileGameManager.numScans > 0))
            {
                switch (numResource)
                {
                    case 0:
                        image.color = Color.black;
                        canExtract = false;
                        TileGameManager.message = "No Resources Located Here";
                        break;
                    case 25:
                        image.color = Color.blue;
                        TileGameManager.message = "Small Amount of Resources Located Here";
                        break;
                    case 50:
                        image.color = Color.yellow;
                        TileGameManager.message = "Medium Amount of Resources Located Here";
                        break;
                    case 100:
                        image.color = Color.red;
                        TileGameManager.message = "High Amount of Resources Located Here";
                        break;
                }

                canScan = false;
                TileGameManager.numScans--;
            }
            else
            {
                TileGameManager.message = "Invalid Attempt.";
            }
        }
    }
}
