using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cucumberTakl : MonoBehaviour
{
    public GameObject money; //Монетка
    public GameObject canvas; //Канвас диалога
    public Transform tr; //Свойство Transform для монетки
    public Rigidbody2D rigidbody; //Свойство Rigidbody для монетки
    public GameObject Cucumber; //Огурец
    public Text Dialog; //Текст диалога
    public Text[] TextArray = new Text[3]; //Текст для кнопок
    public GameObject[] Button_Sostoania = new GameObject[3]; //Массив для хранения кнопок ответа
    public Rigidbody2D Cherry_Rigitbody; //Rigitbody для черри
    public bool axx = true;
    [SerializeField] private Hero hero;
    public GameObject BackGround;
    public GameObject Rucopis;
    public GameObject Fertilizer_Prefab;
    private int quantidyFertilizers = 1;
    

    //Глобальные переменные и массивы

    //Количество вопросов
    private int Number_Question = 0; 
    private int Number_Question_Button = 0; 
    private int Number_Question_Text = 0;
    private int reaction = 0;
    //Массивы с вопросвми ответами
    public string[,] Answer1_Cucumber = new string[4,3];
    public string[,] Answer1_Hero = new string[4,3];
    public string[,] Button_Text = new string[4, 3];
    //Скорость вращения монетки
    public float n = 200f;
    //Отслеживание видимости кнопок
    private bool[] Visible_Button = { false, false, false };
    int a = 0;
    int res;
    public bool Dialog_True = false;
    private string Udacha = "";
    
    [SerializeField] private Fertilisers fertilisers;
    [SerializeField] private Flylevel1 flylevel1; 
    private void Awake()
    {
        
        Answer1_Hero[0,0] = "Не твоё зелёное старое дело огурец.";
        Answer1_Hero[0,1] = "Это не имеет значение.";
        Answer1_Hero[0,2] = "Здравствуй!Наверное когда я рос,квкойто таракан мне откусил пол ноги.";

        Answer1_Cucumber[0,0] = "Ты дерзкий.Я не особо хочу иметь с тобой дело,но ты мне нравишся.Как тебя зовут?";
        Answer1_Cucumber[0,1] = "Ну ладно,не важно.Как тебя зовут?";
        Answer1_Cucumber[0,2] = "Ой как печально,приятно познакомится.Как тебя зовут?";

        Answer1_Hero[1,0] = "Не так тупо как тебя";
        Answer1_Hero[1,1] = "Черри";
        Answer1_Hero[1,2] = "Меня зовут помидорка Черри,Рад знакомству";

        Answer1_Cucumber[1,0] = "Мне как раз нужен такой наглый овощ который помог бы мне с очень важным заданием";
        Answer1_Cucumber[1,1] = "У меня есть одно задание,не хочешь поучаствовать?";
        Answer1_Cucumber[1,2] = "Славно.Очень славно.У меня есть одно очень важное задание,поможешь?";

        Answer1_Hero[2,0] = "Расскажи про задание старый хрыщ";
        Answer1_Hero[2,1] = "Что за задание";
        Answer1_Hero[2,2] = "Корнишон,не могли бы вы рассказать про задание?";

        Answer1_Cucumber[2,0] = "Уже много лет мы - овощи воюем с мухами и тараканими.И мне, мои прыщи подсказывают что где-то там,впереди нас ждёт ответ.Ну так что,ты готов пойти на встречу приключениям?";
        Answer1_Cucumber[2,1] = "Уже много лет мы - овощи воюем с мухами и тараканими.И мне, мои прыщи подсказывают что где-то там,впереди нас ждёт ответ.Ну так что,ты готов пойти на встречу приключениям?";
        Answer1_Cucumber[2,2] = "Уже много лет мы - овощи воюем с мухами и тараканими.И мне, мои прыщи подсказывают что где-то там,впереди нас ждёт ответ.Ну так что,ты готов пойти на встречу приключениям?";

        Answer1_Hero[3,0] = "А куда идти?";
        Answer1_Hero[3,1] = "Как не победить тараканов если у меня даже оружия нет?";
        Answer1_Hero[3,2] = "Что будет если меня раздавят?";

        Answer1_Cucumber[3,0] = "Иди вперёд,ты выйдешь с фермы и дойдёшь до логова их матки или кто там у них";
        Answer1_Cucumber[3,1] = "Я тебе дам мешочек с удобрениями,съешь его и получишь способности о которых даже не догадывался";
        Answer1_Cucumber[3,2] = "Лишь мёртвые помидоры знают!";

        Button_Text[0, 0] = "Не твоё дело";
        Button_Text[0, 1] = "Это не важно";
        Button_Text[0, 2] = "Сказать";

        Button_Text[1, 0] = "Дерзко";
        Button_Text[1, 1] = "Черри";
        Button_Text[1, 2] = "Рад знакомству";

        Button_Text[2, 0] = "Чё за ботва!";
        Button_Text[2, 1] = "Задание?";
        Button_Text[2, 2] = "Расскажите";

        Button_Text[3, 0] = "Куда идти?";
        Button_Text[3, 1] = "Как мне драться?";
        Button_Text[3, 2] = "А смерть?";
    }
   
    private void Start()
    {
        
        Rename_Button();        
    }
    float x = 10;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            End();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
           fertilisers.Init_Fertilizers(quantidyFertilizers,Fertilizer_Prefab);
        }
    }
    
    public void Money_Click()
    {
        Rucopis.SetActive(false);
        money.SetActive(false);
        Dialog_True = true;
        canvas.SetActive(true);
        Debug.Log("On Dialog");
        hero.Artur(false);
    }
    public void Button_Zlobno_Click()
    {
        if (Number_Question == 3)
            Visible_Button[0] = true;
        Debug.Log("0" + Visible_Button[0]);
       
        Button_sostoania(0);
        
    }
    public void Button_Norm_Click()
    {
        
        if (Number_Question == 3)
            Visible_Button[1] = true;
        Debug.Log("1" + Visible_Button[1]);
        
        Button_sostoania(1);
        
    }
    public void Button_Good_Click()
    {
        
        if (Number_Question == 3)
            Visible_Button[2] = true;
        Debug.Log("2" + Visible_Button[0]);
        
        Button_sostoania(2);
        
    }
    private void Button_sostoania(int react)
    {
        if (Number_Question != 3)
            Udacha = Udacha + react.ToString();
        Dialog.text = $"Черри: {Answer1_Hero[Number_Question, react]}";
            OnOff_Buttton(false);        
            Invoke("CucumberTalk", 4f);
            reaction = react;
        Debug.Log("Удача: " + Udacha);
    }    
    private void CucumberTalk()
    {
       
        Dialog.text = $"Корнишон: {Answer1_Cucumber[Number_Question, reaction]}";
        if (Number_Question < 3)
            Number_Question++;
       else
            Number_Question = 3;
        Debug.Log($"{Number_Question}");                      
        Rename_Button();        
        OnOff_Buttton(true);
        if (Number_Question_Button == 3)
            Button_Sostoania[reaction].SetActive(false);
        if(Number_Question_Button < 3)
            Number_Question_Button++;
       else        
           Number_Question_Button = 3;

        res = Vis_But();
        if (res == 3)
        {
            Invoke("PreEnd", 4f);
            
        }
       

    }
    private void OnOff_Buttton(bool a)
    {
        for (int i = 0; i < Button_Sostoania.Length; i++)
        {           
          Button_Sostoania[i].SetActive(a);            
        }
    }
    private void Rename_Button()
    {
        if (Number_Question_Text < 4)
        {
            for (int i = 0; i < 3; i++)
            {
                TextArray[i].text = Button_Text[Number_Question_Text, i];                
            }
        }        
        Number_Question_Text++;
    }
    private int Vis_But()
    {
        int res = 0;
        for (int i = 0; i < Visible_Button.Length; i++)
        {
            if (Visible_Button[i] == true)
            {
                Button_Sostoania[i].SetActive(false);
                res++;
            }            
        }
        return res;
        
    }
    private void PreEnd()
    {            
        Dialog.text = "Корнишон: Ну что.Я желаю тебе удачи и надеюсь что ты спасёшь все овощи грядки!";
        Invoke("End", 3f);
    }
    private void End()
    {
        if (Udacha == "120")
            quantidyFertilizers++;

        canvas.SetActive(false);
        Cucumber.SetActive(false);
        hero.Artur(true);
        fertilisers.Init_Fertilizers(quantidyFertilizers,Fertilizer_Prefab);
        flylevel1.InitializeteFly();
        
    }

    

    


}

