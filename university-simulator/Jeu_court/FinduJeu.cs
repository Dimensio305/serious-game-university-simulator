using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// Script lié à la scène FinduJeu
/// Elle s'occupe de gérer les différentes fins possibles
/// </summary>
public partial class FinduJeu : Node2D
{
	//Noeud enfant de FinduJeu
	private TextEdit _textEdit;
	private TextureRect _fond;
	
	//Liste regroupant les chemins des différents écrans de fin
	private List<String> _listeFond = new List<String>{
			"res://fond_et_titre/Designer (3).jpeg",
			"res://fond_et_titre/Designer (2).jpeg",
			"res://fond_et_titre/Designer (4).jpeg",
			"res://fond_et_titre/Designer (5).jpeg",
			"res://fond_et_titre/Designer (6).jpeg"
		};
	
	/// <summary>
	/// Lors du premier chargement de la scène (et le seul) prends la valeur de chaques jauges
	/// Si il l'une d'elle est à 0 le joueur a perdu et l'on charge l'écran de game over associé
	/// Sinon c'est l'écran de victoire qui est affiché
	/// </summary>
	public override void _Ready()
	{
			_textEdit = GetNode<TextEdit>("TextEdit");
			_fond = GetNode<TextureRect>("Fond");
			List<int> jauges = new List<int>();
			jauges.Add(JaugeManager.GetJaugeValue("Jauge1"));
			jauges.Add(JaugeManager.GetJaugeValue("Jauge2"));
			jauges.Add(JaugeManager.GetJaugeValue("Jauge3"));
			jauges.Add(JaugeManager.GetJaugeValue("Jauge4"));
			int i = 1;
			_textEdit.Text = "vous avez gagnez";
			_fond.Texture = GD.Load<Texture2D>(_listeFond[0]);
			foreach(int jauge in jauges){
				if(jauge==0){
					switch(i){
					case 1 :
						_textEdit.Text = "vous avez perdu car vous ne savez pas gérer vos finances";
						break;
					case 2 :
						_textEdit.Text = "vous avez perdu car vous ne savez pas gérer la satisfaction de vos professeur";
						break;
					case 3 :
						_textEdit.Text = "vous avez perdu car vous ne savez pas gérer le taux d'insertion de vos élèves";
						break;
					case 4: 
						_textEdit.Text = "vous avez perdu car vous ne savez pas gérer le taux de réussite de vos élèves";
						break;
					default : 
						break;
					}
				_fond.Texture = GD.Load<Texture2D>(_listeFond[i]);
				}
				i++;
			
		}
	}
}
