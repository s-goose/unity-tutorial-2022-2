using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicRobot : MonoBehaviour
{
    public string greeting = "hello world";
    public float groundLevel = 0.0f;
    protected DialogBox dialogBox;
    protected Rigidbody rb;
    public virtual string robotClassName {get; protected set;} = "Unnamed kind of robot";
    public virtual float jumpPower {get; protected set;} = 8f;

    void Start() {
        // Find out dialog box
        dialogBox = GetComponentInChildren<DialogBox>();

        // Setup a RigidBody. It would be more cpu efficient to use [RequireComponent (typeof (RigidBody))] and add an RB to the prefabs. Backlog!
        rb = gameObject.AddComponent<Rigidbody>();

        // Register with controller
        RobotManager.Instance.AddRobot(this);

        // Say hello
        Greet();
    }

    void OnDestroy() {
        // don't leave references to objects that don't exist in the Manager's list!
        RobotManager.Instance.RemoveRobot(this);
    }

    void Update() {
        // dampen falling
        if (transform.position.y < groundLevel+0.1f && rb.velocity.y < 0.0f) {
            rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y*0.1f,rb.velocity.z);
        }
        // constant small upward thrust
        if (transform.position.y < groundLevel+0.25f) {
            rb.AddForce(new Vector3(0,Random.Range(0.25f,1f),0), ForceMode.Impulse);
        }
    }

    // ---------------------
    // --- Robot Methods ---
    // ---------------------

    // All robots greet in the same way... because their programming forces them too!
    public void Greet() {
        dialogBox.SaySomething(greeting);
    }

    // Robots can Identify and Jump as they wish or per the instruction manual
    public virtual void Identify() {
        dialogBox.SaySomething($"Hello. My name is {robotClassName}");
    }

    public virtual void Jump() {
        // Add jump power only if we aren't too far away from the ground.
        if (transform.position.y < 50f+groundLevel) {
            rb.velocity = new Vector3(rb.velocity.x, 0 ,rb.velocity.z); // set y velocity to zero to make sure jump is consistent
            rb.AddForce(new Vector3(0f,jumpPower,0f), ForceMode.Impulse);
        }
    }

    // Robots are required to develop their own SpecialFunction in order to receive their robot degree from Compiler University
    public abstract void SpecialFunction();
}
