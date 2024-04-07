namespace cerazoT1.Views;

public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
	}


    private void btn_calculate_Clicked(object sender, EventArgs e)
    {
		
        if (!string.IsNullOrEmpty(txt_age.Text) &&
            !string.IsNullOrEmpty(txt_name.Text) &&
            !string.IsNullOrEmpty(txt_lastname.Text) &&
            !string.IsNullOrEmpty(txt_salary.Text))
        {
            double contribution = Convert.ToDouble(txt_salary.Text) * 0.0945;
            DisplayAlert("Afiliado/a:", txt_name.Text + " " + txt_lastname.Text + ", su edad es " + txt_age.Text +
              ", con suledo de: $" + txt_salary.Text + "\n\n" + "Su aporte mensual al IESS es: $" + contribution, "Acpetar");
        }
        else if(Convert.ToInt32(txt_age.Text) < 1 || Convert.ToInt32(txt_salary.Text) < 0 )
        {
            DisplayAlert("Afiliado/a:", "Ingrese valore númericos válidos.", "Acpetar");
        }
        else
        {
            DisplayAlert("Afiliado/a:", "Ingrese los campos Requeridos.", "Acpetar");
        }
    }
}