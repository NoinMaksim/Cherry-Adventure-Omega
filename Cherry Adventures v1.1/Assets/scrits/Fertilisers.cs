using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fertilisers : MonoBehaviour
{
    [SerializeField] Player_UI _UI;
    public int fertilizers = 0;
    float x = 10;




    /// <summary>
    /// Создания удобрения(ий)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="fertilizer_Prefab"></param>
    public void Init_Fertilizers(int a ,GameObject fertilizer_Prefab)
    {
        Debug.Log("Instantiate ");
        
        for (int i = 0; i < a; i++)
        {
            Instantiate(fertilizer_Prefab, new Vector3(x, -2.6f, 0), Quaternion.Euler(0, 0, 0));
            x--;
            Debug.Log("Instantiate " + i);
            
        }       
    }

    
    

    /// <summary>
    /// Добавление/удаление удобрений
    /// </summary>
    public void Addfertilizers()
    {
        _UI.changeQualityfertilizers(fertilizers);

       _UI.Renderfertilizers();
    }

    public void Destroy_Fertilizer(GameObject bject)
    {
        Debug.Log("Delete " + bject);
        fertilizers++;
        Addfertilizers();
        Destroy(bject);
    }

}
