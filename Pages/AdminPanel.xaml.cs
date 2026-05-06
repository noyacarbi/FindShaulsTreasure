using FindShaulsTreasure.Services;

namespace FindShaulsTreasure.Pages;

public partial class AdminPanel : ContentPage
{
	public AdminPanel()
	{
		InitializeComponent();
	}

    private async void bStart_Clicked(object sender, EventArgs e)
	{
		const string SECRET = "1234";

		if (ePass.Text.Trim() != SECRET.Trim())
		{
			await DisplayAlert("Wrong", "Wrong password", "OK");
			return;
		}

		if (int.TryParse(eTeam.Text.Trim(), out int id))
		{
			GameState.Clear();
			GameState.TeamId = id;
			GameState.QuestIndex = 0;
			GameState.Score = 0;

            if (Application.Current?.Windows.Count > 0)
            {
                Application.Current.Windows[0].Page = new QuestHolder();
            }
        }
		else
		{
			await DisplayAlert("Error", "Invalid team ID", "OK");
		}
	}
}