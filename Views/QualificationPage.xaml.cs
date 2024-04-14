namespace cerazoT1.Views;

public partial class QualificationPage : ContentPage
{
	public QualificationPage()
	{
		InitializeComponent();
	}

    public Boolean validateNote(string note)
    {
        if (Convert.ToDouble(note) >= 11 || Convert.ToDouble(note) < 0) return true;
        else return false;
    }

    private void btnValidate_Clicked(object sender, EventArgs e)
    {
        if (pckStudent.SelectedIndex == -1)
        {
            DisplayAlert("Error", "Selecione un estudiante", "Aceptar");
        }
        else if (string.IsNullOrWhiteSpace(txtNote1.Text) ||
            string.IsNullOrWhiteSpace(txtNote2.Text) ||
            string.IsNullOrWhiteSpace(txtTest1.Text) ||
            string.IsNullOrWhiteSpace(txtTest2.Text))
        {
            DisplayAlert("Error", "Ingresa un valor valido", "Aceptar");
        }
        else if (validateNote(txtNote1.Text) ||
            validateNote(txtNote2.Text) ||
            validateNote(txtTest1.Text) ||
            validateNote(txtTest2.Text))
        {
            DisplayAlert("Error", "Ingresa un valor valido entre 0 y 10", "Aceptar");
        }
        else
        {
            string status = "";
            double firstPartial = Math.Round(Convert.ToDouble(txtNote1.Text) * 0.3 + Convert.ToDouble(txtTest1.Text) * 0.2, 2);
            double secondPartial = Math.Round(Convert.ToDouble(txtNote2.Text) * 0.3 + Convert.ToDouble(txtTest2.Text) * 0.2, 2);
            double finalNote = Math.Round(firstPartial + secondPartial, 2);

            if (finalNote >= 7) status = "APROBADO";
            else if (finalNote >= 5 && finalNote <= 6.99) status = "COMPLEMENTARIO";
            else status = "REPROBADO";

            DisplayAlert("Reporte:", "Estudiante: "+ pckStudent.Items[pckStudent.SelectedIndex].ToString() + 
                "\nFecha: " + pckDate.Date.ToString() + "\n\nNota Parcial 1: " + firstPartial + 
                "\nNota Parcial 2: " + secondPartial + "\n\n" + "\nNota Final: " + finalNote + "\nEstado: " + status, "Aceptar");
        }
    }
}