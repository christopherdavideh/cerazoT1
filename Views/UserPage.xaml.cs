namespace cerazoT1.Views;

public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
	}


    private void btn_calculate_Clicked(object sender, EventArgs e)
    {
		double contribution = Convert.ToDouble(txt_salary.Text) * 0.0945;
        if (txt_age.Text.Length > 0 &&
            txt_name.Text.Length > 0 &&
            txt_lastname.Text.Length > 0 &&
            txt_salary.Text.Length > 0)
        {
            DisplayAlert("Afiliado/a:", txt_name.Text + " " + txt_lastname.Text + ", su edad es " + txt_age.Text +
              ", con suledo de: $" + txt_salary.Text + "\n\n" + "Su aporte mensual al IESS es: $" + contribution, "Acpetar");
        }
        else if(Convert.ToInt32(txt_salary.Text) < 1 || Convert.ToInt32(txt_salary.Text) < 0 )
        {
            DisplayAlert("Afiliado/a:", "Ingrese valore númericos válidos." + contribution, "Acpetar");
        }
        else
        {
            DisplayAlert("Afiliado/a:", "Ingrese los campos Requeridos." + contribution, "Acpetar");
        }
    }
}