using System;
using System.Collections.Generic;
using Godot;

public class Question{
	Dictionary<int, int> question = new Dictionary<int, int>();
	int idquestion;
	int nbquestion = 0;

	
	public Question(){
	question.Add(1, 1);
	question.Add(2, 11);
	question.Add(3,21);
	question.Add(4, 31);
	question.Add(5, 41);
	question.Add(6, 51);
	question.Add(7, 61);
	question.Add(8, 71);
	question.Add(9, 81);
	question.Add(10, 91);
	question.Add(11,101);
	}
 
 

	public string getquestion(int composante){
		string requete = GestionDb.Instance.ExecuteRequete("select question from question where id ="+question[composante].ToString()+ " and idcat = "+composante.ToString()+";");
		idquestion = question[composante];
		return requete;
	}
	public int getnbquestion(){
		return nbquestion;
	}

	public void question_suivante(int composante){
		question[composante]+=1;
	}


	public int getnumquestion(){
		return idquestion;
	}

	public int getvaleur1(string j){
		return Int32.Parse(GestionDb.Instance.ExecuteRequete("select "+ j+" from Reponse where idquestion ="+idquestion.ToString()+" and idreponse=1;"));
	}

	public int getvaleur2(string j){
		return Int32.Parse(GestionDb.Instance.ExecuteRequete("select "+ j+" from Reponse where idquestion ="+idquestion.ToString()+" and idreponse=2;"));
	}

	public string reponse1(){
		return GestionDb.Instance.ExecuteRequete("select reponse from Reponse where idquestion ="+idquestion.ToString()+ " and idreponse = 1 ;");
	}

	public string reponse2(){
		return GestionDb.Instance.ExecuteRequete("select reponse from Reponse where idquestion ="+idquestion.ToString()+ " and idreponse = 2 ;");
	}


}
