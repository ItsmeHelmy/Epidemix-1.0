using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{

    public Image actorImg;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI msgTxt;
    public RectTransform bgBox;

    Message[] currentMsgs;
    Actor[] currentActors;
    int activeMsg = 0;
    public static bool isActive = false;



    public void OpenDialogue(Message[] msgs, Actor[] actors)
    {
        currentMsgs = msgs;
        currentActors = actors;
        activeMsg = 0;
        isActive= true;

        Debug.Log("Started conversation! Loaded messages: " + msgs.Length);
        displayMsg();
        bgBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    void displayMsg()
    {
        Message messageToDisplay = currentMsgs[activeMsg];
        msgTxt.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImg.sprite = actorToDisplay.sprite;
    }

    public void nextMsg()
    {
        activeMsg++;
        if (activeMsg < currentMsgs.Length)
        {
            displayMsg();
        } else
        {
            Debug.Log("Conversation ended");
            bgBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive= false;
            FindObjectOfType<Transition>().LoadNextLevel();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bgBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            nextMsg();
        }
    }
}
