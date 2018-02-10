using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NinjaJump
{
    public class JumpForcePower : MonoBehaviour
    {
        public float jumpPower = 0;

        private float maxJumpPower = 0.35f;

        private void Update()
        {
            jumpPower = Mathf.Min(jumpPower + Time.deltaTime, maxJumpPower);
        }
    }
}