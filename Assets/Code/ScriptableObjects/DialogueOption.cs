using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Option", menuName = "Dialogue System/Dialogue Option")]
public class DialogueOption : ScriptableObject
{
    [TextArea(3, 10)]
    public string optionText;
    
    public DialogueConversation nextConversation;
}
