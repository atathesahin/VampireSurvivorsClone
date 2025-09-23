using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public enum MainMenuState
    {
        MainMenu = 0,
        Options = 1,
        LevelSelect = 2
    }
    
    public MainMenuState state;

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject levelSelectPanel;
    
    
    private void Start()
    {
        SwitchState(MainMenuState.MainMenu);
    }
    
    public void SwitchState(int switchState)
    {
        SwitchState((MainMenuState)switchState);
    }
    
    
    private void SwitchState(MainMenuState switchState)
    {
        mainMenuPanel.SetActive(switchState == MainMenuState.MainMenu);
        optionsPanel.SetActive(switchState == MainMenuState.Options);
        levelSelectPanel.SetActive(switchState == MainMenuState.LevelSelect);
        

        state = switchState;
    }
}
