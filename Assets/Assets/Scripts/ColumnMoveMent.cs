using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NinjaJump
{
    public class ColumnMoveMent : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        // Update is called once per frame
        void Update()
        {
            if (PlayerJump.instance.isJumping)
            {
                MoveColumn();
            }
        }

        void MoveColumn()
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;
        }

        private void OnTriggerEnter2D(Collider2D target)
        {
            if (target.tag == "Destroy")
            {
                Destroy(gameObject);
            }
        }
    }
}