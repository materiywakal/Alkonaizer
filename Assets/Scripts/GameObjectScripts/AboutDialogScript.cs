using UnityEngine;
using UnityEngine.UI;

public class AboutDialogScript : MonoBehaviour
{
    private string[] TextToDisplay;
    private int CurrentPage;

    [SerializeField] public GameObject NextButton;
    [SerializeField] public GameObject CloseButton;
    [SerializeField] public GameObject DisplayedText;

    private void Start()
    {
        TextToDisplay = new string[]
        {
            "Для начала пользования приложением заполните требуемые поля во вкладке с данными о человеке, найти которую можно нажав на кнопку в правом верхнем углу.",
            "После этого можно добавить алкогольную продукцию. Для этого нажмите на + и заполните данные об алкоголе.",
            "Сверху появится статус, обозначающий состояние пользователя при распитии указанных им напитков. Число обозночает процентное соотношение от текущего до следующего состояния."
        };
        CurrentPage = 0;
        DisplayedText.GetComponent<Text>().text = TextToDisplay[CurrentPage];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DestroySelf();
        }
    }

    public void NextPage()
    {
        CurrentPage++;
        if (CurrentPage >= TextToDisplay.Length)
        {
            DestroySelf();
            return;
        }

        DisplayedText.GetComponent<Text>().text = TextToDisplay[CurrentPage];
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}