using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PopUp : MonoBehaviour
{
    public TMP_Text HintText;
    public TMP_Text HintTitle;

    // public Button SkipOneButton;
    // public Button SkipAllButton;
    
    public GameObject Layer;
    
    public PlayerMovement pm;

    private static List<(int Z_Value, PopUpEnums popUpEnums)> tutorialCoordinates;
    private static int highestLevel = 0;

    public static void setTutorialCoordinates(int level)
    {
        if (level <= highestLevel)
        {
            return;
        }

        highestLevel = level;
        
        switch(level) {
			case 1: tutorialCoordinates = FindObjectOfType<GroundSpawner>().tutorialCoordinates;
				break;
			case 2: tutorialCoordinates = FindObjectOfType<GroundSpawner>().tutorialCoordinates2;
				break;
			case 3: tutorialCoordinates = FindObjectOfType<GroundSpawner>().tutorialCoordinates3;
				break;
		}
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initially Hide the PopUp for Hint
        HideLayer();

        // Get the Player Movement Object
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Hide the PopUp Dialog Box
    void HideLayer()
    {
        Layer.transform.localScale = new Vector3(0, 0, 0);
    }
    
    // Show the PopUp Dialog Box
    void ShowLayer()
    {
        Layer.transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        int location = pm.getCurrentPosition();
        if (tutorialCoordinates.Count > 0 && location >= tutorialCoordinates[0].Z_Value)
        {
            pm.FreezeGame();
            SetDialogAttributes(tutorialCoordinates[0].popUpEnums);
            ShowLayer();
            tutorialCoordinates.Remove(tutorialCoordinates[0]);
        }
    }

    public void SetDialogAttributes(PopUpEnums em)
    {
        switch (em)
        {
            case PopUpEnums.TIME:
                HintText.text = "<TIME Hint Text>";
                HintTitle.text = "<TIME Title Text>";
                break;

            case PopUpEnums.PERMEATE:
                HintText.text = "<PERMEATE Hint Text>";
                HintTitle.text = "<PERMEATE Title Text>";
                break;

            case PopUpEnums.LEVITATE:
                HintText.text = "<LEVITATE Hint Text>";
                HintTitle.text = "<LEVITATE Title Text>";

                break;
            case PopUpEnums.SIZE:
                HintText.text = "<SIZE Hint Text>";
                HintTitle.text = "<SIZE Title Text>";

                break;
            case PopUpEnums.SPEED:
                HintText.text = "<SPEED Hint Text>";
                HintTitle.text = "<SPEED Title Text>";
                
                break;
            case PopUpEnums.SHOOT:
                HintText.text = "<SHOOT Hint Text>";
                HintTitle.text = "<SHOOT Title Text>";

                break;
            default:
                HintText.text = "<Default Hint Text>";
                HintTitle.text = "<Default Title Text>";

                break;
        }
    }

    public void NextButtonClicked()
    {
        HideLayer();
        pm.UnFreezeGame();
    }
    
    public void SkipAllButtonClicked()
    {
        if (tutorialCoordinates.Count > 0)
        {
            tutorialCoordinates.RemoveAll(r => true);    
        }
        HideLayer();
        pm.UnFreezeGame();
    }
}