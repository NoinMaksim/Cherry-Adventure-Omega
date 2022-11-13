using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cucumberTakl : MonoBehaviour
{
    public GameObject money; //�������
    public GameObject canvas; //������ �������
    public Transform tr; //�������� Transform ��� �������
    public Rigidbody2D rigidbody; //�������� Rigidbody ��� �������
    public GameObject Cucumber; //������
    public Text Dialog; //����� �������
    public Text[] TextArray = new Text[3]; //����� ��� ������
    public GameObject[] Button_Sostoania = new GameObject[3]; //������ ��� �������� ������ ������
    public Rigidbody2D Cherry_Rigitbody; //Rigitbody ��� �����
    public bool axx = true;
    [SerializeField] private Hero hero;
    public GameObject BackGround;
    public GameObject Rucopis;
    public GameObject Fertilizer_Prefab;
    private int quantidyFertilizers = 1;
    

    //���������� ���������� � �������

    //���������� ��������
    private int Number_Question = 0; 
    private int Number_Question_Button = 0; 
    private int Number_Question_Text = 0;
    private int reaction = 0;
    //������� � ��������� ��������
    public string[,] Answer1_Cucumber = new string[4,3];
    public string[,] Answer1_Hero = new string[4,3];
    public string[,] Button_Text = new string[4, 3];
    //�������� �������� �������
    public float n = 200f;
    //������������ ��������� ������
    private bool[] Visible_Button = { false, false, false };
    int a = 0;
    int res;
    public bool Dialog_True = false;
    private string Udacha = "";
    
    [SerializeField] private Fertilisers fertilisers;
    [SerializeField] private Flylevel1 flylevel1; 
    private void Awake()
    {
        
        Answer1_Hero[0,0] = "�� ��� ������ ������ ���� ������.";
        Answer1_Hero[0,1] = "��� �� ����� ��������.";
        Answer1_Hero[0,2] = "����������!�������� ����� � ���,������� ������� ��� ������� ��� ����.";

        Answer1_Cucumber[0,0] = "�� �������.� �� ����� ���� ����� � ����� ����,�� �� ��� ��������.��� ���� �����?";
        Answer1_Cucumber[0,1] = "�� �����,�� �����.��� ���� �����?";
        Answer1_Cucumber[0,2] = "�� ��� ��������,������� ������������.��� ���� �����?";

        Answer1_Hero[1,0] = "�� ��� ���� ��� ����";
        Answer1_Hero[1,1] = "�����";
        Answer1_Hero[1,2] = "���� ����� ��������� �����,��� ����������";

        Answer1_Cucumber[1,0] = "��� ��� ��� ����� ����� ������ ���� ������� ����� �� ��� � ����� ������ ��������";
        Answer1_Cucumber[1,1] = "� ���� ���� ���� �������,�� ������ �������������?";
        Answer1_Cucumber[1,2] = "������.����� ������.� ���� ���� ���� ����� ������ �������,��������?";

        Answer1_Hero[2,0] = "�������� ��� ������� ������ ����";
        Answer1_Hero[2,1] = "��� �� �������";
        Answer1_Hero[2,2] = "��������,�� ����� �� �� ���������� ��� �������?";

        Answer1_Cucumber[2,0] = "��� ����� ��� �� - ����� ����� � ������ � ����������.� ���, ��� ����� ������������ ��� ���-�� ���,������� ��� ��� �����.�� ��� ���,�� ����� ����� �� ������� ������������?";
        Answer1_Cucumber[2,1] = "��� ����� ��� �� - ����� ����� � ������ � ����������.� ���, ��� ����� ������������ ��� ���-�� ���,������� ��� ��� �����.�� ��� ���,�� ����� ����� �� ������� ������������?";
        Answer1_Cucumber[2,2] = "��� ����� ��� �� - ����� ����� � ������ � ����������.� ���, ��� ����� ������������ ��� ���-�� ���,������� ��� ��� �����.�� ��� ���,�� ����� ����� �� ������� ������������?";

        Answer1_Hero[3,0] = "� ���� ����?";
        Answer1_Hero[3,1] = "��� �� �������� ��������� ���� � ���� ���� ������ ���?";
        Answer1_Hero[3,2] = "��� ����� ���� ���� ��������?";

        Answer1_Cucumber[3,0] = "��� �����,�� ������� � ����� � ������ �� ������ �� ����� ��� ��� ��� � ���";
        Answer1_Cucumber[3,1] = "� ���� ��� ������� � �����������,����� ��� � �������� ����������� � ������� ���� �� �����������";
        Answer1_Cucumber[3,2] = "���� ������ �������� �����!";

        Button_Text[0, 0] = "�� ��� ����";
        Button_Text[0, 1] = "��� �� �����";
        Button_Text[0, 2] = "�������";

        Button_Text[1, 0] = "������";
        Button_Text[1, 1] = "�����";
        Button_Text[1, 2] = "��� ����������";

        Button_Text[2, 0] = "׸ �� �����!";
        Button_Text[2, 1] = "�������?";
        Button_Text[2, 2] = "����������";

        Button_Text[3, 0] = "���� ����?";
        Button_Text[3, 1] = "��� ��� �������?";
        Button_Text[3, 2] = "� ������?";
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
        Dialog.text = $"�����: {Answer1_Hero[Number_Question, react]}";
            OnOff_Buttton(false);        
            Invoke("CucumberTalk", 4f);
            reaction = react;
        Debug.Log("�����: " + Udacha);
    }    
    private void CucumberTalk()
    {
       
        Dialog.text = $"��������: {Answer1_Cucumber[Number_Question, reaction]}";
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
        Dialog.text = "��������: �� ���.� ����� ���� ����� � ������� ��� �� ������ ��� ����� ������!";
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

