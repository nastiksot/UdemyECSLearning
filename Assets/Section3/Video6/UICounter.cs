using UnityEngine;
using UnityEngine.UI;

namespace Section3.Video6
{
    public class UICounter : MonoBehaviour
    {
        [SerializeField] private Text sheepText;
        [SerializeField] private Text tankText;
        [SerializeField] private Text palmTreeText;
        [SerializeField] private Button sheepButton;
        [SerializeField] private Button tankButton;
        [SerializeField] private Button palmTreeButton;

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
            palmTreeButton.onClick.AddListener(() =>
            {
                var palmCount = ecsInterface.CountPalmTreeEntities();
                palmTreeText.text = $"{palmCount}";
            });
        }

    }
}
