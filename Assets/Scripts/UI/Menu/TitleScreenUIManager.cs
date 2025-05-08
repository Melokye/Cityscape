using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUIManager : BaseUIManager
{
    [SerializeField] private BaseUI _mainMenu;
    [SerializeField] private BaseUI _optionsMenu;

    void Start(){
        #if UNITY_EDITOR
        DebugTool.CheckSerializeField(this);
        #endif

        OpenUI(_mainMenu);
    }

    public void OpenOptions() => OpenUI(_optionsMenu);
    public void CloseOptions() => CloseCurrentUI();

    public void LoadSceneFromName(string aSceneName){
        // TODO à mettre dans un fichier à part
        SceneManager.LoadScene(aSceneName);
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
