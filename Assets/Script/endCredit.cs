using UnityEngine;
using UnityEngine.SceneManagement;

public class endCredit : MonoBehaviour
{
    public string sceneToEnding;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToEnding);
        }
    }
}
