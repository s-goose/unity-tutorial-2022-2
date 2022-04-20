# unity-tutorial-2022-2
This is a project to demonstrate C# object-oriented principles for
the Unity tutorial "Programming theory in action".
https://learn.unity.com/tutorial/submission-programming-theory-in-action

The complete unity project consists of three robots (derived from a base
class) that follow commands.

The base class is "BasicRobot" from which three subtypes are derived:
CyanRobot, MagentaRobot, and YellowRobot. All the robots implement or inherit...

 - Greet() is a common method shared by all subtypes.

 - Identify() is a virtual method that Cyan overrides to Identify more enthusiastically.

 - Jump() is a virtual method that Magenta overrides to express joy in jumping. All
robots jump strength is determined by the property jumpPower, which is also overridden.

 - SpecialFunction() is an abstract method, so each robot is required to have its own.

A menu is provided to invoke methods using a singleton-like instance of RobotManager.
All robots register with RobotManager on Start() and deregister OnDestroy().

There are opportunities for improvement in this project. :)

JV
