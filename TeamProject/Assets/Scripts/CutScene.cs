using UnityEngine;

public class CutScene : MonoBehaviour
{
    [TextArea(1,5)]
    [SerializeField] private string[] dialogs;
    private int dialogIndex = 0;

    [SerializeField] private TMPro.TextMeshProUGUI dialogText;

    
    public void SetNextReplica()
    {
        dialogText.text = dialogs[dialogIndex];
        dialogIndex++;
    }
}
