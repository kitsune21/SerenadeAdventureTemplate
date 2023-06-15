using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUITester : MonoBehaviour
{
    public TMP_Text speakerText;
    public TMP_Text lineText;

    public GameObject textPrefab;
    public GameObject optionsPanel;
    private List<GameObject> optionsTextPrefabs = new List<GameObject>();

    private void updateSpeakerText(string newSpeaker) {
        speakerText.text = newSpeaker;
    }

    private void updateLineText(string newLine) {
        lineText.text = newLine;
    }
    

    public void DisplayLine(DialogueLine newLine) {
        updateSpeakerText(newLine.speaker);
        updateLineText(newLine.text);
    }

    public void DisplayOption(DialogueOption newOption) {
        GameObject tempOption = Instantiate(textPrefab, optionsPanel.transform);
        tempOption.GetComponent<TMP_Text>().text = newOption.optionText;
        optionsTextPrefabs.Add(tempOption);
    }

    public void ClearOptions() {
        foreach(GameObject optionsTextPrefab in optionsTextPrefabs) {
            Destroy(optionsTextPrefab);
        }
        optionsTextPrefabs.Clear();
    }
}
