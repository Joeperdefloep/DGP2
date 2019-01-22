using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour {

    public float playerSpeed;
    public GameObject player;
    public Inventory inventory;

    public float posX;
    public float posY;
    public float posZ;

    public Animator anim;

    public Transform attackPoint;
    public float attackDisplacement;

    private void Start()
    {
        anim = GetComponent<Animator>();
        posX = PlayerPrefs.GetFloat("positieX");
        posY = PlayerPrefs.GetFloat("positieY");
        posZ = PlayerPrefs.GetFloat("positieZ");
        Vector3 posVec = new Vector3(posX, posY, posZ);
        player.transform.position = posVec;
    }


    // Update is called once per frame
    void FixedUpdate() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //Idle right
        if (horizontal > .01f)
        {
            anim.SetBool("Left", false);
            anim.SetBool("Right", true);
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
            attackPoint.position = new Vector2(attackDisplacement, 0);
            attackPoint.position += transform.position;
        }
        //Idle left
        if (horizontal < -.01f)
        {
            anim.SetBool("Left", true);
            anim.SetBool("Right", false);
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
            attackPoint.position = new Vector2(-attackDisplacement, 0);
            attackPoint.position += transform.position;
        }
        //Idle up
        if (vertical > .01f)
        {
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
            anim.SetBool("Up", true);
            anim.SetBool("Down", false);
            attackPoint.position = new Vector2(0, attackDisplacement);
            attackPoint.position += transform.position;
        }
        //Idle down
        if (vertical < -.01f)
        {
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
            anim.SetBool("Up", false);
            anim.SetBool("Down", true);
            attackPoint.position = new Vector2(0, -attackDisplacement);
            attackPoint.position += transform.position;
        }

        //Walking Left
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            anim.SetBool("WalkLeft", true);
            attackPoint.position = new Vector2(-attackDisplacement, 0);
            attackPoint.position += transform.position;
        }
        else
        {
            anim.SetBool("WalkLeft", false);
        }
        //Walking Right
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            anim.SetBool("WalkRight", true);
            attackPoint.position = new Vector2(attackDisplacement, 0);
            attackPoint.position += transform.position;
        }
        else
        {
            anim.SetBool("WalkRight", false);
        }
        //Walking Up
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            attackPoint.position = new Vector2(0, attackDisplacement);
            attackPoint.position += transform.position;
            anim.SetBool("WalkUp", true);
        }
        else
        {
            anim.SetBool("WalkUp", false);
        }
        //Walking Down
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            anim.SetBool("WalkDown", true);
            attackPoint.position = new Vector2(0, -attackDisplacement);
            attackPoint.position += transform.position;
        }
        else
        {
            anim.SetBool("WalkDown", false);
        }

        transform.Translate(horizontal * playerSpeed * Time.deltaTime, vertical * playerSpeed * Time.deltaTime, 0f, Space.World);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("muntjes", inventory.coinCount);
            PlayerPrefs.SetInt("planken", inventory.plankCount);
            PlayerPrefs.SetInt("schroeven", inventory.nailCount);
            PlayerPrefs.SetFloat("positieX", posX);
            PlayerPrefs.SetFloat("positieY", posY);
            PlayerPrefs.SetFloat("positieZ", posZ);
            Debug.Log(posX + posY + posZ);
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Options");
        }

        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;

    }
}
