using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagentaRobot : BasicRobot
{
    public override string robotClassName { get { return "MagentaBot"; } }
    public override float jumpPower { get => base.jumpPower*1.5f; }

    public override void Jump(){
        base.Jump();
        dialogBox.SaySomething("Yeay!");
    }

    public override void SpecialFunction() {
        // Add jump power only if we aren't too far away from the ground.
        if (transform.position.y < 200f+groundLevel) {
            rb.AddForce(new Vector3(0f,jumpPower*1.2f,0f), ForceMode.Impulse);
        }
        dialogBox.SaySomething("more jumping!");
    }
}
