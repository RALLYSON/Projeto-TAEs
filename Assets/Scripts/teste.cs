using UnityEngine;
using UnityEngine.UI;

public class teste : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button m_YourFirstButton, m_YourSecondButton, m_YourThirdButton;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        
        m_YourSecondButton.onClick.AddListener(delegate { TaskWithParameters("Hello"); });
      
    }

   

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
    }

}