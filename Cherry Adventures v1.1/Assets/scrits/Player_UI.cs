using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI : MonoBehaviour
{

    public Text fertilizersText;
    [SerializeField] private Fertilisers Fertilisers;
    private int Qualityfertilizers = 0;
    private void Awake()
    {
       
    }
    private void Start()
    {

        Renderfertilizers();
    }

    public void changeQualityfertilizers(int a)
    {
        Debug.Log("Qualityfertilizers: " + a);
        Qualityfertilizers = a;

    }

    
    public void Renderfertilizers()
    {
        fertilizersText.text = Qualityfertilizers.ToString();
    }

    public void Game()
    {
        SceneManager.LoadScene("Game_Scene");
    }

    public void Skils_Menu()
    {
        SceneManager.LoadScene("Skils_Scene");
    }
}
