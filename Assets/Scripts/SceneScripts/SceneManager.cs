using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Cambiar a esta escena cuando se presione una tecla o se haga clic en un botón.
    public string targetSceneName = "TargetScene";

    void Update()
    {
        // Puedes cambiar de escena cuando se presione una tecla, por ejemplo, la tecla "Espacio".
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeScene(targetSceneName);
        }
    }

    public void ChangeScene(string SampleScene)
    {
        // Cargar la escena especificada.
        SceneManager.LoadScene(SampleScene);
    }
}

