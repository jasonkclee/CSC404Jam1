using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_spawn : MonoBehaviour
{
    public MouseTarget mouse;
    public GameObject[] spawns;
    public float SPAWN_COOLDOWN = 1.5f;
    float curSpawnCoolDown;

    private MouseTarget[] mouses;

    // Start is called before the first frame update
    void Start()
    {
        mouses = new MouseTarget[spawns.Length];
        curSpawnCoolDown = SPAWN_COOLDOWN;
        //InvokeRepeating();
    }

    // Update is called once per frame
    void Update()
    {
        curSpawnCoolDown -= Time.deltaTime;
        // some interval of time passed?
        if (curSpawnCoolDown <= 0)
        {
            
            curSpawnCoolDown = SPAWN_COOLDOWN;
            // Choose 1 random index i in spawns
            int i = Random.Range(0, spawns.Length);
            

            int count = 0;
            while (count != mouses.Length && mouses[i] != null)
            {
                i = (i +1) % mouses.Length;
                count++;
            }

            if (mouses[i] == null)
            {
                //Debug.Log("Spawn occurred " + i);
                GameObject spawn = spawns[i];
                // Instantiate mouse object at spawns[i].transform.position
                mouses[i] = Instantiate(mouse, spawn.transform.position, Quaternion.identity);
            }
            else {
                //Debug.Log("full");
            }

            for (int j = 0; j < mouses.Length; j++) {
                MouseTarget mt = mouses[j];
                if (mt != null && mt.LifeSpan <= 0) {
                    Destroy(mt.gameObject);
                    //Destroy(mt);
                   //Debug.Log("destroyed: " + j);
                    mouses[j] = null;
                }
                
            }
            
        }


    }
}
