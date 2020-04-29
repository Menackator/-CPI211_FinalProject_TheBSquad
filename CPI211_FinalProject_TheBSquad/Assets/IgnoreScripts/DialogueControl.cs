using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueControl : MonoBehaviour
{

    public enum profile
    {
        char1,
        char2
    }

    public class Chat
    {
        public string text;
        public string nameProfile;
        public profile profile;
        public Chat(string myText, string myName, profile myProfile)
        {
            text = myText;
            nameProfile = myName;
            profile = myProfile;
        }
    }

    public Image leftProfile;
    public Image rightProfile;
    public TextMeshProUGUI text;
    public TextMeshProUGUI nameProfile;
    public Sprite char1Image;
    public Sprite char2Image;
    public Sprite noneImage;
    int currentDialogue;

    List<Chat> speechText = new List<Chat>
    {
        new Chat("dialogue","char1",profile.char1)
    };

    // Start is called before the first frame update
    void Start()
    {
        //nothing
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (currentDialogue < speechText.Count)
            {
                text.text = speechText[currentDialogue].text;
                nameProfile.text = speechText[currentDialogue].nameProfile;
                if (speechText[currentDialogue].profile == profile.char1)
                {
                    leftProfile.sprite = char1Image;
                    rightProfile.sprite = noneImage;
                }
                else if (speechText[currentDialogue].profile == profile.char2)
                {
                    leftProfile.sprite = noneImage;
                    rightProfile.sprite = char2Image;
                }
                else
                {
                    //Nothing
                }
                currentDialogue++;
            }
        }
    }
}
