using UnityEngine;

namespace Section3.Video3
{
    public class ResourceHolder : MonoBehaviour
    {
        [SerializeField] private Mesh mesh;
        [SerializeField] private Material material;

        public Mesh Mesh => mesh;
        public Material Material => material;
    }
}