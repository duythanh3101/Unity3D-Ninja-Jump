using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NinjaJump
{
    public class SpawnerColumn : MonoBehaviour
    {
        [SerializeField]
        private GameObject ColumnObject;

        [HideInInspector]
        public float minDistanceOfTwoColumn = 1.25f;

        [HideInInspector]
        public float maxDistanceOfTwoColumn = 2.5f;

        [HideInInspector]
        public float maxSpawnerDistance = 10f;

        private float defaultSpawnerCoordinate = -2.5f;

        private void Start()
        {
            Spawner(defaultSpawnerCoordinate);
        }

        public void Spawner(float coordinateX)
        {
            if (coordinateX - maxSpawnerDistance < Mathf.Epsilon)
            {
                float coordinateY = Random.Range(-4f, -1.25f);

                Instantiate(ColumnObject, new Vector3(coordinateX, coordinateY, 0f), Quaternion.identity);

                coordinateX += minDistanceOfTwoColumn + Random.Range(minDistanceOfTwoColumn, maxDistanceOfTwoColumn);

                Spawner(coordinateX);
            }
        }
    }
}