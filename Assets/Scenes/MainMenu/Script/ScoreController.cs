using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] Text[] playerScore;
   


    public void OnEnable() {
        LoadScores();
    }

    private void LoadScores() {
        string line;
       // --> List<ObjetoPlayerScore> playerScores = new List<ObjetoPlayerScore>();
        try {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr =  File.OpenText("ScoreTopTen.txt");
            //Read the first line of text
            line = sr.ReadToEnd();
            //Continue to read until you reach end of file
            if (line != null) {
                //write the line to console window
                string[] scores = line.Split('\n');
                for(int i = 0; i < scores.Length; i++) {
                    string[] nameWithScore = scores[i].Split(','); // Lo separa por "," (2 elementos)
                    //--> ObjetoPlayerScore ps = new ObjetoPlayerScore(nameWithScore[1], nameWithScore[2]);
                    //--> playerScores.Add(ps);
                    //playerScore[i].text = nameWithScore[0] + ": " + nameWithScore[1];
                    //playerScore[i].text = $"Name: {nameWithScore[0]}    Score:{nameWithScore[1]}";

                }
                //player_1.text = scores[2];



            }
            //close the file
            sr.Close();
            
        } catch (Exception e) {
            Debug.Log("Exception: " + e.Message);
        } 
    }

    public void GuardarScore() {

        using (StreamWriter outputFile = new StreamWriter("ScoreTopTen.txt")) {

            outputFile.WriteLine("Prueba asd");
            

            Debug.Log("prueba");
        }
    }

} // Fin
