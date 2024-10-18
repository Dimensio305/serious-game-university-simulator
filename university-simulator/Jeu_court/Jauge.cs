using Godot;
using System;

public partial class Jauge : TextureRect
{
	
	public void Modif(int Changement){
		var BoiteBarre = GetNodeOrNull<BoxContainer>("ConteneurJauge");
		var Barre = BoiteBarre.GetNodeOrNull<ProgressBar>("JaugeProg");
		Barre.Value = Barre.Value + Changement;
	}
}
