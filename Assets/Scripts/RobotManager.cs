using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    // Make a single instance so this behaves as a singleton.
    // This is a form of encapsulation as the underlying Instance is private and is
    // managed elsewhere
    // ENCAPSULATION
    public static RobotManager Instance {
        get { return _instance; }
    }
    private static RobotManager _instance;

    // This list is intended to contain all of the active BasicRobot instances.
    // Robots add themselves to this list in their Start() and remove themselves
    // OnDestroy(). This is accomplished with the AddRobot and RemoveRobot methods.
    // This is another form of encapsulation.
    // ENCAPSULATION
    public List<BasicRobot> Robots { get; private set;}

    void Awake() {
        // check for "this" also just in case Awake is ever double called (which shouldn't happen). 
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
        }
        _instance = this;
        
        Robots = new List<BasicRobot>(); // Robots will self register
    }

    public void AddRobot(BasicRobot robot) {
        if (!Robots.Contains(robot)) Robots.Add(robot);
    }

    public void RemoveRobot(BasicRobot robot) {
        if (Robots.Contains(robot)) Robots.Remove(robot);
    }
    void OnDestroy() {
        if (Instance == this) _instance = null;
    }

    // Robot Functions
    public void Greet() {
        foreach (BasicRobot robot in Robots) {
            robot.Greet();
        }
    }
    public void Jump() {
        foreach (BasicRobot robot in Robots) {
            robot.Jump();
        }
    }
    public void Identify() {
        foreach (BasicRobot robot in Robots) {
            robot.Identify();
        }
    }
    public void SpecialFunction() {
        foreach (BasicRobot robot in Robots) {
            robot.SpecialFunction();
        }
    }
}
