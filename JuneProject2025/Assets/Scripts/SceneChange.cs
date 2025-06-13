using UnityEngine;
using UnityEngine.SceneManagement;

// using this script will make sprite, when clicked, change to a specified scene
public class SceneChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string sceneToChangeTo;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    void OnMouseDown()
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
