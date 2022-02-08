using Section3.Video4;
using UnityEngine;
using UnityEngine.UI;

namespace Section3.Video5
{
    public class UICounter : MonoBehaviour
    {
        [SerializeField] private Text sheepText;
        [SerializeField] private Text tankText;
        [SerializeField] private Button sheepButton;
        [SerializeField] private Button tankButton;

        [SerializeField] private ECSInterface ecsInterface;
        

        private void Start()
        {
            sheepButton.onClick.AddListener(() =>
            {
                var sheepCount = ecsInterface.CountSheepEntities();
                sheepText.text = $"{sheepCount}";
            });
            
            tankButton.onClick.AddListener(() =>
            {
                var tankCount = ecsInterface.CountTankEntities();
                tankText.text = $"{tankCount}";
            });
        }

    }
}
