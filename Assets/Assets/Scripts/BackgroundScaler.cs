using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NinjaJump
{
    public class BackgroundScaler : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            Vector3 tempScale = transform.localScale;

            float width = sr.bounds.size.x;
            float height = sr.bounds.size.y;

            float worldHeight = Camera.main.orthographicSize * 2f;
            float worldWidth = worldHeight * Screen.width / Screen.height;

            tempScale.x = worldWidth / width;
            tempScale.y = worldHeight / height;

            transform.localScale = tempScale;
        }
    }
}