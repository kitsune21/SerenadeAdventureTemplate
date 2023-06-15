using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Line", menuName = "Dialogue System/Dialogue Line")]
public class DialogueLine : ScriptableObject
{
    [TextArea(3, 10)]
    public string speaker;
    [TextArea(3, 10)]
    public string text;
    
    public DialogueOption[] options;
}
