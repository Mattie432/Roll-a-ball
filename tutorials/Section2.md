### Moving the player
Lets think about how we want the player to move. We want to be able to roll around on the game area, stay on the ground, bump into walls and not fly off into space. We also want to be able to collect objects and pick them up.
[Tutorial followed from here](https://www.youtube.com/watch?v=IZlaZsQM1Fw)

1. We first need to add a `Ridged body` to our player object.
  1. Do this by selecting the sphere then clicking Component > Physics > RidgedBody
2. Now we need to accept input from the player and apply these as forces to move the player object in the scene. We will do this by creating a script we attach to the game object.
  1. Create a folder in the `Assets` directory by looking at the project view, right clicking  the `Assets` folder and Create > Folder. Call this new folder `Scripts`.
  2. Next we need to create a script. Click the `Player` object and under the `Inspector` view click `Add Component`.
  3. Click `New Script` and Call the script `PlayerControl` and select the language as `C#`.
  4. This creates the script file in the Assets directory and attaches it to the `Player` object
  5. We need to move the script from the 'Assets' folder to the 'Scripts' folder.
3. The next step involves programming the script.
  1. Right click the script file and click `open` this will open it in Unity's text editor.
  2. You will see that some of the standard code has already been added.
  3. If we look at the [MonoBehaviour documentation](http://docs.unity3d.com/ScriptReference/MonoBehaviour.html) we can see that there are some functions which interest us. `Update()` and `FixedUpdate()`. Update is called before rendering a frame and fixed update is called before applying physics to the game.
  4. For movement we will be using the `FixedUpdate` function. This is not added by default so you will need to add it yourself.  Your Code should now look like this.
    ```c
      using UnityEngine;
    using System.Collections;

    public class PlayerMovement : MonoBehaviour {

      // Use this for initialization, this runs when the script is loaded
      void Start () {

      }

      // Update is called once per frame
      void Update () {

      }
      //Called before performing any physics calculations. This is the one we will be using.
      void FixedUpdate () {

      }
    }
    ```
  5. Next we need to get input from the user. We will do this by using the `Input.getAxis()` function which returns if an arrow button is being pressed. You can see examples of this function  [here](http://docs.unity3d.com/ScriptReference/Input.GetAxis.html).
  6. We now need to add the code which detects if the user is pressing a directional key.
    ```c
    float moveHorizontal = Input.GetAxis ("Horizontal");
    float moveVertical = Input.GetAxis ("Vertical");
    ```
    This code is calling the `GetAxis` function of `Input` and saving its value to a variable. We are getting the values for horizontal & vertical which represents left/right & up/down respectively.
  7. Now we need to apply forces to the RigidBody, we can see from the [documentation](http://docs.unity3d.com/ScriptReference/30_search.html?q=rigidbody) that there is a function called `AddForce` ([info](http://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html)). This will add a force to the rigid body and cause it to move.
  8. We can see [examples](http://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html) on how this function can be used. It needs to take a [_Vector3_](http://www.bbc.co.uk/schools/gcsebitesize/maths/geometry/vectorshirev1.shtml) which determines the direction the force is applied.
  9. Add this line of code to the `FixedUpdate()` function.
    ```c
    rigidbody.AddForce (Vector3);
    ```
  10. Now we need to get out two float values (moveHorizontal & moveVertical) into a Vector3 value.
    1. First we need to crate a new Vector3 value called `movement`.
    ```c
    Vector3 movement = new Vector3(x, y z)
    ```
    2. Then as horizontal movement is in the X axis and vertical movement is in the Y axis we can add our floats in to our Vector3.
    ```c
    Vector3 movement = new Vector3 (moveHorizontal, y, moveVertical);
    ```
    3. We still have the Y value unfilled, what should this be?... 0, because we do not want the player to move up or down.
    ```c
    Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
    ```
    4. Now we use `movement` as our Vector3 value in the function `AddForce()`
    ```c
    rigidbody.AddForce (movement);
    ```
  11. Now we can save this script and see what we've done! Go back to unity and click the play button towards the top and try to move the ball. To stop testing, click the play button again.
  12. You can see that the ball moves but it is very slow. We need to speed it up again to make it playable.
    1. Open the script file again.
    2. We need to multiply the vector force to make it move faster. We could do this in out script with a fixed value, but that would mean editing the script again to change it. Instead we will create a variable that can be changed from within Unity.
    3. We need to create a public variable in our script, underneath the class declaration add the line `public float speed;`.
    ```c
    public class PlayerMovement : MonoBehaviour {
      public float speed;
    ```
    4. We then need to multiply the vector by the speed.
    ```c
    rigidbody.AddForce (movement * speed * Time.deltaTime);
    ```
    `delaTime` is used to smooth the movement out while holding the key.
    5. Save the changes and return to Unity.
  13. We can now see there is a `speed` setting below the script when clicking on the `Player` object. Try messing around with this setting to see what is best for the game!

You can view my completed code at this point [here](https://github.com/Mattie432/Roll-a-ball/blob/bc5a5b7a6ddb2136b147cc95110c54488d4c029c/code/Assets/Scripts/PlayerMovement.cs).

You can download the project completed upto this point [here](https://github.com/Mattie432/Roll-a-ball/releases/tag/v0.2)

###[Next Tutorial > 3](Section3.md)
