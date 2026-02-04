using UnityEngine;

public class Cup : MonoBehaviour
{
    public GameObject winPanel; // référence au panel "You Won"

    void Start()
    {
        // s'assure que le panel est désactivé au début
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (winPanel != null)
                winPanel.SetActive(true); // afficher l'écran "Won"

            // optionnel : arrêter le jeu
            Time.timeScale = 0f;
        }
    }
}
