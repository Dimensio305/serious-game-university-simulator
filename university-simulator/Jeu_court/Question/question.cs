using System;
using Godot;

public class Question{
    int cat = 1 ;
    int question =1 ;
    int question_cat = 5 ; 

    int nb_question = 0;

    
    public Question(){}
 
 
    public void setnbquestion(){
        nb_question+=1;
    }
    public string getquestion(){
        string requete = GestionDb.Instance.ExecuteRequete("select question from question where id ="+question.ToString()+ " and idcat = "+cat.ToString()+";");
        return requete;
    }

    public void question_suivante(){
        if(cat>= 1 && cat<=11){
            cat+=1;
            question = question_cat+(cat-1)*10;
        }
        else{
            cat = 1 ;
            question_cat+=1;
        }
        nb_question+=1;
    } 

    public int getnumquestion(){
        return nb_question;
    }

    public Rendezvous nvrdv(){
        Random rand = new Random();
        int jour = rand.Next(0,5);
        return Rendezvous.GenererRendezVousAleatoire(jour);
    }

    public int getvaleur1(string j){
        return Int32.Parse(GestionDb.Instance.ExecuteRequete("select "+ j+" from Reponse where idquestion ="+question.ToString()+" and idreponse=1;"));
    }

    public int getvaleur2(string j){
        return Int32.Parse(GestionDb.Instance.ExecuteRequete("select "+ j+" from Reponse where idquestion ="+question.ToString()+" and idreponse=2;"));
    }

    public string reponse1(){
        return GestionDb.Instance.ExecuteRequete("select reponse from Reponse where idquestion ="+question.ToString()+ " and idreponse = 1 ;");
    }

    public string reponse2(){
        return GestionDb.Instance.ExecuteRequete("select reponse from Reponse where idquestion ="+question.ToString()+ " and idreponse = 2 ;");
    }


}