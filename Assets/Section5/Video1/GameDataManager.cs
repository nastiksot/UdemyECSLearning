using UnityEngine;

namespace Section5.Video1
{
    public class GameDataManager : MonoBehaviour
    {
        public static GameDataManager instance;
        public Transform palmTransform;

        private void Awake()
        {
            instance = this;
        }
    }
}