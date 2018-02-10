using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NinjaJump
{
    public class PlayerJump : MonoBehaviour
    {
        public static PlayerJump instance;

        [SerializeField]
        private float magnitudeForce;

        private Rigidbody2D rbPlayer;

        [HideInInspector]
        public bool isJumping;

        protected virtual void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            DontDestroyOnLoad(gameObject);

            rbPlayer = GetComponent<Rigidbody2D>();

            isJumping = false;
        }

        public void Jumping(float power)
        {
            isJumping = true;

            rbPlayer.velocity = new Vector2(0f, magnitudeForce * power);

            new WaitForSeconds(3);
        }

        public void OnCollisionEnter2D(Collision2D target)
        {
            isJumping = false;
            if (target.gameObject.tag == "Ground")
            {
                Destroy(GameObject.FindWithTag("Player"));
#pragma warning disable CS0618 // Type or member is obsolete
                Application.LoadLevel(Application.loadedLevel);
#pragma warning restore CS0618 // Type or member is obsolete
            }
        }

    }
}