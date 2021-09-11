using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RegisterPage1 : MonoBehaviour
{
    public static string theName;//username display on page 2
    public static string username;//user from register page
    public static string passCheck;//retyped pass from register page
    public static string password;//pass from register page
    public static string cusername;//user from login page
    public static string cpassword;//pass from login page

    public GameObject textDisplay;//displaying username on page 2
    public GameObject usernameInput;//user GameObject from register page
    public GameObject passwordInput;//pass GameObject from register page
    public GameObject passCheckInput;//retyped pass GameObject from register page
    public GameObject cuserCheck;//user GameObject from login page
    public GameObject cpassCheck;//pass GameObject from login page

    //error displays
    public GameObject registerErrorDisplay;
    public GameObject loginErrorDisplay;

    //move to pages
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;


    /*
    public bool alreadyName;//inputfield display of username last used  
    public InputField UserTextDisp;


    //start
    void start()
    {
        if (alreadyName == true)
            UserTextDisp.text = PlayerPrefs.GetString("saveName");
    }

    //save username to display function
    public void SaveThis(string newName)
    {
        alreadyName = true;
        PlayerPrefs.SetString("saveName", newName);
    }
   */



    //check if retyped password equal to the password (page 1)
    public void passwordCheck()
    {
        username = usernameInput.GetComponent<Text>().text;
        password = passwordInput.GetComponent<Text>().text;
        passCheck = passCheckInput.GetComponent<Text>().text;

        if (username == "" || password == "" || passCheck == "")
            registerErrorDisplay.GetComponent<Text>().text = "information pending";
        
        else
        {

            if (password != passCheck)        
                registerErrorDisplay.GetComponent<Text>().text = "password match not found";          
            else
            {
                page1.SetActive(false);
                page2.SetActive(true);
            }

        }

    }


    //check if username and password are same (page 2)
    public void loginCheck()
    {

        password = usernameInput.GetComponent<Text>().text;
        username = passwordInput.GetComponent<Text>().text;
        cpassword = cuserCheck.GetComponent<Text>().text;
        cusername = cpassCheck.GetComponent<Text>().text;

        if (username == "" || password == "")
            loginErrorDisplay.GetComponent<Text>().text = "information pending";
        else
        {
            if (username == cusername)
            {

                if (password == cpassword)
                {
                    page2.SetActive(false);
                    page3.SetActive(true);
                }
            }
            else
                loginErrorDisplay.GetComponent<Text>().text = "incorrect username or password";
        }
        

    }

    
    int stringIndex = 0;
    int characterIndex = 0;
    public float speed = 0.1f;

    //displaying welcome username on (page 2)
    public void displayName()
    {
        StartCoroutine(DisplayTimer());
    }


    IEnumerator DisplayTimer()
    {
        theName = usernameInput.GetComponent<Text>().text;
        string[] strings = { "Welcome! \n" + theName + "\t Log into your account", "" };

        while (1 == 1)
        {
            yield return new WaitForSeconds(speed);
            if (characterIndex > strings[stringIndex].Length)
            {
                continue;
            }
            textDisplay.GetComponent<Text>().text = strings[stringIndex].Substring(0, characterIndex);
            characterIndex++;
        }

    }

    //go back to register (page 2)
    public void backButtonPage2()
    {

        page2.SetActive(false);
        page1.SetActive(true);
     
    }

    //go back to login (page 3) 
    public void backButtonPage3()
    {

        page3.SetActive(false);
        page2.SetActive(true);

    }

}
