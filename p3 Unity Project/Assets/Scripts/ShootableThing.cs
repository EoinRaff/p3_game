using UnityEngine;
using System.Collections;

public class ShootableThing : MonoBehaviour
{

    //The enemies/objects current health point total which should be set according to their color
    public int currentHealth;

    //Colors used for checking the current material color of the enemy/object and the gun it is shot with
    Color Red = new Color(1f, 0f, 0f, 1f);
    Color Green = new Color(0f, 1f, 0f, 1f);
    Color Blue = new Color(0f, 0f, 1f, 1f);
    Color Cyan = new Color(0f, 1f, 1f, 1f);
    Color Magenta = new Color(1f, 0f, 1f, 1f);
    Color Yellow = new Color(1f, 1f, 0f, 1f);

    /*
	//Initialize and instantiate new object of class RayCastShooting
	//this is done to get acces to gunColor in class RayCastShooting
	RayCastShooting gun = new RayCastShooting ();
	*/

    /*
	//!!!!!OBS DOENST REALLY WORK YET!!!!!
	//used for setting the currentHealt according to the color of the enemy/object  
	void SetHealth(){

		//if the enemy is cyan, magenta or yellow it should have a health of 2 because it should be shot with two colors before it can die
		if(gameObject.GetComponent <Renderer> ().material.color == Cyan || gameObject.GetComponent <Renderer> ().material.color == Magenta || gameObject.GetComponent <Renderer> ().material.color == Yellow){
			currentHealth = 2;
		}
		//if the enemy is red, green or blue it should have a health of 1 because it should only be shot once to die
		else if(gameObject.GetComponent <Renderer> ().material.color == Red || gameObject.GetComponent <Renderer> ().material.color == Green || gameObject.GetComponent <Renderer> ().material.color == Blue){
			currentHealth = 1;
		}
	}
	*/

    public void Damage(int damageAmount, string gunColor)
    {

        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;


        //CYAN ENEMY
        //if the cyan enemy is shot by a green gun it should turn blue, else if it is shot by a blue gun it should turn green
        if (currentHealth == 1 && gameObject.GetComponent<Renderer>().material.color == Cyan && gunColor == "Green")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            print("Cyan hit by Green");
        }
        else if (currentHealth == 1 && gameObject.GetComponent<Renderer>().material.color == Cyan && gunColor == "Blue")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            print("Cyan hit by Blue");
        }


        //MAGENTA ENEMY	
        //if the magenta enemy is shot by a blue gun it should turn red, else if it is shot by a red gun it should turn blue
        if (currentHealth == 1 && gameObject.GetComponent<Renderer>().material.color == Magenta && gunColor == "Blue")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            print("Magenta hit by Blue");
        }
        else if (currentHealth == 1 && gameObject.GetComponent<Renderer>().material.color == Magenta && gunColor == "Red")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            print("Magenta hit by Red");
        }



        //YELLOW ENEMY
        //if the yellow enemy is shot by a red gun it should turn green, else if it is shot by a green gun it should turn red
        if (currentHealth == 1 && gameObject.GetComponent<Renderer>().material.color == Yellow && gunColor == "Red")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            print("Yellow hit by Red");
        }
        else if (currentHealth == 1 && gameObject.GetComponent<Renderer>().material.color == Yellow && gunColor == "Green")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            print("Yellow hit by Green");
        }



        //RGB ENEMIES

        //if the red enemy is shot by a red gun it should dissapear/die
        if (currentHealth <= 0 && gameObject.GetComponent<Renderer>().material.color == Red && gunColor == "Red")
        {
            gameObject.SetActive(false);
            print("Red hit");
        }

        //if the blue enemy is shot by a blue gun it should dissapear/die
        if (currentHealth <= 0 && gameObject.GetComponent<Renderer>().material.color == Blue && gunColor == "Blue")
        {
            gameObject.SetActive(false);
            print("Blue hit");
        }

        //if the green enemy is shot by a green gun it should dissapear/die
        if (currentHealth <= 0 && gameObject.GetComponent<Renderer>().material.color == Green && gunColor == "Green")
        {
            gameObject.SetActive(false);
            print("Green hit");
        }
    }
}

