using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileGameManager : MonoBehaviour
{
    [SerializeField]
    Image buttonImage;
    [SerializeField]
    Sprite scanningSprite;
    [SerializeField]
    Sprite extractingSprite;

    [SerializeField]
    Text modeText;
    [SerializeField]
    Text resourcesExtractedText;
    [SerializeField]
    Text extractsText;
    [SerializeField]
    Text scansText;

    [SerializeField]
    Text messageText;

    [SerializeField]
    GameObject resultsPanel;
    [SerializeField]
    Text resultsText;

    public static string message;
    public static int numExtracts;
    public static int numScans;
    public static bool isScanning;
    public static bool canInteract;

    public static int resourcesExtracted;

    bool resultsDisplayed;

    private void Start()
    {
        message = " ";
        numExtracts = 3;
        numScans = 6;
        resourcesExtracted = 0;
        isScanning = false;
        canInteract = true;

        resultsDisplayed = false;
    }

    private void Update()
    {
        // This could be put into an event...
        extractsText.text = "Extracts: " + numExtracts.ToString();
        scansText.text = "Scans: " + numScans.ToString();
        messageText.text = message;
        resourcesExtractedText.text = "Resources Extracted: " + resourcesExtracted.ToString();

        if (numExtracts < 1 && resultsDisplayed == false)
        {
            DisplayResults();
        }
    }

    public void ToggleMode()
    {
        isScanning = !isScanning;

        if (isScanning == true)
        {
            buttonImage.sprite = scanningSprite;
            modeText.text = "Scan Mode";
        }
        else
        {
            buttonImage.sprite = extractingSprite;
            modeText.text = "Extract Mode";
        }
    }

    public void DisplayResults()
    {
        resultsDisplayed = true;

        resultsText.text = "Resources Extracted: " + resourcesExtracted.ToString();
        resultsPanel.SetActive(true);
    }
}
