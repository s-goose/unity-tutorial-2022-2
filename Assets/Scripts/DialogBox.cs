using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public float talkTime = 3.5f; // Time to display the message
    private Text text;
    private float timeout = 0.0f;

    void Awake(){
        // This is declared in awake instead of Start because
        // other objects may make use a DialogBox in their Start()
        // which can leading to NullRefs if we hadn't done this here.
        // OR... we could have just set text in the inspector.
        text = GetComponentInChildren<Text>();
        text.text = "";
    }

    void Update() {
        if (timeout <= 0.0f) return;

        if ( (timeout - Time.deltaTime) <= 0.0f) {
            text.text = "";
            timeout = 0.0f;
        } else {
            timeout -= Time.deltaTime;
        }
    }

    public void SaySomething(string talk) {
        // Set the dialog text and begin a countdown to clear it.
        text.text = talk;
        timeout = talkTime;
    }
}
