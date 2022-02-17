using UnityEngine;

namespace Section5.Video2
{
    public class PalmMovement : MonoBehaviour
    {
        public float speed = 10f;
        public float rotationSpeed = 100f;

        private void Update()
        {
            var position = Input.GetAxis("Vertical");
            var rotation = Input.GetAxis("Horizontal");
            if (position != 0)
            {
                position *= speed * Time.deltaTime;
            }

            if (rotation != 0)
            {
                rotation *= rotationSpeed * Time.deltaTime;
            }

            transform.Translate(0f, 0f, position);
            transform.Rotate(0f, rotation, 0f);
        }
    }
}