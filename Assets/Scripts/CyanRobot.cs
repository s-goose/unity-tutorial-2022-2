using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyanRobot : BasicRobot
{
    public override string robotClassName { get { return "CyanBot"; } }
    public override float jumpPower { get => base.jumpPower*0.8f; }
    public ParticleSystem specialParticalSystem;
    public override void SpecialFunction() {
        specialParticalSystem.Play();
    }

    public override void Identify() {
        dialogBox.SaySomething($"HELLO! I AM SUPER-SPECIAL {robotClassName.ToUpper()}!!!");
    }
}
