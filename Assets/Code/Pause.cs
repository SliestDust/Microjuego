using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Pause : MonoBehaviour
{
public static bool gameIsPaused;
public Button b;
public GameObject go;
    void start(){
	b.onClick.AddListener(PauseGame);
        go.GetComponent<TextMeshProUGUI>().text = "";

    }
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame ()
    {
	
        gameIsPaused = !gameIsPaused;
        if(gameIsPaused)
        {
        go.GetComponent<TextMeshProUGUI>().text = "PAUSADO";
            Time.timeScale = 0f;
        }
        else 
        {
	
        go.GetComponent<TextMeshProUGUI>().text = "";
            Time.timeScale = 1;
        }
    }
    public void OnClick(){
	Debug.Log("Boton press");
	    PauseGame();
            //Time.timeScale = 0f;
    }
}
