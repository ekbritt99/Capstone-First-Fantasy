using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCBubbleManager : MonoBehaviour
{
    [SerializeField] private float displaySpeed = 0.05f;

    [Header("Dialogue Text")]
    [SerializeField] private TextMeshProUGUI npcDialogueText;

    [Header("Dialogue Sentences")]
    [TextArea]
    [SerializeField] private string[] npcDialogueSentences;

    [Header("Bubbles")]
    [SerializeField] private GameObject shopBubble;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void startDialogue()
    {
        StartCoroutine(TypeShopNPCDialogue());
    }

    private IEnumerator TypeShopNPCDialogue()
    {
        char[] charSentence = npcDialogueSentences[0].ToCharArray();
        foreach (char letter in charSentence)
        {
            npcDialogueText.text += letter;
            yield return new WaitForSeconds(displaySpeed);
        }
        Invoke("hideShopBubble", 2.0f);
    }

    private void showShopBubble()
    {
        shopBubble.SetActive(true);
    }

    private void hideShopBubble()
    {
        shopBubble.SetActive(false);
    }
}
