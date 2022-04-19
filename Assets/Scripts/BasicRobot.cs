using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRobot : MonoBehaviour
{
    protected DialogBox dialogBox;
    public string MyGreeting = "hello world";

    void Start() {
        dialogBox = GetComponentInChildren<DialogBox>();
        Talk();
    }

    public void Talk() {
        dialogBox.SaySomething("Hello World");
    }
}
