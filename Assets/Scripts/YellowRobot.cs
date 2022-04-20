using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowRobot : BasicRobot
{
    public override string robotClassName { get { return "YellowBot"; } }
    public override void SpecialFunction() {
        dialogBox.SaySomething("vidi vici veni. ego sum flavo.");
    }
}
