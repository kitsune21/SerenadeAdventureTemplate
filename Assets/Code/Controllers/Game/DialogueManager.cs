using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public DialogueConversation conversation; // Reference to the DialogueConversation scriptable object
    private int currentLineIndex = 0; // Track the current dialogue line index
    private bool displayingOptions = false; // Track if options are being displayed

    private DialogueUITester uITester;

    private void Start() {
        uITester = GetComponentInParent<DialogueUITester>();
        StartConversation(); 
    }

    private void StartConversation()
    {
        currentLineIndex = 0;
        DisplayCurrentLine();
    }

    private void DisplayCurrentLine()
    {
        DialogueLine currentLine = conversation.GetLine(currentLineIndex);
        uITester.DisplayLine(currentLine);

        if (currentLine.options.Length > 0)
        {
            displayingOptions = true;
            foreach(DialogueOption option in currentLine.options) {
                uITester.DisplayOption(option);
            }
        }
        else
        {
            displayingOptions = false;
        }
    }

    public void SelectOption(int optionIndex)
    {
        if (displayingOptions)
        {
            DialogueLine currentLine = conversation.GetLine(currentLineIndex);
            DialogueOption selectedOption = currentLine.options[optionIndex];

            // Proceed to the next conversation based on the selected option
            if (selectedOption.nextConversation != null)
            {
                conversation = selectedOption.nextConversation;
                currentLineIndex = 0;
                DisplayCurrentLine();
            }
            else
            {
                // Handle the case where the selected option doesn't have a next conversation
                // It could be the end of the dialogue or some other custom logic
            }
        }
    }

    private void AdvanceToNextLine()
    {
        currentLineIndex++;
        if (currentLineIndex >= conversation.lines.Length)
        {
            // End of conversation
            // Add your logic for what happens when the conversation ends
        }
        else
        {
            DisplayCurrentLine();
        }
    }

    // Other methods for handling player input, choices, etc.
}