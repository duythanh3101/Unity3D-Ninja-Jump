using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NinjaJump
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private PlayerJump playerJump;

        [SerializeField]
        private GameObject PowerBarObject;

        [SerializeField]
        private SpawnerColumn SpawnerColumn;

        private float jumpPower;

        // Use this for initialization
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject powerBar = Instantiate(PowerBarObject) as GameObject;

                GameObject[] columns = GameObject.FindGameObjectsWithTag("Column");
                float maxColumnDistance = 0;
                foreach (GameObject Column in columns)
                {
                    maxColumnDistance = Mathf.Max(maxColumnDistance, Column.transform.position.x);
                }
                
                if (maxColumnDistance < SpawnerColumn.maxSpawnerDistance)
                {
                    SpawnerColumn.Spawner(maxColumnDistance + 
                        SpawnerColumn.minDistanceOfTwoColumn +
                        Random.Range(SpawnerColumn.minDistanceOfTwoColumn, SpawnerColumn.maxDistanceOfTwoColumn));
                }
            }

            if (Input.GetKeyUp(KeyCode.Space) && playerJump.isJumping == false)
            {
                GameObject powerObject = GameObject.FindWithTag("Power");

                JumpForcePower script = powerObject.GetComponent("JumpForcePower") as JumpForcePower;

                jumpPower = script.jumpPower;

                Destroy(GameObject.FindWithTag("Power"));

                playerJump.Jumping(jumpPower);
            }
        }
    }
}