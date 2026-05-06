using FindShaulsTreasure.Pages;

namespace FindShaulsTreasure
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Page startPage = Services.GameState.TeamId == -1 ? new AdminPanel() : new QuestHolder();

            return new Window(startPage);
        }
    }
}