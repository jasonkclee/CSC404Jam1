using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * - despawn yarn object after short period of time
 * - handle collision event between yarn and mouse
 * 
 * - attach Sound effects
 * X mouse spawning/position determining
 * - score tracking
 * - limit rate of fire
 * - time limit 
 * - restart button
 * 
 * 
 * */
using UnityEngine.UI;

public class MyController : MonoBehaviour
{

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject yarn;
    public GameObject yarnSpawn;
    public Camera gameCamera;
    public Collider table;

    public float throwSpeed = 40;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public Text scoreText;
    public int score = 0;
    //public AudioSource throwSound;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        // Instantiate at position (0, 0, 0) and zero rotation.
        // Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        float val = Input.GetAxis("Fire1");
        if (Input.GetMouseButtonUp(0)) {
            //throwSound.Play(0);

            // Create a new yarn ball
            yarn = Instantiate(yarn, yarnSpawn.transform.position, Quaternion.identity);
            yarn.GetComponent<Yarn>().controller = this;
            Rigidbody rb = yarn.GetComponent<Rigidbody>();

            // Determine direction of throw
            Ray ray = gameCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            RaycastHit hit;
            float raycastDist = 200;
            
            if (table.Raycast(ray, out hit, raycastDist))
            {
                //Debug.Log("Intersection found");
                Vector3 hitPoint = hit.point;
                hitPoint.y += 1;
                Vector3 dir = (hitPoint - yarnSpawn.transform.position);
                dir.Normalize();
                rb.velocity = dir * throwSpeed;
                //transform.position = ray.GetPoint(100.0f);
            }
            else {
                //Debug.Log("No intersection");
                Vector3 dir = ray.direction;
                dir.Normalize();
                rb.velocity = dir * throwSpeed;//new Vector3(0, 7, 5);
            }


            
          
        }   
    }
}
